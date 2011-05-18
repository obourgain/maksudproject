using System;
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
        FolderBrowserDialog dialog = new FolderBrowserDialog();
        private const string GOOGLE_SEARCH = "http://www.google.com/search?q=";
        private const string IMDB_SEARCH = "http://www.imdb.com/find?s=all&q=";
        private const string IMDB_TITLE = "http://www.imdb.com/title/";

        public MovieBrowserSimple()
        {
            InitializeComponent();

        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadFolderDialog();
        }

        private void LoadFolderDialog()
        {
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadFolder(dialog.SelectedPath);
            }
        }

        private void LoadFolder(string folderPath)
        {

            var movie = ParseFolderName(folderPath);
            var treeNode = new TreeNode(movie.TitleWithRating) { Tag = movie };
            treeView1.Nodes.Add(treeNode);

            FolderBrowseRecursively(treeNode, folderPath);
        }

        private void FolderBrowseRecursively(TreeNode treeNode, string selectedPath)
        {

            var directories = Directory.GetDirectories(selectedPath);
            if (directories.Count() == 0) return;

            foreach (var directory in directories)
            {
                var movie = ParseFolderName(directory);
                var tn = new TreeNode(movie.TitleWithRating) { Tag = movie };
                treeNode.Nodes.Add(tn);


                var files = Directory.GetFiles(directory);
                foreach (var file in files)
                {
                    movie = ParseFolderName(file);
                    var node = new TreeNode(movie.TitleWithRating) { Tag = movie };
                    tn.Nodes.Add(node);
                }

                FolderBrowseRecursively(tn, directory);
            }
        }

        //private Movie BaseName(string directory)
        //{
        //    return ParseFolderName(directory);
        //}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SearchMovie(IMDB_SEARCH);
        }

        private void SearchMovie(String address)
        {
            try
            {
                Movie movie = (Movie)treeView1.SelectedNode.Tag;
                if (address.Equals(IMDB_SEARCH) && movie != null && !string.IsNullOrEmpty(movie.ImdbId))
                {
                    Navigate(IMDB_TITLE + movie.ImdbId);
                }
                else
                {
                    Navigate(address + IgnoreWords(treeView1.SelectedNode.Text));
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

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            SearchMovie(IMDB_SEARCH);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchMovie(IMDB_SEARCH);
        }

        private void googleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchMovie(GOOGLE_SEARCH);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SearchMovie(GOOGLE_SEARCH);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DeleteNode();
        }

        private void DeleteNode()
        {
            try
            {
                if (MessageBox.Show(this, "Sure To Delete", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    treeView1.SelectedNode.Remove();
            }
            finally
            {

            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (treeView1.SelectedNode.Nodes.Count == 0)
                    Open();
                else
                {
                    SearchMovie(IMDB_SEARCH);
                }

            }
            else if (e.KeyCode == Keys.Space)
            {
                Open();
            }
        }

        private void Open()
        {
            try
            {
                ShellExecute execute = new ShellExecute
                {
                    Verb = ShellExecute.OpenFile,
                    Path = ((Movie)treeView1.SelectedNode.Tag).FilePath
                };
                execute.Execute();
            }
            finally
            {

            }
        }

        private void intelligentTrackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            intelligentTrackerToolStripMenuItem.Checked = !intelligentTrackerToolStripMenuItem.Checked;
        }


        void Navigate(string url)
        {

            webBrowser1.Navigate(url);

        }

        private void MovieBrowserSimple_FormClosing(object sender, FormClosingEventArgs e)
        {

            Properties.Settings.Default.Paths = new StringCollection();

            foreach (TreeNode node in treeView1.Nodes)
            {
                Properties.Settings.Default.Paths.Add(((Movie)node.Tag).FilePath);
            }

            Properties.Settings.Default.Ignore = textIgnore.Text;

            Properties.Settings.Default.Save();

        }

        private void MovieBrowserSimple_Load(object sender, EventArgs e)
        {
            LoadAllFolders();
        }

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

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                textBox1.AppendText("Document Completed: " + webBrowser1.ReadyState + "\r\n");
                if (intelligentTrackerToolStripMenuItem.Checked)
                    Redirect(webBrowser1.DocumentText);
            }
            catch
            {
            }

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
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {

                ParseMovieInfo();
            }
            catch { }
        }

        private Movie ParseMovieInfo()
        {
            string src = webBrowser1.DocumentText;
            var rating = Regex.Match(src, @"<span class=""rating-rating"">([\d.]+)<span>").Groups[1].Value;
            var match = Regex.Match(src, @"<title>(.+?) \(.*?([\d.]+)\)");

            string imdbId = Regex.Match(webBrowser1.Url.AbsolutePath, @"/title/(tt\d+)/").Groups[1].Value;

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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            UpdateMovie();
        }

        private void UpdateMovie()
        {
            try
            {
                Movie filename = (Movie)treeView1.SelectedNode.Tag;

                string newdir = filename.FilePath.Substring(0, filename.FilePath.LastIndexOf("\\") + 1);

                Movie movie = ParseMovieInfo();
                //Directory.Move(filename, newdir);
                newdir += CleanedName(HttpHelper.Decode(String.Format("{0} ({1}), [{2}] [{3}]", movie.Title, movie.Year, movie.Rating, movie.ImdbId)));

                Directory.Move(filename.FilePath, newdir);

                //treeView1.SelectedNode.Tag = newdir;
                movie.FilePath = newdir;
                treeView1.SelectedNode.Text = ParseFolderName(newdir).Title + " " + movie.Rating;
                treeView1.SelectedNode.Tag = movie;
            }
            catch
            {
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Open();
        }

        private string CleanedName(string name)
        {
            return Regex.Replace(name, @"[\\/:*?""<>|]+", "");
        }

        private Movie ParseFolderName(string folderPath)
        {
            String folderName = "";
            int i = folderPath.LastIndexOf("\\");
            if (i > 0)
            {
                folderName = folderPath.Substring(i + 1);
            }

            var match = Regex.Match(folderName, @"(.+) \((\d+)\), \[([\d.]+)\]\s*(\[(tt\d+)\])?");
            if (match.Success)
            {
                return new Movie()
                           {
                               Title = match.Groups[1].Value,
                               Year = int.Parse(match.Groups[2].Value),
                               Rating = double.Parse(match.Groups[3].Value),
                               ImdbId = match.Groups[5].Value,
                               FilePath = folderPath
                           };
            }
            else
            {
                return new Movie() { Title = folderName, FilePath = folderPath };
            }
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
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

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.AppendText("Navigated to " + e.Url.AbsoluteUri + "\r\n");
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            LoadAllFolders();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMovie();
        }
    }
}
