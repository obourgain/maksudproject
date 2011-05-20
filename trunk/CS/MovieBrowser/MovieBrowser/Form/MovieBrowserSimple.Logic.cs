using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CommonUtilities;
using HttpUtility;
using MovieBrowser.Model;
using ShellLib;

namespace MovieBrowser.Form
{
    partial class MovieBrowserSimple
    {

        private void LoadAllFolders()
        {
            treeView1.Nodes.Clear();

            if (Properties.Settings.Default.Paths != null)
            {
                foreach (var path in Properties.Settings.Default.Paths)
                {
                    LoadFolder(path);
                }
            }
            textIgnore.Text = "" + Properties.Settings.Default.Ignore;

            var entities = new MovieDbEntities();

            var list = entities.Movies.ToList();

            foreach (var movie in list)
            {
                listView1.Items.Add(new MovieListViewItem(movie));
            }
        }
        private void LoadFolderDialog()
        {
            if (_dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadFolder(_dialog.SelectedPath);
            }
        }
        private void LoadFolder(string folderPath)
        {

            var movie = Movie.FromFolderName(folderPath);
            var treeNode = new MovieNode(movie);
            treeView1.Nodes.Add(treeNode);

            FolderBrowseRecursively(treeNode, folderPath);
        }
        private static void FolderBrowseRecursively(MovieNode treeNode, string selectedPath)
        {

            var directories = Directory.GetDirectories(selectedPath);
            if (directories.Count() == 0) return;

            foreach (var directory in directories)
            {
                var movie = Movie.FromFolderName(directory);
                var tn = new MovieNode(movie);
                treeNode.Nodes.Add(tn);


                var files = Directory.GetFiles(directory);
                foreach (var file in files)
                {
                    movie = Movie.FromFolderName(file);
                    var node = new MovieNode(movie);
                    tn.Nodes.Add(node);
                }

                FolderBrowseRecursively(tn, directory);
            }
        }
        private void SearchMovie(String address)
        {
            try
            {
                _selectedNode = (MovieNode)treeView1.SelectedNode;
                var movie = (Movie)_selectedNode.Tag;
                if (address.Equals(ImdbSearch) && movie != null && !string.IsNullOrEmpty(movie.ImdbId))
                {
                    Navigate(ImdbTitle + movie.ImdbId);
                }
                else
                {
                    Navigate(address + IgnoreWords(_selectedNode.Text));
                }
            }
            catch { }
        }
        private void SearchMovie(String address, Movie movie)
        {
            try
            {
                if (address.Equals(ImdbSearch) && movie != null && !string.IsNullOrEmpty(movie.ImdbId))
                {
                    Navigate(ImdbTitle + movie.ImdbId);
                }
                else
                {
                    Navigate(address + IgnoreWords(_selectedNode.Text));
                }
            }
            catch { }
        }
        private string IgnoreWords(string text)
        {
            text = text.ToLower();
            string[] ignored = textIgnore.Text.ToLower().Split();
            text = ignored.Aggregate(text, (current, s) => string.IsNullOrEmpty(s) ? current : current.Replace(s, ""));
            text = text.Replace(".", " ");
            return text;
        }
        private void UpdateMovie()
        {
            try
            {
                var filename = (Movie)_selectedNode.Tag;

                var newdir = filename.FilePath.Substring(0, filename.FilePath.LastIndexOf("\\") + 1);

                var movie = ParseMovieInfo();
                //Directory.Move(filename, newdir);
                newdir += HttpHelper.Decode(movie.FolderName).Clean();

                Directory.Move(filename.FilePath, newdir);

                movie.FilePath = newdir;
                movie.IsValidMovie = true;
                _selectedNode.Text = movie.TitleWithRating;
                _selectedNode.Tag = movie;
                _selectedNode.SelectedImageIndex = _selectedNode.ImageIndex = movie.ImageIndex;
            }
            catch
            {
            }
        }
        private void SaveIgnoreList()
        {
            string[] words = textIgnore.Text.ToLower().Split();
            //Array.Sort(words);

            var t = (from s in words
                     orderby s descending
                     select s).ToArray();

            string s2 = string.Join(" ", t);

            textIgnore.Text = s2;
            Properties.Settings.Default.Ignore = s2;
            Properties.Settings.Default.Save();
        }
        private void SaveFolderList()
        {
            Properties.Settings.Default.Paths = new StringCollection();

            foreach (MovieNode node in treeView1.Nodes)
            {
                Properties.Settings.Default.Paths.Add(((Movie)node.Tag).FilePath);
            }
            Properties.Settings.Default.Save();
        }



