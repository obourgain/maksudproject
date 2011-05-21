﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MovieBrowser.Controller;
using MovieBrowser.Model;

namespace MovieBrowser.Forms
{
    public partial class UpdateMovieInformation : Form
    {
        public UpdateMovieInformation()
        {
            InitializeComponent();
        }


        private readonly List<Movie> _movies;
        public UpdateMovieInformation(List<Movie> movies)
        {
            InitializeComponent();
            _movies = movies;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var controller = new MovieBrowserController();

            FireText("Starting Background 1 ...");
            int count = _movies.Count;
            int i = 1;
            foreach (var movie in _movies)
            {

                FireText("#" + i++ + "/" + count + " Searching " + movie.Title);


                if (movie.IsValidMovie)
                {
                    FireText("Found Exact Match: ImdbId= " + movie.ImdbId);
                    String src = HttpUtility.HttpHelper.DownloadWebPage(MovieBrowserController.ImdbTitle + movie.ImdbId);
                    controller.CollectAndAddMovieToDb(src);
                    FireText("Finished: ImdbId= " + movie.ImdbId);
                }
                else
                {
                    FireText("Trying ... to Guess...");
                    String src = HttpUtility.HttpHelper.DownloadWebPage(MovieBrowserController.ImdbSearch + HttpUtility.HttpHelper.UrlEncode(movie.Title));
                    var m = controller.GuessMovie(src);

                    var item = new ListViewItem(movie.Title);
                    item.SubItems.Add(m.Title);
                    item.SubItems.Add(m.ImdbId);
                    item.SubItems.Add(m.Year + "");
                    item.SubItems.Add(movie.FilePath);

                    if (!string.IsNullOrEmpty(m.ImdbId))
                    {
                        FireText("I guess it is '" + m.Title + "' with ImdbId=" + m.ImdbId);
                        item.Checked = true;
                    }

                    AddItem(item);
                }
            }
            FireText("DONE.... I am FINISHED...");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private delegate void AddItemDelegate(object value);
        private void AddItem(object value)
        {
            if (this.listView1.InvokeRequired)
            {
                // This is a worker thread so delegate the task.
                this.listView1.Invoke(new AddItemDelegate(this.AddItem), value);
            }
            else
            {
                // This is the UI thread so perform the task.
                listView1.Items.Add((ListViewItem)value);
            }
        }

        private delegate void FireTextDelegate(string text);
        private void FireText(string value)
        {
            if (this.textBox1.InvokeRequired)
            {
                // This is a worker thread so delegate the task.
                this.textBox1.Invoke(new FireTextDelegate(this.FireText), value);
            }
            else
            {
                // This is the UI thread so perform the task.
                textBox1.AppendText(value + "\r\n");
            }
        }



        private List<Movie> _update;

        private void button2_Click(object sender, EventArgs e)
        {
            _update = new List<Movie>();
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked)
                {
                    var movie = new Movie();
                    movie.Title = item.SubItems[1].Text;
                    movie.ImdbId = item.SubItems[2].Text;
                    int year = 0;
                    int.TryParse(item.SubItems[3].Text, out year);
                    movie.Year = year;
                    movie.ImdbId = item.SubItems[2].Text;
                    movie.FilePath = item.SubItems[4].Text;

                    if (!string.IsNullOrEmpty(movie.ImdbId))
                        _update.Add(movie);
                }
            }

            backgroundWorker2.RunWorkerAsync();

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            FireText("Starting Background 2 ...");
            var controller = new MovieBrowserController();
            int count = _update.Count;
            int i = 1;
            foreach (var movie in _update)
            {
                FireText("#" + i++ + "/" + count + " Found Exact Match: ImdbId= " + movie.ImdbId);
                String src = HttpUtility.HttpHelper.DownloadWebPage(MovieBrowserController.ImdbTitle + movie.ImdbId);
                var m = controller.CollectAndAddMovieToDb(src);
                FireText("Finished: ImdbId= " + movie.ImdbId);

                m.FilePath = movie.FilePath;
                controller.ChangeFolderName(m);
            }

            FireText("DONE.... I am FINISHED...");

        }

    }
}
