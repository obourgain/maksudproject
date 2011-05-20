using System;
using System.IO;
using System.Windows.Forms;
using CommonUtilities;
using MovieBrowser.Controller;
using MovieBrowser.Model;

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
            _controller.MovieFolderTree = treeView1;
            _controller.TextBox1 = textBox1;
            _controller.TextIgnore = textIgnore;
            _controller.ListView1 = listView1;
        }




        //Events
        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            _controller.LoadFolderDialog();
        }
        private void tsSearchImdbClicl(object sender, EventArgs e)
        {
            TreeView1DoubleClick(sender, e);
        }
        private void TreeView1DoubleClick(object sender, EventArgs e)
        {
            try { _controller.SearchMovie(MovieBrowserController.ImdbSearch, (Movie)treeView1.SelectedNode.Tag); }
            catch { }
        }
        private void SearchToolStripMenuItemClick(object sender, EventArgs e)
        {
            tsSearchImdbClicl(sender, e);
        }
        private void GoogleToolStripMenuItemClick(object sender, EventArgs e)
        {
            try { _controller.SearchMovie(MovieBrowserController.GoogleSearch, (Movie)treeView1.SelectedNode.Tag); }
            catch { }
        }
        private void tsSearchGoogleClick(object sender, EventArgs e)
        {
            GoogleToolStripMenuItemClick(sender, e);
        }
        private void tsDeleteClick(object sender, EventArgs e)
        {
            _controller.DeleteNode();
        }
        private void TreeView1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (treeView1.SelectedNode.Nodes.Count == 0)
                    _controller.Open();
                else
                {
                    _controller.SearchMovie(MovieBrowserController.ImdbSearch, (Movie)treeView1.SelectedNode.Nodes[0].Tag);
                }

            }
            else if (e.KeyCode == Keys.Space)
            {
                _controller.Open();
            }
        }



        private void IntelligentTrackerToolStripMenuItemClick(object sender, EventArgs e)
        {
            intelligentTrackerToolStripMenuItem.Checked = !intelligentTrackerToolStripMenuItem.Checked;
        }
        private void MovieBrowserSimpleFormClosing(object sender, FormClosingEventArgs e)
        {

            _controller.SaveFolderList();

        }
        private void MovieBrowserSimpleLoad(object sender, EventArgs e)
        {
            _controller.LoadAllFolders();

            _controller.LoadPenDrives(tsPendrives);
        }



        private void WebBrowser1DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                textBox1.AppendText("Document Completed: " + webBrowser1.ReadyState + "\r\n");
                if (intelligentTrackerToolStripMenuItem.Checked)
                    _controller.Redirect(webBrowser1.DocumentText);
            }
            catch (Exception)
            {
            }

        }
        private void ToolStripButton7Click(object sender, EventArgs e)
        {
            try
            {

                _controller.ParseMovieInfo();
            }
            catch { }
        }
        private void ToolStripButton6Click(object sender, EventArgs e)
        {
            _controller.UpdateMovie();
        }
        private void TsOpenInExplorerClick(object sender, EventArgs e)
        {
            _controller.Open();
        }
        private void TsUpdateIgnoreListClick(object sender, EventArgs e)
        {
            _controller.SaveIgnoreList();
        }
        private void WebBrowser1Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.AppendText("Navigated to " + e.Url.AbsoluteUri + "\r\n");
        }
        private void ToolStripButton9Click(object sender, EventArgs e)
        {
            _controller.LoadAllFolders();
        }
        private void UpdateToolStripMenuItemClick(object sender, EventArgs e)
        {
            _controller.UpdateMovie();
        }
        private void TsSaveFoldersClick(object sender, EventArgs e)
        {
            _controller.SaveFolderList();
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
            _controller.AddMovieToDb(_controller.ParseMovieInfo());
        }

        private void UpdateMovieDatabaseToolStripMenuItemClick(object sender, EventArgs e)
        {
            _controller.UpdateMovieDataBaseFromFileSystem();
        }

        private void ListView1DoubleClick(object sender, EventArgs e)
        {
            try { _controller.SearchMovie(MovieBrowserController.ImdbSearch, (Movie)listView1.SelectedItems[0].Tag); }
            catch { }
        }

        private void ListView1KeyDown(object sender, KeyEventArgs e)
        {
            try { _controller.SearchMovie(MovieBrowserController.ImdbSearch, (Movie)listView1.SelectedItems[0].Tag); }
            catch { }
        }

    }

    public class SendToThread
    {

        public string Source { get; set; }
        public string Destination { get; set; }
        public CopyDialog Dialog { get; set; }

        public void SendTo()
        {
            try
            {
                FileHelper.CopyAllRecursive(new DirectoryInfo(Source), new DirectoryInfo(Destination), Dialog);
                MessageBox.Show(@"Copied Successfully.");
                Dialog.SetPropertyThreadSafe(() => Dialog.Visible, false);
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Problem Sending file.\r\n{0}", exception.Message);
            }
        }

    }


}