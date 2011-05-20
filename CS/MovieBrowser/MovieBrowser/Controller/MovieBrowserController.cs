using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CommonUtilities;
using CommonUtilities.FileSystem;
using HttpUtility;
using MovieBrowser.Forms;
using MovieBrowser.Model;
using ShellLib;

namespace MovieBrowser.Controller
{
    public class DebugEventArgs : EventArgs
    {
        public string Text { get; set; }
        public DebugEventArgs(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public class MovieBrowserController
    {
        public event EventHandler OnDebugTextFired;

        public void InvokeOnDebugTextFired(string text)
        {
            var handler = OnDebugTextFired;
            if (handler != null) handler(this, new EventArgs() { });
        }

        public const string GoogleSearch = "http://www.google.com/search?q=";
        public const string ImdbSearch = "http://www.imdb.com/find?s=all&q=";
        public const string ImdbTitle = "http://www.imdb.com/title/";

        readonly FolderBrowserDialog _dialog = new FolderBrowserDialog();
        private readonly MovieNode _selectedNode = null;

        public WebBrowser Browser { get; set; }
        //public TreeView MovieFolderTree { get; set; }
        //public ListView ListView1 { get; set; }


        public void LoadAllFolders(TreeView movieFolderTree)
        {
            movieFolderTree.Nodes.Clear();
            if (Properties.Settings.Default.Paths == null) return;
            foreach (var path in Properties.Settings.Default.Paths)
            {
                LoadFolderIntoTreeView(path, movieFolderTree);
            }
        }

        public void LoadListViewMovies(ListView listView1)
        {
            listView1.Items.Clear();
            var entities = new MovieDbEntities();
            var list = entities.Movies.ToList();
            foreach (var movie in list)
            {
                listView1.Items.Add(new MovieListViewItem(movie));
            }
        }

        public void LoadFolderIntoTreeViewDialog(TreeView treeView)
        {
            if (_dialog.ShowDialog() == DialogResult.OK)
            {
                LoadFolderIntoTreeView(_dialog.SelectedPath, treeView);
            }
        }
        private static void LoadFolderIntoTreeView(string folderPath, TreeView treeView)
        {

            var movie = Movie.FromFolderName(folderPath);
            var treeNode = new MovieNode(movie);
            treeView.Nodes.Add(treeNode);

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

        public void SearchMovie(String address, Movie movie)
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
        private static string IgnoreWords(string text)
        {
            text = text.ToLower();
            string[] ignored = Properties.Settings.Default.IgnoreWords.ToLower().Split();
            text = ignored.Aggregate(text, (current, s) => string.IsNullOrEmpty(s) ? current : current.Replace(s, ""));
            text = text.Replace(".", " ");
            return text;
        }

        public void UpdateMovie()
        {
            try
            {
                var filename = (Movie)_selectedNode.Tag;

                var newdir = filename.FilePath.Substring(0, filename.FilePath.LastIndexOf("\\") + 1);

                var movie = ParseMovieInfo(Browser.Url.AbsolutePath, Browser.DocumentText);
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

        public string UpdateIgnoreWords()
        {
            string[] words = Properties.Settings.Default.IgnoreWords.ToLower().Split();
            //Array.Sort(words);

            var t = (from s in words
                     orderby s descending
                     select s).ToArray();

            string s2 = string.Join(" ", t);

            Properties.Settings.Default.IgnoreWords = s2;
            Properties.Settings.Default.Save();

            return s2;
        }

        public void SaveFolderListTree(TreeView movieFolderTree)
        {
            Properties.Settings.Default.Paths = new StringCollection();

            foreach (MovieNode node in movieFolderTree.Nodes)
            {
                Properties.Settings.Default.Paths.Add(((Movie)node.Tag).FilePath);
            }
            Properties.Settings.Default.Save();
        }

        public Movie ParseMovieInfo(string url, string src)
        {
            //var src = Browser.DocumentText;
            var rating = Regex.Match(src, @"<span class=""rating-rating"">([\d.]+)<span>").Groups[1].Value;
            var match = Regex.Match(src, @"<title>(.+?) \(.*?([\d.]+)\)");

            var imdbId = Regex.Match(url, @"/title/(tt\d+)/").Groups[1].Value;

            InvokeOnDebugTextFired("Title: " + match.Groups[1].Value + "\r\n");
            InvokeOnDebugTextFired("Year: " + match.Groups[2].Value + "\r\n");
            InvokeOnDebugTextFired("Rating: " + rating + "\r\n");
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

        public void DeleteNode(TreeView movieFolderTree)
        {
            try
            {

                if (MessageBox.Show(@"Sure To Delete", @"Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    movieFolderTree.SelectedNode.Remove();
            }
            finally
            {

            }
        }

        public void Open(string path)
        {
            var execute = new ShellExecute
            {
                Verb = ShellExecute.OpenFile,
                Path = path
            };
            execute.Execute();
        }
        void Navigate(string url)
        {

            Browser.Navigate(url);


        }

        public void Redirect(string src)
        {
            var match = Regex.Match(src, "Media from&nbsp;<a href=\"/title/(tt[0-9]+)/");
            var title = match.Groups[1].Value;
            if (!string.IsNullOrEmpty(title))
            {
                var url = "http://www.imdb.com/title/" + title;
                InvokeOnDebugTextFired(string.Format("Redirect to '{0}'...\r\n", url));
                Browser.Navigate(url);
            }
        }


        public void LoadPenDrives(ToolStripComboBox tsPendrives)
        {
            tsPendrives.Items.Clear();

            var ss = FileHelper.UsbDrives();
            foreach (string t in ss)
            {
                tsPendrives.Items.Add(t);
            }
            if (ss.Count > 0) tsPendrives.SelectedIndex = 0;
        }

        public void AddMovieToDb(Movie movie)
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

        public void UpdateMovieDataBaseFromFileSystem(TreeView treeView)
        {
            foreach (var node in treeView.Nodes)
            {
                UpdateMovieDataBaseFromFileSystem((MovieNode)node);
            }
        }

        public void UpdateMovieDataBaseFromFileSystem(MovieNode movieNode)
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

        public void SendTo(TreeView treeView1, ToolStripComboBox tsPendrives)
        {
            try
            {
                var movie = (Movie)treeView1.SelectedNode.Tag;
                var stt = new SendToThread()
                {
                    Source = movie.FilePath,
                    Destination = Path.Combine(tsPendrives.SelectedItem.ToString(), movie.FolderName)
                };
                //var thread = new Thread(stt.SendTo);
                //thread.Start();

                stt.SendTo();
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("SendTo:\r\n{0}", exception.Message));
            }
        }
    }
}
