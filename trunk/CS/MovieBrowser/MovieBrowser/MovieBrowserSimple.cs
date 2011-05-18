using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HttpUtility;
using ShellLib;

namespace MovieBrowser
{
    public partial class MovieBrowserSimple : Form
    {
        readonly FolderBrowserDialog _dialog = new FolderBrowserDialog();
        private const string GoogleSearch = "http://www.google.com/search?q=";
        private const string ImdbSearch = "http://www.imdb.com/find?s=all&q=";
        private const string ImdbTitle = "http://www.imdb.com/title/";

        private MovieNode _selectedNode = null;


        public MovieBrowserSimple()
        {
            InitializeComponent();
            treeView1.TreeViewNodeSorter = new MovieComparer();
        }
        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            LoadFolderDialog();
        }
        private void ToolStripButton2Click(object sender, EventArgs e)
        {
            SearchMovie(ImdbSearch);
        }
        private void TreeView1DoubleClick(object sender, EventArgs e)
        {
            SearchMovie(ImdbSearch);
        }
        private void SearchToolStripMenuItemClick(object sender, EventArgs e)
        {
            SearchMovie(ImdbSearch);
        }
        private void GoogleToolStripMenuItemClick(object sender, EventArgs e)
        {
            SearchMovie(GoogleSearch);
        }
        private void ToolStripButton3Click(object sender, EventArgs e)
        {
            SearchMovie(GoogleSearch);
        }
        private void ToolStripButton4Click(object sender, EventArgs e)
        {
            DeleteNode();
        }
        private void TreeView1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (treeView1.SelectedNode.Nodes.Count == 0)
                    Open();
                else
                {
                    SearchMovie(ImdbSearch);
                }

            }
            else if (e.KeyCode == Keys.Space)
            {
                Open();
            }
        }
        private void IntelligentTrackerToolStripMenuItemClick(object sender, EventArgs e)
        {
            intelligentTrackerToolStripMenuItem.Checked = !intelligentTrackerToolStripMenuItem.Checked;
        }
        private void MovieBrowserSimpleFormClosing(object sender, FormClosingEventArgs e)
        {

            SaveFolderList();

        }
        private void MovieBrowserSimpleLoad(object sender, EventArgs e)
        {
            LoadAllFolders();
        }
        private void WebBrowser1DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                textBox1.AppendText("Document Completed: " + webBrowser1.ReadyState + "\r\n");
                if (intelligentTrackerToolStripMenuItem.Checked)
                    Redirect(webBrowser1.DocumentText);
            }
            catch (Exception)
            {
            }

        }
        private void ToolStripButton7Click(object sender, EventArgs e)
        {
            try
            {

                ParseMovieInfo();
            }
            catch { }
        }
        private void ToolStripButton6Click(object sender, EventArgs e)
        {
            UpdateMovie();
        }
        private void ToolStripButton8Click(object sender, EventArgs e)
        {
            Open();
        }
        private void ToolStripButton5Click1(object sender, EventArgs e)
        {
            SaveIgnoreList();
        }
        private void WebBrowser1Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.AppendText("Navigated to " + e.Url.AbsoluteUri + "\r\n");
        }
        private void ToolStripButton9Click(object sender, EventArgs e)
        {
            LoadAllFolders();
        }
        private void UpdateToolStripMenuItemClick(object sender, EventArgs e)
        {
            UpdateMovie();
        }

        #region Code
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
                newdir += CleanedName(HttpHelper.Decode(String.Format("{0} ({1}), [{2}] [{3}]", movie.Title, movie.Year, movie.Rating, movie.ImdbId)));

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
        private static string CleanedName(string name)
        {
            return Regex.Replace(name, @"[\\/:*?""<>|]+", "");
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
        #endregion

        private void TsSaveFoldersClick(object sender, EventArgs e)
        {
            SaveFolderList();
        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.TreeViewNodeSorter = new MovieComparer();

            treeView1.Sort();
        }


    }
}