        private Movie ParseMovieInfo()
        {
            var src = webBrowser1.DocumentText;
            var rating = Regex.Match(src, @"<span class=""rating-rating"">([\d.]+)<span>").Groups[1].Value;
            var match = Regex.Match(src, @"<title>(.+?) \(.*?([\d.]+)\)");

            var imdbId = Regex.Match(webBrowser1.Url.AbsolutePath, @"/title/(tt\d+)/").Groups[1].Value;

            textBox1.AppendText("Title: " + match.Groups[1].Value + "\r\n");
            textBox1.AppendText("Year: " + match.Groups[2].Value + "\r\n");
            textBox1.AppendText("Rating: " + rating + "\r\n");
            var movie = new Movie
            {
                Rating = Convert.ToDouble(rating),
                Title = HttpHelper.Decode(match.Groups[1].Value),
                Year = Convert.ToInt32(match.Groups[2].Value),
                ImdbId = imdbId,
                FilePath = ""
            };
            return movie;

        }
        private void DeleteNode()
        {
            try
            {
                if (MessageBox.Show(this, @"Sure To Delete", @"Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    treeView1.SelectedNode.Remove();
            }
            finally
            {

            }
        }
        private void Open()
        {
            var execute = new ShellExecute
            {
                Verb = ShellExecute.OpenFile,
                Path = ((Movie)treeView1.SelectedNode.Tag).FilePath
            };
            execute.Execute();
        }
        void Navigate(string url)
        {

            webBrowser1.Navigate(url);


        }
        private void Redirect(string src)
        {
            var match = Regex.Match(src, "Media from&nbsp;<a href=\"/title/(tt[0-9]+)/");
            var title = match.Groups[1].Value;
            if (!string.IsNullOrEmpty(title))
            {
                textBox1.AppendText("Redirect!...\r\n");
                webBrowser1.Navigate("http://www.imdb.com/title/" + title);
            }
        }

        private void LoadPenDrives()
        {
            tsPendrives.Items.Clear();

            var ss = FileHelper.UsbDrives();
            foreach (string t in ss)
            {
                tsPendrives.Items.Add(t);
            }
        }

        private void AddMovieToDb(Movie movie)
        {
            var entities = new MovieDbEntities();

            if (entities.Movies.Where(o => o.ImdbId.Equals(movie.ImdbId)).ToList().Count() == 0)
            {
                entities.AddToMovies(movie);
                entities.SaveChanges();
            }
            else
            {
                //Already exists
                Console.WriteLine(@"Exists: {0}", movie.ImdbId);
            }

        }

        private void UpdateMovieDataBaseFromFileSystem()
        {
            foreach (var node in treeView1.Nodes)
            {
                UpdateMovieDataBaseFromFileSystem((MovieNode)node);
            }
        }

        private void UpdateMovieDataBaseFromFileSystem(MovieNode movieNode)
        {
            if (movieNode.Movie.IsValidMovie)
            {
                AddMovieToDb(movieNode.Movie);
            }

            foreach (var node in movieNode.Nodes)
            {
                UpdateMovieDataBaseFromFileSystem((MovieNode)node);
            }
        }
    }
}
