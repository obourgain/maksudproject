using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CommonUtilities;
using HttpUtility;
using MovieBrowser.Model;
using ShellLib;

namespace MovieBrowser.Form
{
    public partial class MovieBrowserSimple : System.Windows.Forms.Form
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

            LoadPenDrives();
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
        private void TsSaveFoldersClick(object sender, EventArgs e)
        {
            SaveFolderList();
        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.TreeViewNodeSorter = new MovieComparer();

            treeView1.Sort();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadPenDrives();
        }


        private void sendToPendriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyToPendrive();
        }

        private void CopyToPendrive()
        {
            SendTo();
        }

        public void SendTo()
        {
            try
            {
                var movie = (Movie)treeView1.SelectedNode.Tag;
                var stt = new SendToThread()
                              {
                                  Source = movie.FilePath,
                                  Destination = Path.Combine(tsPendrives.SelectedItem.ToString(), movie.FolderName)
                              };
                var thread = new Thread(stt.SendTo);
                thread.Start();
            }
            catch
            {

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AddMovieToDb(ParseMovieInfo());
        }

        private void updateMovieDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMovieDataBaseFromFileSystem();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SearchMovie(ImdbSearch, (Movie)listView1.SelectedItems[0].Tag);
            }
            catch
            {

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
                FileHelper.CopyAllRecursive(new DirectoryInfo(Source), new DirectoryInfo(Destination), null);
                MessageBox.Show(@"Copied Successfully.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Problem Sending file.");
            }
        }

    }


}