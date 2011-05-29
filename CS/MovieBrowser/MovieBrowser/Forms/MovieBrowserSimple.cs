using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using BrightIdeasSoftware;
using CommonUtilities;
using CommonUtilities.FileSystem;
using MovieBrowser.Controller;
using MovieBrowser.Model;
using System.Linq;
using FolderBrowserDialog = VistaUIApi.Dialog.FolderBrowserDialog;


namespace MovieBrowser.Forms
{

    public partial class MovieBrowserSimple : Form
    {
        private User _loggedInUser = null;
        private Movie _movie = null;
        readonly MovieBrowserController _controller = new MovieBrowserController();

        public MovieBrowserSimple()
        {
            InitializeComponent();
            //treeView1.TreeViewNodeSorter = new MovieComparer();

            _controller.Browser = webBrowser1;
            _controller.OnDebugTextFired += _controller_OnDebugTextFired;
            _controller.OnNotificationFired += DesktopNotify;
            _controller.IntelligentSearch = intelligentTrackerToolStripMenuItem.Checked;

            InitializeTree();

        }

        private bool IsAuthorized
        {
            get
            {


                return _loggedInUser != null;
            }
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
                textBox1.AppendText(((TextEventArgs)e).Text);
            }
        }

        void DesktopNotify(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = ((TextEventArgs)e).Title;
            notifyIcon1.BalloonTipText = ((TextEventArgs)e).Text;
            notifyIcon1.ShowBalloonTip(200);
        }
        #endregion


