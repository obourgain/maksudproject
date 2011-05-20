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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabMovies = new System.Windows.Forms.TabControl();
            this.tpFileSystem = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToPendriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tpMovies = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colImdbId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRating = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabInformation = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textIgnore = new System.Windows.Forms.TextBox();
            this.tpInformation = new System.Windows.Forms.TabPage();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsParse = new System.Windows.Forms.ToolStripButton();
            this.tsUpdateFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBrowseFolder = new System.Windows.Forms.ToolStripButton();
            this.tsSaveFolders = new System.Windows.Forms.ToolStripButton();
            this.tsReload = new System.Windows.Forms.ToolStripButton();
            this.tsSearchImdb = new System.Windows.Forms.ToolStripButton();
            this.tsSearchGoogle = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.tsOpenInExplorer = new System.Windows.Forms.ToolStripButton();
            this.tsUpdateIgnoreList = new System.Windows.Forms.ToolStripButton();
            this.tsPendrives = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateMovieDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseCurrentPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intelligentTrackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabMovies.SuspendLayout();
            this.tpFileSystem.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tpMovies.SuspendLayout();
            this.tabInformation.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(823, 376);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(823, 423);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(823, 22);
            this.statusStrip1.TabIndex = 0;
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
            this.splitContainer1.Panel2.Controls.Add(this.tabInformation);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip3);
            this.splitContainer1.Size = new System.Drawing.Size(823, 376);
            this.splitContainer1.SplitterDistance = 273;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabMovies
            // 
            this.tabMovies.Controls.Add(this.tpFileSystem);
            this.tabMovies.Controls.Add(this.tpMovies);
            this.tabMovies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMovies.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMovies.Location = new System.Drawing.Point(0, 0);
            this.tabMovies.Name = "tabMovies";
            this.tabMovies.SelectedIndex = 0;
            this.tabMovies.Size = new System.Drawing.Size(273, 376);
            this.tabMovies.TabIndex = 2;
            // 
            // tpFileSystem
            // 
            this.tpFileSystem.Controls.Add(this.treeView1);
            this.tpFileSystem.Location = new System.Drawing.Point(4, 26);
            this.tpFileSystem.Name = "tpFileSystem";
            this.tpFileSystem.Padding = new System.Windows.Forms.Padding(3);
            this.tpFileSystem.Size = new System.Drawing.Size(265, 346);
            this.tpFileSystem.TabIndex = 0;
            this.tpFileSystem.Text = "Movie Folders";
            this.tpFileSystem.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(259, 340);
            this.treeView1.TabIndex = 1;
            this.treeView1.DoubleClick += new System.EventHandler(this.TreeView1DoubleClick);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TreeView1KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToPendriveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 26);
            // 
            // sendToPendriveToolStripMenuItem
            // 
            this.sendToPendriveToolStripMenuItem.Name = "sendToPendriveToolStripMenuItem";
            this.sendToPendriveToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.sendToPendriveToolStripMenuItem.Text = "Send To Pendrive";
            this.sendToPendriveToolStripMenuItem.Click += new System.EventHandler(this.SendToPendriveToolStripMenuItemClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "movie");
            this.imageList1.Images.SetKeyName(1, "folder");
            this.imageList1.Images.SetKeyName(2, "video");
            this.imageList1.Images.SetKeyName(3, "subtitle");
            this.imageList1.Images.SetKeyName(4, "file");
            // 
            // tpMovies
            // 
            this.tpMovies.Controls.Add(this.listView1);
            this.tpMovies.Location = new System.Drawing.Point(4, 26);
            this.tpMovies.Name = "tpMovies";
            this.tpMovies.Padding = new System.Windows.Forms.Padding(3);
            this.tpMovies.Size = new System.Drawing.Size(265, 344);
            this.tpMovies.TabIndex = 1;
            this.tpMovies.Text = "Movies";
            this.tpMovies.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colImdbId,
            this.colTitle,
            this.colRating,
            this.colYear});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(259, 340);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.ListView1DoubleClick);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListView1KeyDown);
            // 
            // colImdbId
            // 
            this.colImdbId.Text = "Imdb Id";
            this.colImdbId.Width = 100;
            // 
            // colTitle
            // 
            this.colTitle.Text = "Title";
            this.colTitle.Width = 200;
            // 
            // colRating
            // 
            this.colRating.Text = "Rating";
            // 
            // colYear
            // 
            this.colYear.Text = "Year";
            // 
            // tabInformation
            // 
            this.tabInformation.Controls.Add(this.tabPage2);
            this.tabInformation.Controls.Add(this.tabPage1);
            this.tabInformation.Controls.Add(this.tabPage3);
            this.tabInformation.Controls.Add(this.tpInformation);
            this.tabInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInformation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInformation.Location = new System.Drawing.Point(0, 25);
            this.tabInformation.Name = "tabInformation";
            this.tabInformation.SelectedIndex = 0;
            this.tabInformation.Size = new System.Drawing.Size(546, 351);
            this.tabInformation.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(538, 321);
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
            this.webBrowser1.Size = new System.Drawing.Size(532, 315);
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
            this.tabPage1.Size = new System.Drawing.Size(538, 319);
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
            this.textBox1.Size = new System.Drawing.Size(532, 315);
            this.textBox1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textIgnore);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(538, 319);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Ignore List";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textIgnore
            // 
            this.textIgnore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textIgnore.Location = new System.Drawing.Point(3, 3);
            this.textIgnore.Multiline = true;
            this.textIgnore.Name = "textIgnore";
            this.textIgnore.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textIgnore.Size = new System.Drawing.Size(532, 315);
            this.textIgnore.TabIndex = 0;
            // 
            // tpInformation
            // 
            this.tpInformation.Location = new System.Drawing.Point(4, 26);
            this.tpInformation.Name = "tpInformation";
            this.tpInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tpInformation.Size = new System.Drawing.Size(538, 319);
            this.tpInformation.TabIndex = 4;
            this.tpInformation.Text = "Movie Info";
            this.tpInformation.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsParse,
            this.tsUpdateFolder,
            this.toolStripButton2});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(546, 25);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsParse
            // 
            this.tsParse.Image = ((System.Drawing.Image)(resources.GetObject("tsParse.Image")));
            this.tsParse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsParse.Name = "tsParse";
            this.tsParse.Size = new System.Drawing.Size(55, 22);
            this.tsParse.Text = "Parse";
            this.tsParse.Click += new System.EventHandler(this.ToolStripButton7Click);
            // 
            // tsUpdateFolder
            // 
            this.tsUpdateFolder.Image = ((System.Drawing.Image)(resources.GetObject("tsUpdateFolder.Image")));
            this.tsUpdateFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUpdateFolder.Name = "tsUpdateFolder";
            this.tsUpdateFolder.Size = new System.Drawing.Size(101, 22);
            this.tsUpdateFolder.Text = "Update Folder";
            this.tsUpdateFolder.Click += new System.EventHandler(this.ToolStripButton6Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(107, 22);
            this.toolStripButton2.Text = "Add To Movies";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBrowseFolder,
            this.tsSaveFolders,
            this.tsReload,
            this.tsSearchImdb,
            this.tsSearchGoogle,
            this.tsDelete,
            this.tsOpenInExplorer,
            this.tsUpdateIgnoreList,
            this.tsPendrives,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(709, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsBrowseFolder
            // 
            this.tsBrowseFolder.Image = ((System.Drawing.Image)(resources.GetObject("tsBrowseFolder.Image")));
            this.tsBrowseFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBrowseFolder.Name = "tsBrowseFolder";
            this.tsBrowseFolder.Size = new System.Drawing.Size(65, 22);
            this.tsBrowseFolder.Text = "Browse";
            this.tsBrowseFolder.Click += new System.EventHandler(this.ToolStripButton1Click);
            // 
            // tsSaveFolders
            // 
            this.tsSaveFolders.Image = ((System.Drawing.Image)(resources.GetObject("tsSaveFolders.Image")));
            this.tsSaveFolders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSaveFolders.Name = "tsSaveFolders";
            this.tsSaveFolders.Size = new System.Drawing.Size(51, 22);
            this.tsSaveFolders.Text = "Save";
            this.tsSaveFolders.Click += new System.EventHandler(this.TsSaveFoldersClick);
            // 
            // tsReload
            // 
            this.tsReload.Image = ((System.Drawing.Image)(resources.GetObject("tsReload.Image")));
            this.tsReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsReload.Name = "tsReload";
            this.tsReload.Size = new System.Drawing.Size(63, 22);
            this.tsReload.Text = "Reload";
            this.tsReload.Click += new System.EventHandler(this.ToolStripButton9Click);
            // 
            // tsSearchImdb
            // 
            this.tsSearchImdb.Image = ((System.Drawing.Image)(resources.GetObject("tsSearchImdb.Image")));
            this.tsSearchImdb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSearchImdb.Name = "tsSearchImdb";
            this.tsSearchImdb.Size = new System.Drawing.Size(56, 22);
            this.tsSearchImdb.Text = "IMDB";
            this.tsSearchImdb.Click += new System.EventHandler(this.tsSearchImdbClicl);
            // 
            // tsSearchGoogle
            // 
            this.tsSearchGoogle.Image = ((System.Drawing.Image)(resources.GetObject("tsSearchGoogle.Image")));
            this.tsSearchGoogle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSearchGoogle.Name = "tsSearchGoogle";
            this.tsSearchGoogle.Size = new System.Drawing.Size(65, 22);
            this.tsSearchGoogle.Text = "Google";
            this.tsSearchGoogle.Click += new System.EventHandler(this.tsSearchGoogleClick);
            // 
            // tsDelete
            // 
            this.tsDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsDelete.Image")));
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(60, 22);
            this.tsDelete.Text = "Delete";
            this.tsDelete.Click += new System.EventHandler(this.tsDeleteClick);
            // 
            // tsOpenInExplorer
            // 
            this.tsOpenInExplorer.Image = ((System.Drawing.Image)(resources.GetObject("tsOpenInExplorer.Image")));
            this.tsOpenInExplorer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOpenInExplorer.Name = "tsOpenInExplorer";
            this.tsOpenInExplorer.Size = new System.Drawing.Size(114, 22);
            this.tsOpenInExplorer.Text = "Open in Explorer";
            this.tsOpenInExplorer.Click += new System.EventHandler(this.TsOpenInExplorerClick);
            // 
            // tsUpdateIgnoreList
            // 
            this.tsUpdateIgnoreList.Image = ((System.Drawing.Image)(resources.GetObject("tsUpdateIgnoreList.Image")));
            this.tsUpdateIgnoreList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUpdateIgnoreList.Name = "tsUpdateIgnoreList";
            this.tsUpdateIgnoreList.Size = new System.Drawing.Size(123, 22);
            this.tsUpdateIgnoreList.Text = "Update Ignore List";
            this.tsUpdateIgnoreList.Click += new System.EventHandler(this.TsUpdateIgnoreListClick);
            // 
            // tsPendrives
            // 
            this.tsPendrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsPendrives.Name = "tsPendrives";
            this.tsPendrives.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Load Pendrives";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.parseToolStripMenuItem,
            this.extraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(823, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
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
            this.parseCurrentPageToolStripMenuItem,
            this.intelligentTrackerToolStripMenuItem});
            this.parseToolStripMenuItem.Name = "parseToolStripMenuItem";
            this.parseToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.parseToolStripMenuItem.Text = "&Parse";
            // 
            // parseCurrentPageToolStripMenuItem
            // 
            this.parseCurrentPageToolStripMenuItem.Name = "parseCurrentPageToolStripMenuItem";
            this.parseCurrentPageToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.parseCurrentPageToolStripMenuItem.Text = "&Parse Current Page";
            // 
            // intelligentTrackerToolStripMenuItem
            // 
            this.intelligentTrackerToolStripMenuItem.Checked = true;
            this.intelligentTrackerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.intelligentTrackerToolStripMenuItem.Name = "intelligentTrackerToolStripMenuItem";
            this.intelligentTrackerToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
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
            // MovieBrowserSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 447);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MovieBrowserSimple";
            this.Text = "Movie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MovieBrowserSimpleFormClosing);
            this.Load += new System.EventHandler(this.MovieBrowserSimpleLoad);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tabMovies.ResumeLayout(false);
            this.tpFileSystem.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tpMovies.ResumeLayout(false);
            this.tabInformation.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBrowseFolder;
        private System.Windows.Forms.ToolStripButton tsSearchImdb;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsSearchGoogle;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabInformation;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsParse;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem parseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseCurrentPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intelligentTrackerToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textIgnore;
        private System.Windows.Forms.ToolStripButton tsUpdateFolder;
        private System.Windows.Forms.ToolStripButton tsOpenInExplorer;
        private System.Windows.Forms.ToolStripButton tsUpdateIgnoreList;
        private System.Windows.Forms.ToolStripButton tsReload;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsSaveFolders;
        private System.Windows.Forms.ToolStripMenuItem extraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripComboBox tsPendrives;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sendToPendriveToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabControl tabMovies;
        private System.Windows.Forms.TabPage tpFileSystem;
        private System.Windows.Forms.TabPage tpMovies;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colImdbId;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colRating;
        private System.Windows.Forms.ToolStripMenuItem updateMovieDatabaseToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader colYear;
        private System.Windows.Forms.TabPage tpInformation;
    }
}

