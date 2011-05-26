using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BrightIdeasSoftware;
using CommonUtilities;
using CommonUtilities.Extensions;
using CommonUtilities.FileSystem;
using MovieBrowser.Controller;
using MovieBrowser.Model;
using System.Linq;


namespace MovieBrowser.Forms
{

    public partial class MovieBrowserSimple : Form
    {

        readonly MovieBrowserController _controller = new MovieBrowserController();

        public MovieBrowserSimple()
        {
            InitializeComponent();
            treeView1.TreeViewNodeSorter = new MovieComparer();

            _controller.Browser = webBrowser1;
            _controller.OnDebugTextFired += _controller_OnDebugTextFired;
            _controller.IntelligentSearch = intelligentTrackerToolStripMenuItem.Checked;
        }


        #region ThreadSafe Access
        void _controller_OnDebugTextFired(object sender, EventArgs e)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new EventHandler(_controller_OnDebugTextFired), sender, e);
            }
            else
            {
                textBox1.AppendText(((DebugEventArgs)e).Text);
            }
        }
        #endregion


        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            _controller.LoadFolderIntoTreeViewDialog(treeView1);
        }
        private void TsSearchImdbClick(object sender, EventArgs e)
        {
            TreeView1DoubleClick(sender, e);
        }
        private void TreeView1DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null) return;

            if (treeView1.SelectedNode.Nodes.Count == 0)
                _controller.Open(((Movie)treeView1.SelectedNode.Tag).FilePath);
            else
                _controller.SearchMovieTree(MovieBrowserController.ImdbSearch, (MovieNode)treeView1.SelectedNode);
        }
        private void SearchToolStripMenuItemClick(object sender, EventArgs e)
        {
            TsSearchImdbClick(sender, e);
        }
        private void GoogleToolStripMenuItemClick(object sender, EventArgs e)
        {
            TreeView1DoubleClick(sender, e);
        }
        private void TsSearchGoogleClick(object sender, EventArgs e)
        {
            GoogleToolStripMenuItemClick(sender, e);
        }
        private void TsDeleteClick(object sender, EventArgs e)
        {
            _controller.DeleteNode(treeView1);
        }
        private void TreeView1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TreeView1DoubleClick(sender, e);
            }
            else if (e.KeyCode == Keys.Space)
            {
                _controller.Open(((Movie)treeView1.SelectedNode.Tag).FilePath);
            }
        }
        private void IntelligentTrackerToolStripMenuItemClick(object sender, EventArgs e)
        {
            intelligentTrackerToolStripMenuItem.Checked = !intelligentTrackerToolStripMenuItem.Checked;
            _controller.IntelligentSearch = intelligentTrackerToolStripMenuItem.Checked;
        }
        private void MovieBrowserSimpleFormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.SaveFolderListTree(treeView1);
        }
        private void MovieBrowserSimpleLoad(object sender, EventArgs e)
        {
            textIgnore.Text = "" + Properties.Settings.Default.IgnoreWords;
            _controller.LoadAllFolders(treeView1);
            _controller.LoadPenDrives(tsPendrives);

            var entities = new MovieDbEntities();

            dataListView1.UseTranslucentHotItem = true;
            dataListView1.DataSource = entities.Movies.ToList();
        }
        private void WebBrowser1DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                textBox1.AppendText("Document Completed: " + webBrowser1.ReadyState + "\r\n");
                if (_controller.RecentSearch && _controller.IntelligentSearch)
                    _controller.Redirect(e.Url.AbsoluteUri, webBrowser1.DocumentText);
                else
                {
                    _controller.RecentSearch = false;
                }
            }
            catch (Exception)
            {
            }
        }
        private void ToolStripButton7Click(object sender, EventArgs e)
        {
            try
            {
                _controller.ParseMovieInfo(webBrowser1.DocumentText);
            }
            catch { }
        }
        private void ToolStripButton6Click(object sender, EventArgs e)
        {
            _controller.UpdateMovie();
        }
        private void TsOpenInExplorerClick(object sender, EventArgs e)
        {
            _controller.Open(((Movie)treeView1.SelectedNode.Tag).FilePath);
        }
        private void TsUpdateIgnoreListClick(object sender, EventArgs e)
        {
            textIgnore.Text = _controller.UpdateIgnoreWords();
        }
        private void WebBrowser1Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.AppendText("Navigated to " + e.Url.AbsoluteUri + "\r\n");
        }
        private void ToolStripButton9Click(object sender, EventArgs e)
        {
            _controller.LoadAllFolders(treeView1);
        }
        private void UpdateToolStripMenuItemClick(object sender, EventArgs e)
        {
            _controller.UpdateMovie();
        }
        private void TsSaveFoldersClick(object sender, EventArgs e)
        {
            _controller.SaveFolderListTree(treeView1);
        }
        private void SortToolStripMenuItemClick(object sender, EventArgs e)
        {
            treeView1.TreeViewNodeSorter = new MovieComparer();

            treeView1.Sort();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _controller.LoadPenDrives(tsPendrives);
        }
        private void SendToPendriveToolStripMenuItemClick(object sender, EventArgs e)
        {
            _controller.SendTo(treeView1, tsPendrives);
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var information = new CollectInformation { Html = webBrowser1.DocumentText, MovieController = _controller, MovieNode = null };
            var thread = new Thread(information.Collect);
            thread.Start();
        }
        private void UpdateMovieDatabaseToolStripMenuItemClick(object sender, EventArgs e)
        {
            _controller.UpdateMovieDataBaseFromFileSystem(treeView1);
        }
        private void ListView1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) DataListView1SelectedIndexChanged(sender, e);
        }

        private void updateMovieInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var movies = (from MovieNode node in treeView1.SelectedNode.Nodes select node.Movie).ToList();

            new UpdateMovieInformation(movies).Show();

        }



        void LoadImdbInfo(string imdbId)
        {
            var db = new MovieDbEntities();

            lblImdbId.Text = imdbId;

            var movie = db.Movies.Where(a => a.ImdbId == imdbId).FirstOrDefault();
            if (movie == null)
            {
                lblMovieTitle.Text = "";
                lblRating.Text = "";
                lblRuntime.Text = "";
                lblMPAA.Text = "";


                listCountries.Items.Clear();
                listKeywords.Items.Clear();
                listGenres.Items.Clear();


                return;
            }
            else
            {
                lblMovieTitle.Text = HttpHelper.HtmlDecode(movie.Title);
                lblRating.Text = movie.Rating + "";
                lblRuntime.Text = movie.Runtime + "";
                lblMPAA.Text = movie.MPPA;

                var listC = db.MovieCountries.Where(a => a.Movie.Id == movie.Id).Select(o => o.Country).ToList();
                listCountries.Items.Clear();
                foreach (var country in listC)
                {
                    var item = new ListViewItem(country.Name);
                    item.SubItems.Add(country.Code);
                    listCountries.Items.Add(item);
                }

                var listK = db.MovieKeywords.Where(a => a.Movie.Id == movie.Id).Select(o => o.Keyword).ToList();
                listKeywords.Items.Clear();
                foreach (var country in listK)
                {
                    var item = new ListViewItem(country.Name);
                    item.SubItems.Add(country.Code);
                    listKeywords.Items.Add(item);
                }

                var listG = db.MovieGenres.Where(a => a.Movie.Id == movie.Id).Select(o => o.Genre).ToList();
                listGenres.Items.Clear();
                foreach (var country in listG)
                {
                    var item = new ListViewItem(country.Name);
                    item.SubItems.Add(country.Code);
                    listGenres.Items.Add(item);
                }

            }
        }

        private void Button1Click(object sender, EventArgs e)
        {
            var information = new CollectInformation { MovieController = _controller, MovieNode = (MovieNode)treeView1.SelectedNode };
            var thread = new Thread(information.Collect);
            thread.Start();
        }

        private class CollectInformation
        {
            public MovieNode MovieNode { private get; set; }
            public MovieBrowserController MovieController { private get; set; }
            public string Html { get; set; }

            public void Collect()
            {
                try
                {
                    if (string.IsNullOrEmpty(Html))
                        Html = HttpHelper.FetchWebPage(MovieBrowserController.ImdbTitle + MovieNode.Movie.ImdbId);

                    var movie = MovieController.CollectAndAddMovieToDb(Html);
                    if (MovieNode != null && movie != null)
                    {
                        MovieNode.Tag = movie;
                        MovieController.UpdateMovie(movie);
                    }
                    MessageBox.Show(@"Finished...");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"Problem Collecting Information.\r\n{0}", exception.Message);
                }
            }

        }

        private void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode != null)
                LoadImdbInfo(((Movie)treeView1.SelectedNode.Tag).ImdbId);
        }

        private void DataListView1SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var movie = (Movie)(dataListView1.SelectedObject);
                LoadImdbInfo(movie.ImdbId);
            }
            catch { }
        }


        private void toolStripTextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _controller.SearchMovie(MovieBrowserController.ImdbSearch, new Movie() { Title = toolStripTextBoxSearch.Text });
            }
        }

        private void DataListView1DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var movie = (Movie)(dataListView1.SelectedObject);
                _controller.SearchMovie(MovieBrowserController.ImdbSearch, movie);
            }
            catch
            {
            }
        }

        private void DataListView1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                DataListView1DoubleClick(sender, e);
        }


        //
        private static void TimedFilter(DataListView olv, string txt, TextMatchFilter.MatchKind matchKind = TextMatchFilter.MatchKind.Text)
        {
            TextMatchFilter filter = null;
            if (!String.IsNullOrEmpty(txt))
                filter = new TextMatchFilter(olv, txt, matchKind);

            // Setup a default renderer to draw the filter matches
            olv.DefaultRenderer = filter == null ? null : new HighlightTextRenderer(filter);

            // Some lists have renderers already installed
            var highlightingRenderer = olv.GetColumn(0).Renderer as HighlightTextRenderer;
            if (highlightingRenderer != null)
                highlightingRenderer.Filter = filter;

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            olv.ModelFilter = filter;
            stopWatch.Stop();
        }

        private void TextBox2TextChanged(object sender, EventArgs e)
        {
            TimedFilter(dataListView1, textSearch.Text);
        }

      
    }

    public class SendToThread
    {

        public string Source { get; set; }
        public string Destination { get; set; }


        public void SendTo()
        {
            try
            {
                FileHelper.CopyAllRecursive(new DirectoryInfo(Source), new DirectoryInfo(Destination));
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Problem Sending file.\r\n{0}", exception.Message);
            }
        }

    }


}