        private void ToolStripButton1Click(object sender, EventArgs e)
        {





        }
        private void TsSearchImdbClick(object sender, EventArgs e)
        {
            TreeView1DoubleClick(sender, e);
        }
        private void TreeView1DoubleClick(object sender, EventArgs e)
        {

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
            //_controller.DeleteNode(treeView1);
        }
        private void TreeView1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TreeView1DoubleClick(sender, e);
            }
            else if (e.KeyCode == Keys.Space)
            {
                //_controller.Open(((Movie)treeView1.SelectedNode.Tag).FilePath);
            }
        }
        private void IntelligentTrackerToolStripMenuItemClick(object sender, EventArgs e)
        {
            intelligentTrackerToolStripMenuItem.Checked = !intelligentTrackerToolStripMenuItem.Checked;
            _controller.IntelligentSearch = intelligentTrackerToolStripMenuItem.Checked;
        }
        private void MovieBrowserSimpleFormClosing(object sender, FormClosingEventArgs e)
        {
            //_controller.SaveFolderListTree(treeView1);
        }
        private void MovieBrowserSimpleLoad(object sender, EventArgs e)
        {

            Login();

            _controller.LoadPenDrives(comboPendrives);

            dataListView1.UseTranslucentHotItem = true;
            dataListView1.DataSource = _controller.MoviesList;

            var paths = (from object a in Properties.Settings.Default.Paths select (string)a).ToList();
            LoadTree(paths);
        }

        private void Login()
        {
            if (_loggedInUser == null)
            {
                var form = new LoginForm();
                form.LoggedIn += (sender, args) =>
                {
                    var textEventArgs = (TextEventArgs)args;
                    if (textEventArgs.Data != null)
                        _loggedInUser = (User)textEventArgs.Data;
                };
                form.ShowDialog(this);
            }
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

        }
        private void TsOpenInExplorerClick(object sender, EventArgs e)
        {
            //
        }
        private void TsUpdateIgnoreListClick(object sender, EventArgs e)
        {


        }
        private void WebBrowser1Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.AppendText("Navigated to " + e.Url.AbsoluteUri + "\r\n");
        }
        private void ToolStripButton9Click(object sender, EventArgs e)
        {
            //_controller.LoadAllFolders(treeView1);
        }
        private void UpdateToolStripMenuItemClick(object sender, EventArgs e)
        {
            _controller.UpdateMovie();
        }
        private void TsSaveFoldersClick(object sender, EventArgs e)
        {
            //  _controller.SaveFolderListTree(treeView1);
        }
        private void SortToolStripMenuItemClick(object sender, EventArgs e)
        {
            // treeView1.TreeViewNodeSorter = new MovieComparer();

            //  treeView1.Sort();
        }

        private void SendToPendriveToolStripMenuItemClick(object sender, EventArgs e)
        {
            //_controller.SendTo(treeView1, tsPendrives);
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var information = new CollectInformation { Html = webBrowser1.DocumentText, MovieController = _controller, MovieNode = null };
            var thread = new Thread(information.Collect);
            thread.Start();
        }
        private void UpdateMovieDatabaseToolStripMenuItemClick(object sender, EventArgs e)
        {
            //_controller.UpdateMovieDataBaseFromFileSystem(treeView1);
        }
        private void ListView1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) DataListView1SelectedIndexChanged(sender, e);
        }

        private void updateMovieInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var movies = ((Movie)treeView1.SelectedObject).Children;
            new UpdateMovieInformation(movies).Show();
        }


        void InitializeTree()
        {
            this.treeView1.CanExpandGetter = delegate(object x)
            {
                return ((Movie)x).IsFolder;
            };

            this.treeView1.ChildrenGetter = delegate(object x)
            {
                var movie = (Movie)x;
                try
                {
                    var dir = new DirectoryInfo(movie.FilePath);

                    var members = dir.GetFileSystemInfos();

                    return movie.Children = members.Select(fileSystemInfo => Movie.FromFolderName(fileSystemInfo.FullName)).ToList();
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(this, ex.Message, "ObjectListViewDemo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return new ArrayList();
                }
            };


            // Show the size of files as GB, MB and KBs. Also, group them by
            // some meaningless divisions
            this.treeColumnSize.AspectGetter = delegate(object x)
            {
                var m = (Movie)x;

                if (!m.IsFolder)
                {

                    try
                    {
                        var fileInfo = new FileInfo(((Movie)x).FilePath);

                        return fileInfo.Length;
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        // Mono 1.2.6 throws this for hidden files
                        return (long)-2;
                    }
                }
                else
                {
                    return (long)-2;
                }
            };

            // Draw the system icon next to the name
            //var helper = new SysImageListHelper(this.treeListView1);
            this.treeColumnTitle.ImageGetter = delegate(object x)
            {
                return ((Movie)x).ImageIndex;
            };



            this.treeColumnSize.AspectToStringConverter = delegate(object x)
            {
                if ((long)x < 0) // folder
                    return "";
                else
                    return FormatFileSize((long)x);
            };

            this.treeColumnYear.AspectToStringConverter = delegate(object x)
            {
                if (x + "" == "0") // folder
                    return "";
                else
                    return x + "";
            };

            this.treeColumnRating.AspectToStringConverter = delegate(object x)
            {
                if (x + "" == "0") // folder
                    return "";
                else
                    return x + "";
            };

            // Show the system description for this object
            this.treeColumnFileType.AspectGetter = delegate(object x)
            {
                return ShellUtilities.GetFileType(((Movie)x).FilePath);
            };
        }

        private void LoadTree(IEnumerable<string> paths)
        {
            var roots = new ArrayList();
            foreach (var root in paths)
            {
                var movie = Movie.FromFolderName(root);
                roots.Add(movie);
            }
            treeView1.Roots = roots;
        }

        static string FormatFileSize(long size)
        {
            var limits = new int[] { 1024 * 1024 * 1024, 1024 * 1024, 1024 };
            var units = new string[] { "GB", "MB", "KB" };

            for (var i = 0; i < limits.Length; i++)
            {
                if (size >= limits[i])
                    return String.Format("{0:#,##0.##} " + units[i], ((double)size / limits[i]));
            }

            return String.Format("{0} bytes", size); ;
        }

        void LoadImdbInfo(Movie rowMovie)
        {
            _movie = rowMovie;

            var db = new MovieDbEntities();

            lblImdbId.Text = rowMovie.ImdbId;

            var movie = db.Movies.Where(a => a.ImdbId == rowMovie.ImdbId).FirstOrDefault();
            if (movie == null)
            {

                listCountries.Items.Clear();
                listKeywords.Items.Clear();
                listGenres.Items.Clear();

                if (rowMovie.IsValidMovie)
                {
                    lblTitle.Text = rowMovie.Title;
                    lblRating.Text = rowMovie.Rating + "";
                    lblYear.Text = rowMovie.Year + "";
                }
                else
                {
                    lblTitle.Text = "";
                    lblRating.Text = "";
                    lblYear.Text = "";
                }

                lblRuntime.Text = "";
                lblMPAA.Text = "";
                textMpaaReason.Text = "";
                textHighlight.Text = "";

                return;
            }
            else
            {
                lblTitle.Text = movie.Title;
                lblRating.Text = movie.Rating + "";
                lblYear.Text = movie.Year + "";

                lblRuntime.Text = movie.Runtime;
                lblMPAA.Text = movie.MPAA;
                textMpaaReason.Text = movie.MPAAReason;
                textHighlight.Text = movie.Highlight;


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

            if (IsAuthorized)
            {
                var personalNote =
                    db.MoviePersonalNotes.Where(o => o.User.Id == _loggedInUser.Id && o.Movie.ImdbId == rowMovie.ImdbId).FirstOrDefault();

                LoadPersonalNote(personalNote);
            }
            else
            {
                LoadPersonalNote(null);
            }
        }


        void LoadPersonalNote(MoviePersonalNote note)
        {
            if (note == null)
            {
                rsUserRating.Rating = 0;

                pbDislike.Image = Properties.Resources.hate_it_dis;
                pbHaveIt.Image = Properties.Resources.have_it_dis;
                pbLike.Image = Properties.Resources.like_it_dis;
                pbSeenIt.Image = Properties.Resources.seen_it_dis;
                pbWanted.Image = Properties.Resources.check_list_dis;
            }
            else
            {
                rsUserRating.Rating = note.Rating;

                pbDislike.Image = note.Favourite < 0 ? Properties.Resources.hate_it : Properties.Resources.hate_it_dis;
                pbLike.Image = note.Favourite > 0 ? Properties.Resources.like_it : Properties.Resources.like_it_dis;
                pbHaveIt.Image = note.Have ? Properties.Resources.have_it : Properties.Resources.have_it_dis;
                pbSeenIt.Image = note.Seen ? Properties.Resources.seen_it : Properties.Resources.seen_it_dis;
                pbWanted.Image = note.Wishlist ? Properties.Resources.check_list : Properties.Resources.check_list_dis;
            }

        }


        private class CollectInformation
        {
            public OLVListItem MovieNode { private get; set; }
            public MovieBrowserController MovieController { private get; set; }
            public string Html { get; set; }

            public void Collect()
            {
                try
                {
                    var movie2 = (Movie)MovieNode.RowObject;

                    var movie = MovieController.CollectAndAddMovieToDb(movie2);
                    if (MovieNode != null && movie != null)
                    {
                        MovieController.UpdateMovie(MovieNode);
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"Problem Collecting Information.", exception.Message);
                }
            }

        }


        private void DataListView1SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var movie = (Movie)(dataListView1.SelectedObject);
                LoadImdbInfo(movie);
            }
            catch { }
        }


        private void toolStripTextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //_controller.SearchMovie(MovieBrowserController.ImdbSearch, new Movie() { Title = toolStripTextBoxSearch.Text });
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


        private void buttonClean_Click(object sender, EventArgs e)
        {
            _controller.RemoveMovie(lblImdbId.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.RemoveAllInfo();
        }

        private void searchTextBox1_SearchStarted(object sender, EventArgs e)
        {
            TimedFilter(this.treeView1, searchTextBox1.Text);
        }

        private void searchTextBox1_SearchCancelled(object sender, EventArgs e)
        {
            TimedFilter(this.treeView1, "");
        }

        private void searchTextBox2_SearchStarted(object sender, EventArgs e)
        {
            TimedFilter(this.dataListView1, searchTextBox2.Text);
        }

        private void searchTextBox2_SearchCancelled(object sender, EventArgs e)
        {
            TimedFilter(this.dataListView1, "");
        }


        private static void TimedFilter(ObjectListView olv, string txt, TextMatchFilter.MatchKind matchKind = TextMatchFilter.MatchKind.Text)
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

            olv.ModelFilter = filter;
        }

        private void treeListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (treeView1.SelectedObject != null)
                LoadImdbInfo((Movie)treeView1.SelectedObject);
        }

        /****************************************************************/
        private void tbBrowseFolders_Click(object sender, EventArgs e)
        {
            VistaUIApi.Dialog.FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                //    _controller.LoadFolderIntoTreeViewDialog(treeView1);
            }
        }

        private void tbSaveFolders_Click(object sender, EventArgs e)
        {

        }

        private void tbLoadPendrives_Click(object sender, EventArgs e)
        {
            _controller.LoadPenDrives(comboPendrives);
        }

        private void tbOpenExplorer_Click(object sender, EventArgs e)
        {
            _controller.Open(((Movie)treeView1.SelectedObject).FilePath);
        }

        private void tbSearchImdb_Click(object sender, EventArgs e)
        {
            _controller.SearchMovie(Controller.MovieBrowserController.ImdbSearch, (Movie)treeView1.SelectedObject);
        }

        private void tbIgnoreList_Click(object sender, EventArgs e)
        {
            var form = new IgnoreListForm();
            form.ShowDialog(this);
        }

        private void tbUpdateFolder_Click(object sender, EventArgs e)
        {
            _controller.UpdateMovie((OLVListItem)treeView1.SelectedItem);
        }

        private void tbAddToDb_Click(object sender, EventArgs e)
        {
            CollectAndUpdate();
        }

        private void CollectAndUpdate()
        {
            var information = new CollectInformation { MovieController = _controller, MovieNode = (OLVListItem)treeView1.SelectedItem };
            var thread = new Thread(information.Collect);
            thread.Start();
        }

        private void rsUserRating_RatingValueChanged(object sender, RatingControl.RatingChangedEventArgs e)
        {
            if (IsAuthorized)
                _controller.UpdateUserRating(_loggedInUser, _movie, rsUserRating.Rating);
            else
            {
                rsUserRating.Rating = 0;
            }
        }

        private void pbWanted_Click(object sender, EventArgs e)
        {
            if (IsAuthorized)
            {
                LoadPersonalNote(_controller.ToggleWanted(_loggedInUser, _movie));
            }
        }

        private void tbRemoveFolders_Click(object sender, EventArgs e)
        {

        }

        private void tbRefreshFolders_Click(object sender, EventArgs e)
        {

        }

        private void tbSearchGoogle_Click(object sender, EventArgs e)
        {

        }

        private void treeListView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedObject == null) return;

            var movie = (Movie)treeView1.SelectedObject;

            if (movie.IsValidMovie || movie.IsFolder)
                _controller.SearchMovieTree(MovieBrowserController.ImdbSearch, (OLVListItem)treeView1.SelectedItem);
            else
                _controller.Open(movie.FilePath);
        }

        private void refreshFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> strs = (from object root in treeView1.Roots select ((Movie)root).FilePath).ToList();
            LoadTree(strs);
        }

        private void buttonCollect_Click(object sender, EventArgs e)
        {
            CollectAndUpdate();
        }

        private void pbLike_Click(object sender, EventArgs e)
        {
            if (IsAuthorized)
            {
                LoadPersonalNote(_controller.SetFavourite(_loggedInUser, _movie, true));
            }
        }

        private void pbSeenIt_Click(object sender, EventArgs e)
        {
            if (IsAuthorized)
            {
                LoadPersonalNote(_controller.ToggleSeenIt(_loggedInUser, _movie));
            }
        }

        private void pbHaveIt_Click(object sender, EventArgs e)
        {
            if (IsAuthorized)
            {
                LoadPersonalNote(_controller.ToggleHaveIt(_loggedInUser, _movie));
            }
        }

        private void pbDislike_Click(object sender, EventArgs e)
        {
            if (IsAuthorized)
            {
                LoadPersonalNote(_controller.SetFavourite(_loggedInUser, _movie, false));
            }
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