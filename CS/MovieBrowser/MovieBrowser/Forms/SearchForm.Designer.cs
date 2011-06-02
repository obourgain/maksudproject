namespace MovieBrowser.Forms
{
    partial class SearchForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.listKeywords = new BrightIdeasSoftware.DataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label2 = new System.Windows.Forms.Label();
            this.listGenres = new BrightIdeasSoftware.DataListView();
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label3 = new System.Windows.Forms.Label();
            this.textRatingFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textRatingTo = new System.Windows.Forms.TextBox();
            this.clSearch = new WindowsFormsAero.CommandLink();
            ((System.ComponentModel.ISupportInitialize)(this.listKeywords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listGenres)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Keywords";
            // 
            // listKeywords
            // 
            this.listKeywords.AllColumns.Add(this.olvColumn1);
            this.listKeywords.AllColumns.Add(this.olvColumn3);
            this.listKeywords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn3});
            this.listKeywords.DataSource = null;
            this.listKeywords.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listKeywords.FullRowSelect = true;
            this.listKeywords.GridLines = true;
            this.listKeywords.HideSelection = false;
            this.listKeywords.Location = new System.Drawing.Point(15, 31);
            this.listKeywords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listKeywords.Name = "listKeywords";
            this.listKeywords.OwnerDraw = true;
            this.listKeywords.Size = new System.Drawing.Size(238, 146);
            this.listKeywords.TabIndex = 5;
            this.listKeywords.UseCompatibleStateImageBehavior = false;
            this.listKeywords.UseFiltering = true;
            this.listKeywords.UseHotItem = true;
            this.listKeywords.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.IsTileViewColumn = true;
            this.olvColumn1.Text = "Name";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 150;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Rated";
            this.olvColumn3.Text = "Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Genre";
            // 
            // listGenres
            // 
            this.listGenres.AllColumns.Add(this.olvColumn2);
            this.listGenres.AllColumns.Add(this.olvColumn4);
            this.listGenres.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn2,
            this.olvColumn4});
            this.listGenres.DataSource = null;
            this.listGenres.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listGenres.FullRowSelect = true;
            this.listGenres.GridLines = true;
            this.listGenres.HideSelection = false;
            this.listGenres.Location = new System.Drawing.Point(15, 204);
            this.listGenres.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listGenres.Name = "listGenres";
            this.listGenres.OwnerDraw = true;
            this.listGenres.Size = new System.Drawing.Size(238, 146);
            this.listGenres.TabIndex = 7;
            this.listGenres.UseCompatibleStateImageBehavior = false;
            this.listGenres.UseFiltering = true;
            this.listGenres.UseHotItem = true;
            this.listGenres.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Name";
            this.olvColumn2.IsTileViewColumn = true;
            this.olvColumn2.Text = "Name";
            this.olvColumn2.UseInitialLetterForGroup = true;
            this.olvColumn2.Width = 150;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Rated";
            this.olvColumn4.Text = "Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Imdb Rating";
            // 
            // textRatingFrom
            // 
            this.textRatingFrom.Location = new System.Drawing.Point(276, 29);
            this.textRatingFrom.Name = "textRatingFrom";
            this.textRatingFrom.Size = new System.Drawing.Size(60, 25);
            this.textRatingFrom.TabIndex = 9;
            this.textRatingFrom.Text = "6";
            this.textRatingFrom.TextChanged += new System.EventHandler(this.textRatingFrom_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "&&";
            // 
            // textRatingTo
            // 
            this.textRatingTo.Location = new System.Drawing.Point(367, 29);
            this.textRatingTo.Name = "textRatingTo";
            this.textRatingTo.Size = new System.Drawing.Size(60, 25);
            this.textRatingTo.TabIndex = 11;
            this.textRatingTo.Text = "10";
            // 
            // clSearch
            // 
            this.clSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clSearch.Location = new System.Drawing.Point(372, 370);
            this.clSearch.Name = "clSearch";
            this.clSearch.Size = new System.Drawing.Size(200, 48);
            this.clSearch.TabIndex = 12;
            this.clSearch.Text = "Search";
            this.clSearch.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 430);
            this.Controls.Add(this.clSearch);
            this.Controls.Add(this.textRatingTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textRatingFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listGenres);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listKeywords);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.listKeywords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listGenres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.DataListView listKeywords;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private System.Windows.Forms.Label label2;
        private BrightIdeasSoftware.DataListView listGenres;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textRatingFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textRatingTo;
        private WindowsFormsAero.CommandLink clSearch;
    }
}