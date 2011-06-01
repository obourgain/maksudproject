using System;
using BrightIdeasSoftware;

namespace MovieBrowser.Forms
{
    partial class MovieBrowserSimple
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieBrowserSimple));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabMovies = new System.Windows.Forms.TabControl();
            this.tpMoviesTree = new System.Windows.Forms.TabPage();
            this.treeView1 = new BrightIdeasSoftware.TreeListView();
            this.treeColumnTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.treeColumnRating = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.treeColumnYear = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.treeColumnSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.treeColumnFileType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToPendriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.updateMovieInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchTextBox1 = new WindowsFormsAero.SearchTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tbBrowseFolders = new System.Windows.Forms.ToolStripButton();
            this.tbRemoveFolders = new System.Windows.Forms.ToolStripButton();
            this.tbRefreshFolders = new System.Windows.Forms.ToolStripButton();
            this.tbSaveFolders = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.pbUpdateTree = new System.Windows.Forms.ToolStripButton();
            this.pbAddTreeItemToDb = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbSearchImdb = new System.Windows.Forms.ToolStripButton();
            this.tbSearchGoogle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbOpenExplorer = new System.Windows.Forms.ToolStripButton();
            this.tbIgnoreList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.comboPendrives = new System.Windows.Forms.ToolStripComboBox();
            this.tbLoadPendrives = new System.Windows.Forms.ToolStripButton();
            this.tbSendTo = new System.Windows.Forms.ToolStripButton();
            this.tpMovies2 = new System.Windows.Forms.TabPage();
            this.dataListView1 = new BrightIdeasSoftware.DataListView();
            this.olvTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvImdbId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvRating = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvYear = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchTextBox2 = new WindowsFormsAero.SearchTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbAddToDb = new System.Windows.Forms.ToolStripButton();
            this.tbRefreshDb = new System.Windows.Forms.ToolStripButton();
            this.tbDeleteFromDb = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.tabInformation = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tpInformation = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonClean = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listGenres = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listCountries = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listKeywords = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.horizontalPanel1 = new WindowsFormsAero.HorizontalPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.textHighlight = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRuntime = new System.Windows.Forms.TextBox();
            this.horizontalPanel2 = new WindowsFormsAero.HorizontalPanel();
            this.buttonModifyList = new System.Windows.Forms.Button();
            this.buttonAddToList = new System.Windows.Forms.Button();
            this.comboBox1 = new WindowsFormsAero.ComboBox();
            this.pbHaveIt = new System.Windows.Forms.PictureBox();
            this.pbSeenIt = new System.Windows.Forms.PictureBox();
            this.pbDislike = new System.Windows.Forms.PictureBox();
            this.lblImdbId = new System.Windows.Forms.Label();
            this.pbLike = new System.Windows.Forms.PictureBox();
            this.pbWanted = new System.Windows.Forms.PictureBox();
            this.rsUserRating = new RatingControl.RatingStar();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMPAA = new System.Windows.Forms.TextBox();
            this.textMpaaReason = new System.Windows.Forms.TextBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateMovieDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intelligentTrackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tbWantToWatch = new System.Windows.Forms.ToolStripButton();
            this.tbLikeIt = new System.Windows.Forms.ToolStripButton();
            this.tbDislikeIt = new System.Windows.Forms.ToolStripButton();
            this.tbSeenIt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbHaveIt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtUserRating = new System.Windows.Forms.ToolStripTextBox();
            this.tbRateIt = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabMovies.SuspendLayout();
            this.tpMoviesTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tpMovies2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.tabInformation.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpInformation.SuspendLayout();
            this.horizontalPanel1.SuspendLayout();
            this.horizontalPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHaveIt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeenIt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDislike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWanted)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.horizontalPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1247, 422);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1247, 447);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabMovies);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStripContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1247, 322);
            this.splitContainer1.SplitterDistance = 509;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabMovies
            // 
            this.tabMovies.Controls.Add(this.tpMoviesTree);
            this.tabMovies.Controls.Add(this.tpMovies2);
            this.tabMovies.Controls.Add(this.tabPage3);
            this.tabMovies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMovies.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMovies.Location = new System.Drawing.Point(0, 0);
            this.tabMovies.Name = "tabMovies";
            this.tabMovies.SelectedIndex = 0;
            this.tabMovies.Size = new System.Drawing.Size(509, 322);
            this.tabMovies.TabIndex = 1;
            // 
            // tpMoviesTree
            // 
            this.tpMoviesTree.Controls.Add(this.treeView1);
            this.tpMoviesTree.Controls.Add(this.panel2);
            this.tpMoviesTree.Location = new System.Drawing.Point(4, 26);
            this.tpMoviesTree.Name = "tpMoviesTree";
            this.tpMoviesTree.Padding = new System.Windows.Forms.Padding(3);
            this.tpMoviesTree.Size = new System.Drawing.Size(501, 292);
            this.tpMoviesTree.TabIndex = 3;
            this.tpMoviesTree.Text = "Movies Folders";
            this.tpMoviesTree.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.AllColumns.Add(this.treeColumnTitle);
            this.treeView1.AllColumns.Add(this.treeColumnRating);
            this.treeView1.AllColumns.Add(this.treeColumnYear);
            this.treeView1.AllColumns.Add(this.treeColumnSize);
            this.treeView1.AllColumns.Add(this.treeColumnFileType);
            this.treeView1.AllowColumnReorder = true;
            this.treeView1.CheckBoxes = true;
            this.treeView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.treeColumnTitle,
            this.treeColumnRating,
            this.treeColumnYear,
            this.treeColumnSize,
            this.treeColumnFileType});
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.EmptyListMsg = "Please add folder!";
            this.treeView1.FullRowSelect = true;
            this.treeView1.GridLines = true;
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(3, 55);
            this.treeView1.Name = "treeView1";
            this.treeView1.OwnerDraw = true;
            this.treeView1.ShowGroups = false;
            this.treeView1.ShowImagesOnSubItems = true;
            this.treeView1.ShowItemToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(495, 234);
            this.treeView1.SmallImageList = this.imageList1;
            this.treeView1.TabIndex = 1;
            this.treeView1.UseCompatibleStateImageBehavior = false;
            this.treeView1.UseFiltering = true;
            this.treeView1.View = System.Windows.Forms.View.Details;
            this.treeView1.VirtualMode = true;
            this.treeView1.SelectedIndexChanged += new System.EventHandler(this.treeListView1_SelectedIndexChanged);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeListView1_DoubleClick);
            // 
            // treeColumnTitle
            // 
            this.treeColumnTitle.AspectName = "Title";
            this.treeColumnTitle.Text = "Title";
            this.treeColumnTitle.Width = 300;
            // 
            // treeColumnRating
            // 
            this.treeColumnRating.AspectName = "Rating";
            this.treeColumnRating.Text = "Rating";
            // 
            // treeColumnYear
            // 
            this.treeColumnYear.AspectName = "Year";
            this.treeColumnYear.Text = "Year";
            // 
            // treeColumnSize
            // 
            this.treeColumnSize.Text = "Size";
            // 
            // treeColumnFileType
            // 
            this.treeColumnFileType.Text = "File Type";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToPendriveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.updateMovieInformationToolStripMenuItem,
            this.refreshFolderToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 76);
            // 
            // sendToPendriveToolStripMenuItem
            // 
            this.sendToPendriveToolStripMenuItem.Name = "sendToPendriveToolStripMenuItem";
            this.sendToPendriveToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.sendToPendriveToolStripMenuItem.Text = "Send To Pendrive";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 6);
            // 
            // updateMovieInformationToolStripMenuItem
            // 
            this.updateMovieInformationToolStripMenuItem.Name = "updateMovieInformationToolStripMenuItem";
            this.updateMovieInformationToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.updateMovieInformationToolStripMenuItem.Text = "Update Movie Information";
            this.updateMovieInformationToolStripMenuItem.Click += new System.EventHandler(this.updateMovieInformationToolStripMenuItem_Click);
            // 
            // refreshFolderToolStripMenuItem
            // 
            this.refreshFolderToolStripMenuItem.Name = "refreshFolderToolStripMenuItem";
            this.refreshFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.refreshFolderToolStripMenuItem.Text = "Refresh Folder";
            this.refreshFolderToolStripMenuItem.Click += new System.EventHandler(this.refreshFolderToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "movie.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "movie_file.png");
            this.imageList1.Images.SetKeyName(3, "subtitle.png");
            this.imageList1.Images.SetKeyName(4, "file.png");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.searchTextBox1);
            this.panel2.Controls.Add(this.toolStrip2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 52);
            this.panel2.TabIndex = 0;
            // 
            // searchTextBox1
            // 
            this.searchTextBox1.ActiveFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.searchTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchTextBox1.Location = new System.Drawing.Point(0, 25);
            this.searchTextBox1.Name = "searchTextBox1";
            this.searchTextBox1.Size = new System.Drawing.Size(495, 24);
            this.searchTextBox1.TabIndex = 7;
            this.searchTextBox1.SearchStarted += new System.EventHandler(this.searchTextBox1_SearchStarted);
            this.searchTextBox1.SearchCancelled += new System.EventHandler(this.searchTextBox1_SearchCancelled);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbBrowseFolders,
            this.tbRemoveFolders,
            this.tbRefreshFolders,
            this.tbSaveFolders,
            this.toolStripSeparator6,
            this.pbUpdateTree,
            this.pbAddTreeItemToDb,
            this.toolStripSeparator5,
            this.tbSearchImdb,
            this.tbSearchGoogle,
            this.toolStripSeparator4,
            this.tbOpenExplorer,
            this.tbIgnoreList,
            this.toolStripSeparator7,
            this.comboPendrives,
            this.tbLoadPendrives,
            this.tbSendTo});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip2.Size = new System.Drawing.Size(495, 25);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tbBrowseFolders
            // 
            this.tbBrowseFolders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBrowseFolders.Image = global::MovieBrowser.Properties.Resources.folder_add;
            this.tbBrowseFolders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBrowseFolders.Name = "tbBrowseFolders";
            this.tbBrowseFolders.Size = new System.Drawing.Size(23, 22);
            this.tbBrowseFolders.Text = "Browse";
            this.tbBrowseFolders.Click += new System.EventHandler(this.tbBrowseFolders_Click);
            // 
            // tbRemoveFolders
            // 
            this.tbRemoveFolders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRemoveFolders.Image = global::MovieBrowser.Properties.Resources.delete;
            this.tbRemoveFolders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRemoveFolders.Name = "tbRemoveFolders";
            this.tbRemoveFolders.Size = new System.Drawing.Size(23, 22);
            this.tbRemoveFolders.Text = "Remove Selected Folder";
            this.tbRemoveFolders.Click += new System.EventHandler(this.tbRemoveFolders_Click);
            // 
            // tbRefreshFolders
            // 
            this.tbRefreshFolders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRefreshFolders.Image = global::MovieBrowser.Properties.Resources.refresh;
            this.tbRefreshFolders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRefreshFolders.Name = "tbRefreshFolders";
            this.tbRefreshFolders.Size = new System.Drawing.Size(23, 22);
            this.tbRefreshFolders.Text = "Refresh Folders";
            this.tbRefreshFolders.Click += new System.EventHandler(this.tbRefreshFolders_Click);
            // 
            // tbSaveFolders
            // 
            this.tbSaveFolders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSaveFolders.Image = global::MovieBrowser.Properties.Resources.save;
            this.tbSaveFolders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSaveFolders.Name = "tbSaveFolders";
            this.tbSaveFolders.Size = new System.Drawing.Size(23, 22);
            this.tbSaveFolders.Text = "Save";
            this.tbSaveFolders.Click += new System.EventHandler(this.tbSaveFolders_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // pbUpdateTree
            // 
            this.pbUpdateTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pbUpdateTree.Image = global::MovieBrowser.Properties.Resources.pb_update;
            this.pbUpdateTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pbUpdateTree.Name = "pbUpdateTree";
            this.pbUpdateTree.Size = new System.Drawing.Size(23, 22);
            this.pbUpdateTree.Text = "Update";
            this.pbUpdateTree.Click += new System.EventHandler(this.pbUpdateTree_Click);
            // 
            // pbAddTreeItemToDb
            // 
            this.pbAddTreeItemToDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pbAddTreeItemToDb.Image = global::MovieBrowser.Properties.Resources.pb_movie;
            this.pbAddTreeItemToDb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pbAddTreeItemToDb.Name = "pbAddTreeItemToDb";
            this.pbAddTreeItemToDb.Size = new System.Drawing.Size(23, 22);
            this.pbAddTreeItemToDb.Text = "toolStripButton3";
            this.pbAddTreeItemToDb.Click += new System.EventHandler(this.pbAddTreeItemToDb_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tbSearchImdb
            // 
            this.tbSearchImdb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSearchImdb.Image = global::MovieBrowser.Properties.Resources.imdb;
            this.tbSearchImdb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSearchImdb.Name = "tbSearchImdb";
            this.tbSearchImdb.Size = new System.Drawing.Size(23, 22);
            this.tbSearchImdb.Text = "Imdb Search";
            this.tbSearchImdb.Click += new System.EventHandler(this.tbSearchImdb_Click);
            // 
            // tbSearchGoogle
            // 
            this.tbSearchGoogle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSearchGoogle.Image = global::MovieBrowser.Properties.Resources.google;
            this.tbSearchGoogle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSearchGoogle.Name = "tbSearchGoogle";
            this.tbSearchGoogle.Size = new System.Drawing.Size(23, 22);
            this.tbSearchGoogle.Text = "Search Google";
            this.tbSearchGoogle.Click += new System.EventHandler(this.tbSearchGoogle_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tbOpenExplorer
            // 
            this.tbOpenExplorer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOpenExplorer.Image = global::MovieBrowser.Properties.Resources.explorer;
            this.tbOpenExplorer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOpenExplorer.Name = "tbOpenExplorer";
            this.tbOpenExplorer.Size = new System.Drawing.Size(23, 22);
            this.tbOpenExplorer.Text = "Open in Explorer";
            this.tbOpenExplorer.Click += new System.EventHandler(this.tbOpenExplorer_Click);
            // 
            // tbIgnoreList
            // 
            this.tbIgnoreList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbIgnoreList.Image = global::MovieBrowser.Properties.Resources.ignore_list;
            this.tbIgnoreList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbIgnoreList.Name = "tbIgnoreList";
            this.tbIgnoreList.Size = new System.Drawing.Size(23, 22);
            this.tbIgnoreList.Text = "Ignore List";
            this.tbIgnoreList.Click += new System.EventHandler(this.tbIgnoreList_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // comboPendrives
            // 
            this.comboPendrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPendrives.Name = "comboPendrives";
            this.comboPendrives.Size = new System.Drawing.Size(75, 25);
            // 
            // tbLoadPendrives
            // 
            this.tbLoadPendrives.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbLoadPendrives.Image = global::MovieBrowser.Properties.Resources.pen_drives;
            this.tbLoadPendrives.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbLoadPendrives.Name = "tbLoadPendrives";
            this.tbLoadPendrives.Size = new System.Drawing.Size(23, 22);
            this.tbLoadPendrives.Text = "Load Pen Drives";
            this.tbLoadPendrives.Click += new System.EventHandler(this.tbLoadPendrives_Click);
            // 
            // tbSendTo
            // 
            this.tbSendTo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSendTo.Image = global::MovieBrowser.Properties.Resources.send_to;
            this.tbSendTo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSendTo.Name = "tbSendTo";
            this.tbSendTo.Size = new System.Drawing.Size(23, 22);
            this.tbSendTo.Text = "Send To Pendrive";
            this.tbSendTo.Click += new System.EventHandler(this.tbSendTo_Click);
            // 
            // tpMovies2
            // 
            this.tpMovies2.Controls.Add(this.dataListView1);
            this.tpMovies2.Controls.Add(this.panel1);
            this.tpMovies2.Location = new System.Drawing.Point(4, 26);
            this.tpMovies2.Name = "tpMovies2";
            this.tpMovies2.Padding = new System.Windows.Forms.Padding(3);
            this.tpMovies2.Size = new System.Drawing.Size(501, 292);
            this.tpMovies2.TabIndex = 2;
            this.tpMovies2.Text = "Movies";
            this.tpMovies2.UseVisualStyleBackColor = true;
            // 
            // dataListView1
            // 
            this.dataListView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.dataListView1.AllColumns.Add(this.olvTitle);
            this.dataListView1.AllColumns.Add(this.olvImdbId);
            this.dataListView1.AllColumns.Add(this.olvRating);
            this.dataListView1.AllColumns.Add(this.olvYear);
            this.dataListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvTitle,
            this.olvImdbId,
            this.olvRating,
            this.olvYear});
            this.dataListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataListView1.DataSource = null;
            this.dataListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataListView1.FullRowSelect = true;
            this.dataListView1.HideSelection = false;
            this.dataListView1.Location = new System.Drawing.Point(3, 56);
            this.dataListView1.Name = "dataListView1";
            this.dataListView1.OverlayText.Text = "";
            this.dataListView1.Size = new System.Drawing.Size(495, 233);
            this.dataListView1.TabIndex = 2;
            this.dataListView1.UseAlternatingBackColors = true;
            this.dataListView1.UseCompatibleStateImageBehavior = false;
            this.dataListView1.UseExplorerTheme = true;
            this.dataListView1.UseFiltering = true;
            this.dataListView1.UseHotItem = true;
            this.dataListView1.UseOverlays = false;
            this.dataListView1.UseTranslucentHotItem = true;
            this.dataListView1.View = System.Windows.Forms.View.Details;
            this.dataListView1.SelectedIndexChanged += new System.EventHandler(this.DataListView1SelectedIndexChanged);
            this.dataListView1.DoubleClick += new System.EventHandler(this.DataListView1DoubleClick);
            this.dataListView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataListView1KeyDown);
            // 
            // olvTitle
            // 
            this.olvTitle.AspectName = "TitleCleaned";
            this.olvTitle.Text = "Title";
            this.olvTitle.UseInitialLetterForGroup = true;
            this.olvTitle.Width = 200;
            // 
            // olvImdbId
            // 
            this.olvImdbId.AspectName = "ImdbId";
            this.olvImdbId.Text = "ImdbId";
            this.olvImdbId.Width = 100;
            // 
            // olvRating
            // 
            this.olvRating.AspectName = "Rating";
            this.olvRating.Text = "Rating";
            // 
            // olvYear
            // 
            this.olvYear.AspectName = "Year";
            this.olvYear.Text = "Year";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchTextBox2);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 53);
            this.panel1.TabIndex = 1;
            // 
            // searchTextBox2
            // 
            this.searchTextBox2.ActiveFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.searchTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchTextBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchTextBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchTextBox2.Location = new System.Drawing.Point(0, 25);
            this.searchTextBox2.Name = "searchTextBox2";
            this.searchTextBox2.Size = new System.Drawing.Size(495, 24);
            this.searchTextBox2.TabIndex = 6;
            this.searchTextBox2.SearchStarted += new System.EventHandler(this.searchTextBox2_SearchStarted);
            this.searchTextBox2.SearchCancelled += new System.EventHandler(this.searchTextBox2_SearchCancelled);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAddToDb,
            this.tbRefreshDb,
            this.tbDeleteFromDb,
            this.toolStripSeparator1,
            this.tbWantToWatch,
            this.tbLikeIt,
            this.tbDislikeIt,
            this.tbSeenIt,
            this.tbHaveIt,
            this.toolStripSeparator2,
            this.txtUserRating,
            this.tbRateIt});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(495, 25);
            this.toolStrip1.TabIndex = 5;
            // 
            // tbAddToDb
            // 
            this.tbAddToDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAddToDb.Image = global::MovieBrowser.Properties.Resources.update;
            this.tbAddToDb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAddToDb.Name = "tbAddToDb";
            this.tbAddToDb.Size = new System.Drawing.Size(23, 22);
            this.tbAddToDb.Text = "Collect";
            this.tbAddToDb.Click += new System.EventHandler(this.tbAddToDb_Click);
            // 
            // tbRefreshDb
            // 
            this.tbRefreshDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRefreshDb.Image = global::MovieBrowser.Properties.Resources.refresh16;
            this.tbRefreshDb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRefreshDb.Name = "tbRefreshDb";
            this.tbRefreshDb.Size = new System.Drawing.Size(23, 22);
            this.tbRefreshDb.Text = "Refresh";
            this.tbRefreshDb.Click += new System.EventHandler(this.tbRefreshDb_Click);
            // 
            // tbDeleteFromDb
            // 
            this.tbDeleteFromDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDeleteFromDb.Image = global::MovieBrowser.Properties.Resources.delete;
            this.tbDeleteFromDb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDeleteFromDb.Name = "tbDeleteFromDb";
            this.tbDeleteFromDb.Size = new System.Drawing.Size(23, 22);
            this.tbDeleteFromDb.Text = "Delete";
            this.tbDeleteFromDb.Click += new System.EventHandler(this.tbDeleteFromDb_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(501, 292);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Search";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.tabInformation);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(734, 297);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(734, 322);
            this.toolStripContainer2.TabIndex = 1;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // tabInformation
            // 
            this.tabInformation.Controls.Add(this.tabPage2);
            this.tabInformation.Controls.Add(this.tabPage1);
            this.tabInformation.Controls.Add(this.tpInformation);
            this.tabInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInformation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInformation.Location = new System.Drawing.Point(0, 0);
            this.tabInformation.Name = "tabInformation";
            this.tabInformation.SelectedIndex = 0;
            this.tabInformation.Size = new System.Drawing.Size(734, 297);
            this.tabInformation.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(726, 267);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Browser";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(720, 261);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser1DocumentCompleted);
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.WebBrowser1Navigated);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(726, 267);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Debug";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(720, 261);
            this.textBox1.TabIndex = 0;
            // 
            // tpInformation
            // 
            this.tpInformation.Controls.Add(this.button1);
            this.tpInformation.Controls.Add(this.buttonClean);
            this.tpInformation.Controls.Add(this.label3);
            this.tpInformation.Controls.Add(this.label2);
            this.tpInformation.Controls.Add(this.label1);
            this.tpInformation.Controls.Add(this.listGenres);
            this.tpInformation.Controls.Add(this.listCountries);
            this.tpInformation.Controls.Add(this.listKeywords);
            this.tpInformation.Location = new System.Drawing.Point(4, 26);
            this.tpInformation.Name = "tpInformation";
            this.tpInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tpInformation.Size = new System.Drawing.Size(726, 267);
            this.tpInformation.TabIndex = 4;
            this.tpInformation.Text = "Movie Info";
            this.tpInformation.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(168, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 18;
            this.button1.Text = "Clean All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonClean
            // 
            this.buttonClean.AutoSize = true;
            this.buttonClean.Location = new System.Drawing.Point(87, 6);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(75, 27);
            this.buttonClean.TabIndex = 17;
            this.buttonClean.Text = "Clean";
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Genres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Countries";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Keywords";
            // 
            // listGenres
            // 
            this.listGenres.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.listGenres.FullRowSelect = true;
            this.listGenres.Location = new System.Drawing.Point(436, 126);
            this.listGenres.Name = "listGenres";
            this.listGenres.Size = new System.Drawing.Size(209, 185);
            this.listGenres.TabIndex = 2;
            this.listGenres.UseCompatibleStateImageBehavior = false;
            this.listGenres.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 200;
            // 
            // listCountries
            // 
            this.listCountries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listCountries.FullRowSelect = true;
            this.listCountries.Location = new System.Drawing.Point(221, 126);
            this.listCountries.Name = "listCountries";
            this.listCountries.Size = new System.Drawing.Size(209, 185);
            this.listCountries.TabIndex = 1;
            this.listCountries.UseCompatibleStateImageBehavior = false;
            this.listCountries.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 200;
            // 
            // listKeywords
            // 
            this.listKeywords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listKeywords.FullRowSelect = true;
            this.listKeywords.Location = new System.Drawing.Point(6, 126);
            this.listKeywords.Name = "listKeywords";
            this.listKeywords.Size = new System.Drawing.Size(209, 185);
            this.listKeywords.TabIndex = 0;
            this.listKeywords.UseCompatibleStateImageBehavior = false;
            this.listKeywords.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // horizontalPanel1
            // 
            this.horizontalPanel1.BackColor = System.Drawing.Color.Transparent;
            this.horizontalPanel1.Controls.Add(this.label4);
            this.horizontalPanel1.Controls.Add(this.textHighlight);
            this.horizontalPanel1.Controls.Add(this.lblYear);
            this.horizontalPanel1.Controls.Add(this.lblTitle);
            this.horizontalPanel1.Controls.Add(this.lblRating);
            this.horizontalPanel1.Controls.Add(this.label8);
            this.horizontalPanel1.Controls.Add(this.lblRuntime);
            this.horizontalPanel1.Controls.Add(this.horizontalPanel2);
            this.horizontalPanel1.Controls.Add(this.label10);
            this.horizontalPanel1.Controls.Add(this.lblMPAA);
            this.horizontalPanel1.Controls.Add(this.textMpaaReason);
            this.horizontalPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.horizontalPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalPanel1.Location = new System.Drawing.Point(0, 322);
            this.horizontalPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 100);
            this.horizontalPanel1.Name = "horizontalPanel1";
            this.horizontalPanel1.Size = new System.Drawing.Size(1247, 100);
            this.horizontalPanel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(463, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "Highlight:";
            // 
            // textHighlight
            // 
            this.textHighlight.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textHighlight.Location = new System.Drawing.Point(529, 47);
            this.textHighlight.Multiline = true;
            this.textHighlight.Name = "textHighlight";
            this.textHighlight.ReadOnly = true;
            this.textHighlight.Size = new System.Drawing.Size(365, 48);
            this.textHighlight.TabIndex = 38;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(101, 42);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(0, 25);
            this.lblYear.TabIndex = 36;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(101, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(17, 28);
            this.lblTitle.TabIndex = 34;
            this.lblTitle.Text = ".";
            // 
            // lblRating
            // 
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblRating.Location = new System.Drawing.Point(5, 5);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(90, 90);
            this.lblRating.TabIndex = 33;
            this.lblRating.Text = ".";
            this.lblRating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(165, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 30;
            this.label8.Text = "Runtime:";
            // 
            // lblRuntime
            // 
            this.lblRuntime.Location = new System.Drawing.Point(226, 47);
            this.lblRuntime.Name = "lblRuntime";
            this.lblRuntime.ReadOnly = true;
            this.lblRuntime.Size = new System.Drawing.Size(231, 23);
            this.lblRuntime.TabIndex = 29;
            // 
            // horizontalPanel2
            // 
            this.horizontalPanel2.BackColor = System.Drawing.Color.Transparent;
            this.horizontalPanel2.Controls.Add(this.buttonModifyList);
            this.horizontalPanel2.Controls.Add(this.buttonAddToList);
            this.horizontalPanel2.Controls.Add(this.comboBox1);
            this.horizontalPanel2.Controls.Add(this.pbHaveIt);
            this.horizontalPanel2.Controls.Add(this.pbSeenIt);
            this.horizontalPanel2.Controls.Add(this.pbDislike);
            this.horizontalPanel2.Controls.Add(this.lblImdbId);
            this.horizontalPanel2.Controls.Add(this.pbLike);
            this.horizontalPanel2.Controls.Add(this.pbWanted);
            this.horizontalPanel2.Controls.Add(this.rsUserRating);
            this.horizontalPanel2.Controls.Add(this.label9);
            this.horizontalPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.horizontalPanel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalPanel2.Location = new System.Drawing.Point(900, 0);
            this.horizontalPanel2.Name = "horizontalPanel2";
            this.horizontalPanel2.Size = new System.Drawing.Size(347, 100);
            this.horizontalPanel2.TabIndex = 28;
            // 
            // buttonModifyList
            // 
            this.buttonModifyList.Image = global::MovieBrowser.Properties.Resources.modify;
            this.buttonModifyList.Location = new System.Drawing.Point(299, 68);
            this.buttonModifyList.Name = "buttonModifyList";
            this.buttonModifyList.Size = new System.Drawing.Size(24, 24);
            this.buttonModifyList.TabIndex = 35;
            this.buttonModifyList.UseVisualStyleBackColor = true;
            // 
            // buttonAddToList
            // 
            this.buttonAddToList.Image = global::MovieBrowser.Properties.Resources.add;
            this.buttonAddToList.Location = new System.Drawing.Point(269, 68);
            this.buttonAddToList.Name = "buttonAddToList";
            this.buttonAddToList.Size = new System.Drawing.Size(24, 24);
            this.buttonAddToList.TabIndex = 34;
            this.buttonAddToList.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(79, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 23);
            this.comboBox1.TabIndex = 33;
            // 
            // pbHaveIt
            // 
            this.pbHaveIt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHaveIt.Image = global::MovieBrowser.Properties.Resources.have_it_dis;
            this.pbHaveIt.Location = new System.Drawing.Point(231, 30);
            this.pbHaveIt.Name = "pbHaveIt";
            this.pbHaveIt.Size = new System.Drawing.Size(32, 32);
            this.pbHaveIt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbHaveIt.TabIndex = 32;
            this.pbHaveIt.TabStop = false;
            this.pbHaveIt.Click += new System.EventHandler(this.pbHaveIt_Click);
            // 
            // pbSeenIt
            // 
            this.pbSeenIt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSeenIt.Image = global::MovieBrowser.Properties.Resources.seen_it_dis;
            this.pbSeenIt.Location = new System.Drawing.Point(193, 30);
            this.pbSeenIt.Name = "pbSeenIt";
            this.pbSeenIt.Size = new System.Drawing.Size(32, 32);
            this.pbSeenIt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSeenIt.TabIndex = 31;
            this.pbSeenIt.TabStop = false;
            this.pbSeenIt.Click += new System.EventHandler(this.pbSeenIt_Click);
            // 
            // pbDislike
            // 
            this.pbDislike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDislike.Image = global::MovieBrowser.Properties.Resources.hate_it_dis;
            this.pbDislike.Location = new System.Drawing.Point(155, 30);
            this.pbDislike.Name = "pbDislike";
            this.pbDislike.Size = new System.Drawing.Size(32, 32);
            this.pbDislike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbDislike.TabIndex = 30;
            this.pbDislike.TabStop = false;
            this.pbDislike.Click += new System.EventHandler(this.pbDislike_Click);
            // 
            // lblImdbId
            // 
            this.lblImdbId.AutoSize = true;
            this.lblImdbId.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImdbId.Location = new System.Drawing.Point(5, 76);
            this.lblImdbId.Name = "lblImdbId";
            this.lblImdbId.Size = new System.Drawing.Size(21, 19);
            this.lblImdbId.TabIndex = 13;
            this.lblImdbId.Text = "tt";
            this.lblImdbId.Visible = false;
            // 
            // pbLike
            // 
            this.pbLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLike.Image = global::MovieBrowser.Properties.Resources.like_it_dis;
            this.pbLike.Location = new System.Drawing.Point(117, 30);
            this.pbLike.Name = "pbLike";
            this.pbLike.Size = new System.Drawing.Size(32, 32);
            this.pbLike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLike.TabIndex = 29;
            this.pbLike.TabStop = false;
            this.pbLike.Click += new System.EventHandler(this.pbLike_Click);
            // 
            // pbWanted
            // 
            this.pbWanted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbWanted.Image = global::MovieBrowser.Properties.Resources.check_list_dis;
            this.pbWanted.Location = new System.Drawing.Point(79, 30);
            this.pbWanted.Name = "pbWanted";
            this.pbWanted.Size = new System.Drawing.Size(32, 32);
            this.pbWanted.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbWanted.TabIndex = 28;
            this.pbWanted.TabStop = false;
            this.pbWanted.Click += new System.EventHandler(this.pbWanted_Click);
            // 
            // rsUserRating
            // 
            this.rsUserRating.ControlLayout = RatingControl.RatingStar.Layouts.Horizontal;
            this.rsUserRating.Level = 10;
            this.rsUserRating.Location = new System.Drawing.Point(79, 3);
            this.rsUserRating.Margin = new System.Windows.Forms.Padding(0);
            this.rsUserRating.Name = "rsUserRating";
            this.rsUserRating.Rating = 0D;
            this.rsUserRating.Size = new System.Drawing.Size(264, 24);
            this.rsUserRating.TabIndex = 19;
            this.rsUserRating.RatingValueChanged += new RatingControl.RatingStar.RatingValueChangedEventHandler(this.rsUserRating_RatingValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(6, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "User Rating:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(165, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 15);
            this.label10.TabIndex = 26;
            this.label10.Text = "for";
            // 
            // lblMPAA
            // 
            this.lblMPAA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMPAA.Location = new System.Drawing.Point(101, 72);
            this.lblMPAA.Name = "lblMPAA";
            this.lblMPAA.ReadOnly = true;
            this.lblMPAA.Size = new System.Drawing.Size(58, 23);
            this.lblMPAA.TabIndex = 24;
            // 
            // textMpaaReason
            // 
            this.textMpaaReason.Location = new System.Drawing.Point(193, 72);
            this.textMpaaReason.Name = "textMpaaReason";
            this.textMpaaReason.ReadOnly = true;
            this.textMpaaReason.Size = new System.Drawing.Size(264, 23);
            this.textMpaaReason.TabIndex = 22;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(166, 22);
            this.toolStripButton2.Text = "Collect Movie Information";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.googleToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.updateMovieDatabaseToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItemClick);
            // 
            // googleToolStripMenuItem
            // 
            this.googleToolStripMenuItem.Name = "googleToolStripMenuItem";
            this.googleToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.googleToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.googleToolStripMenuItem.Text = "Google";
            this.googleToolStripMenuItem.Click += new System.EventHandler(this.GoogleToolStripMenuItemClick);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItemClick);
            // 
            // updateMovieDatabaseToolStripMenuItem
            // 
            this.updateMovieDatabaseToolStripMenuItem.Name = "updateMovieDatabaseToolStripMenuItem";
            this.updateMovieDatabaseToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.updateMovieDatabaseToolStripMenuItem.Text = "Update Movie Database";
            this.updateMovieDatabaseToolStripMenuItem.Click += new System.EventHandler(this.UpdateMovieDatabaseToolStripMenuItemClick);
            // 
            // parseToolStripMenuItem
            // 
            this.parseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intelligentTrackerToolStripMenuItem});
            this.parseToolStripMenuItem.Name = "parseToolStripMenuItem";
            this.parseToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.parseToolStripMenuItem.Text = "&Parse";
            // 
            // intelligentTrackerToolStripMenuItem
            // 
            this.intelligentTrackerToolStripMenuItem.Checked = true;
            this.intelligentTrackerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.intelligentTrackerToolStripMenuItem.Name = "intelligentTrackerToolStripMenuItem";
            this.intelligentTrackerToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.intelligentTrackerToolStripMenuItem.Text = "&Intelligent Tracker";
            this.intelligentTrackerToolStripMenuItem.Click += new System.EventHandler(this.IntelligentTrackerToolStripMenuItemClick);
            // 
            // extraToolStripMenuItem
            // 
            this.extraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortToolStripMenuItem});
            this.extraToolStripMenuItem.Name = "extraToolStripMenuItem";
            this.extraToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.extraToolStripMenuItem.Text = "Extra";
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.sortToolStripMenuItem.Text = "&Sort";
            this.sortToolStripMenuItem.Click += new System.EventHandler(this.SortToolStripMenuItemClick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // tbWantToWatch
            // 
            this.tbWantToWatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbWantToWatch.Image = global::MovieBrowser.Properties.Resources.check_list;
            this.tbWantToWatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbWantToWatch.Name = "tbWantToWatch";
            this.tbWantToWatch.Size = new System.Drawing.Size(23, 22);
            this.tbWantToWatch.Text = "Watch";
            this.tbWantToWatch.Click += new System.EventHandler(this.tbWantToWatch_Click);
            // 
            // tbLikeIt
            // 
            this.tbLikeIt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbLikeIt.Image = global::MovieBrowser.Properties.Resources.like_it;
            this.tbLikeIt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbLikeIt.Name = "tbLikeIt";
            this.tbLikeIt.Size = new System.Drawing.Size(23, 22);
            this.tbLikeIt.Text = "Like It";
            this.tbLikeIt.Click += new System.EventHandler(this.tbLikeIt_Click);
            // 
            // tbDislikeIt
            // 
            this.tbDislikeIt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDislikeIt.Image = global::MovieBrowser.Properties.Resources.hate_it;
            this.tbDislikeIt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDislikeIt.Name = "tbDislikeIt";
            this.tbDislikeIt.Size = new System.Drawing.Size(23, 22);
            this.tbDislikeIt.Text = "Dislike It";
            this.tbDislikeIt.ToolTipText = "Dislike It";
            this.tbDislikeIt.Click += new System.EventHandler(this.tbDislikeIt_Click);
            // 
            // tbSeenIt
            // 
            this.tbSeenIt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSeenIt.Image = global::MovieBrowser.Properties.Resources.seen_it;
            this.tbSeenIt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSeenIt.Name = "tbSeenIt";
            this.tbSeenIt.Size = new System.Drawing.Size(23, 22);
            this.tbSeenIt.Text = "Seen It";
            this.tbSeenIt.Click += new System.EventHandler(this.tbSeenIt_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbHaveIt
            // 
            this.tbHaveIt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHaveIt.Image = global::MovieBrowser.Properties.Resources.have_it;
            this.tbHaveIt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbHaveIt.Name = "tbHaveIt";
            this.tbHaveIt.Size = new System.Drawing.Size(23, 22);
            this.tbHaveIt.Text = "Have It";
            this.tbHaveIt.Click += new System.EventHandler(this.tbHaveIt_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtUserRating
            // 
            this.txtUserRating.Name = "txtUserRating";
            this.txtUserRating.Size = new System.Drawing.Size(48, 25);
            // 
            // tbRateIt
            // 
            this.tbRateIt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRateIt.Image = global::MovieBrowser.Properties.Resources.movie_db;
            this.tbRateIt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRateIt.Name = "tbRateIt";
            this.tbRateIt.Size = new System.Drawing.Size(23, 22);
            this.tbRateIt.Text = "Rate It";
            // 
            // MovieBrowserSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 447);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MovieBrowserSimple";
            this.Text = "Movie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MovieBrowserSimpleFormClosing);
            this.Load += new System.EventHandler(this.MovieBrowserSimpleLoad);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabMovies.ResumeLayout(false);
            this.tpMoviesTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tpMovies2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.tabInformation.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tpInformation.ResumeLayout(false);
            this.tpInformation.PerformLayout();
            this.horizontalPanel1.ResumeLayout(false);
            this.horizontalPanel1.PerformLayout();
            this.horizontalPanel2.ResumeLayout(false);
            this.horizontalPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHaveIt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeenIt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDislike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWanted)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabInformation;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripMenuItem parseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intelligentTrackerToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sendToPendriveToolStripMenuItem;
        private System.Windows.Forms.TabControl tabMovies;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem updateMovieDatabaseToolStripMenuItem;
        private System.Windows.Forms.TabPage tpInformation;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updateMovieInformationToolStripMenuItem;
        private System.Windows.Forms.ListView listGenres;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView listCountries;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView listKeywords;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblImdbId;
        private System.Windows.Forms.TabPage tpMovies2;
        private System.Windows.Forms.Panel panel1;
        private BrightIdeasSoftware.DataListView dataListView1;
        private BrightIdeasSoftware.OLVColumn olvTitle;
        private BrightIdeasSoftware.OLVColumn olvImdbId;
        private BrightIdeasSoftware.OLVColumn olvRating;
        private BrightIdeasSoftware.OLVColumn olvYear;
        private System.Windows.Forms.Button buttonClean;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tpMoviesTree;
        private System.Windows.Forms.Panel panel2;
        private BrightIdeasSoftware.TreeListView treeView1;
        private BrightIdeasSoftware.OLVColumn treeColumnTitle;
        private BrightIdeasSoftware.OLVColumn treeColumnRating;
        private BrightIdeasSoftware.OLVColumn treeColumnYear;
        private BrightIdeasSoftware.OLVColumn treeColumnSize;
        private BrightIdeasSoftware.OLVColumn treeColumnFileType;
        private RatingControl.RatingStar rsUserRating;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private WindowsFormsAero.HorizontalPanel horizontalPanel1;
        private System.Windows.Forms.TextBox textMpaaReason;
        private System.Windows.Forms.TextBox lblMPAA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private WindowsFormsAero.HorizontalPanel horizontalPanel2;
        private System.Windows.Forms.PictureBox pbWanted;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lblRuntime;
        private System.Windows.Forms.TextBox textHighlight;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbHaveIt;
        private System.Windows.Forms.PictureBox pbSeenIt;
        private System.Windows.Forms.PictureBox pbDislike;
        private System.Windows.Forms.PictureBox pbLike;
        private System.Windows.Forms.ToolStripMenuItem refreshFolderToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private WindowsFormsAero.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonModifyList;
        private System.Windows.Forms.Button buttonAddToList;
        private WindowsFormsAero.SearchTextBox searchTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton pbUpdateTree;
        private System.Windows.Forms.ToolStripButton pbAddTreeItemToDb;
        private System.Windows.Forms.ToolStripButton tbBrowseFolders;
        private System.Windows.Forms.ToolStripButton tbRemoveFolders;
        private System.Windows.Forms.ToolStripButton tbSaveFolders;
        private System.Windows.Forms.ToolStripButton tbRefreshFolders;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tbSearchImdb;
        private System.Windows.Forms.ToolStripButton tbSearchGoogle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tbOpenExplorer;
        private System.Windows.Forms.ToolStripButton tbIgnoreList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripComboBox comboPendrives;
        private System.Windows.Forms.ToolStripButton tbLoadPendrives;
        private System.Windows.Forms.ToolStripButton tbSendTo;
        private WindowsFormsAero.SearchTextBox searchTextBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbAddToDb;
        private System.Windows.Forms.ToolStripButton tbRefreshDb;
        private System.Windows.Forms.ToolStripButton tbDeleteFromDb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbWantToWatch;
        private System.Windows.Forms.ToolStripButton tbLikeIt;
        private System.Windows.Forms.ToolStripButton tbDislikeIt;
        private System.Windows.Forms.ToolStripButton tbSeenIt;
        private System.Windows.Forms.ToolStripButton tbHaveIt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox txtUserRating;
        private System.Windows.Forms.ToolStripButton tbRateIt;
    }
}

