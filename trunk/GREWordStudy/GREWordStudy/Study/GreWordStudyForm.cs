using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Crownwood.DotNetMagic.Controls;
using GREWordStudy.Collector;
using GREWordStudy.Common.Browser;
using GREWordStudy.Model;
using ShellLib;

namespace GREWordStudy.Study
{
    public partial class GreWordStudyForm : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseCapture(IntPtr hWnd);

        bool _captured;
        Point _pStart, _pEnd;
        readonly FolderBrowserDialog _fbd = new FolderBrowserDialog();
        private bool _isCommentDirty;
        //Bitmap resultBitmap;

        private readonly Color[] _hardnessForeground = new Color[] { Color.Black, Color.Navy, Color.Black, Color.Black, Color.Black, Color.White };
        private readonly Color[] _hardnessBackground = new Color[] { Color.White, Color.LightGreen, Color.Aquamarine, Color.Yellow, Color.Pink, Color.Red };
        private readonly Color[] _colorBackground = new Color[] { Color.MistyRose, Color.LightBlue, Color.Yellow, Color.Thistle };

        int _cindex;

        readonly Dictionary<string, WebUrl> _webUrls = new Dictionary<string, WebUrl>();
        //readonly Dictionary<string, MaxBrowser> _browsers = new Dictionary<string, MaxBrowser>();

        String _currentWord = "";

        readonly gredbEntities _entities = new gredbEntities();

        public GreWordStudyForm()
        {
            InitializeComponent();

            LoadDatabase();
        }

        void buttonBrowseWord_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentWord)) return;

            ToolStripButton ts = (ToolStripButton)sender;
            string address = _webUrls[ts.Text].Url + _currentWord;

            NavigateTo(_currentWord, address, _webUrls[ts.Text].ImageIndex);
        }


        private void comboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWordList();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TimedFilter(this.wordsDataListView, textWord.Text);
        }

        private static void TimedFilter(DataListView olv, string txt, TextMatchFilter.MatchKind matchKind = TextMatchFilter.MatchKind.Text)
        {
            TextMatchFilter filter = null;
            if (!String.IsNullOrEmpty(txt))
                filter = new TextMatchFilter(olv, txt, matchKind);

            // Setup a default renderer to draw the filter matches
            if (filter == null)
                olv.DefaultRenderer = null;
            else
            {
                olv.DefaultRenderer = new HighlightTextRenderer(filter);

                // Uncomment this line to see how the GDI+ rendering looks
                //olv.DefaultRenderer = new HighlightTextRenderer { Filter = filter, UseGdiTextRendering = false };
            }

            // Some lists have renderers already installed
            HighlightTextRenderer highlightingRenderer = olv.GetColumn(0).Renderer as HighlightTextRenderer;
            if (highlightingRenderer != null)
                highlightingRenderer.Filter = filter;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            olv.ModelFilter = filter;
            stopWatch.Stop();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (_fbd.ShowDialog() == DialogResult.OK)
            {
                textBanglaDictionary.Text = _fbd.SelectedPath;
                Properties.Settings.Default.BengaliDictionaryPath = textBanglaDictionary.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveComment(_currentWord);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDatabase();
        }

        private void listViewRelation_DoubleClick(object sender, EventArgs e)
        {
            if (listViewRelation.SelectedItems.Count == 1)
            {
                LoadWordInformation(listViewRelation.SelectedItems[0].Text, false);
            }
        }

        private void listViewRelation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listViewRelation.SelectedItems.Count == 1)
                {
                    LoadWordInformation(listViewRelation.SelectedItems[0].Text, false);
                }
            }
        }

        private void rtfComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                MakeBold();
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                MakeUnderline();
            }
            else if (e.Control && e.KeyCode == Keys.T)
            {
                MakeStrikethrough();
            }
            else if (e.Control && e.KeyCode == Keys.OemOpenBrackets)
            {
                SetFontSizeAsIncrement((float)-2.0);
            }
            else if (e.Control && e.KeyCode == Keys.OemCloseBrackets)
            {
                SetFontSizeAsIncrement((float)2.0);
            }
            else if (e.Control && e.KeyCode == Keys.Oemcomma)
            {
                try
                {
                    int i = wordsDataListView.SelectedIndices[0];
                    wordsDataListView.SelectedItems.Clear();
                    wordsDataListView.Items[i - 1].Selected = true;
                    wordsDataListView.EnsureVisible(i - 1);
                }
                catch { }
            }
            else if (e.Control && e.KeyCode == Keys.OemPeriod)
            {
                try
                {
                    int i = wordsDataListView.SelectedIndices[0];
                    wordsDataListView.SelectedItems.Clear();
                    wordsDataListView.Items[i + 1].Selected = true;
                    wordsDataListView.EnsureVisible(i + 1);
                }
                catch { }

            }
        }

        #region DB Access
        private void SaveComment(string word)
        {
            GreWord greword = (from w in _entities.GreWords
                               where w.Word == word
                               select w).FirstOrDefault();
            String rtf = rtfComment.Rtf;
            greword.Comment = rtf;
            _entities.SaveChanges();
        }
        private void LoadDatabase()
        {

            this.olvColumn1.ImageGetter = delegate(object row)
                                              {
                                                  try
                                                  {
                                                      GreWord greWord = (GreWord)row;
                                                      return "rating_" + greWord.Hardness;
                                                  }
                                                  catch
                                                  {
                                                      return "rating_0";
                                                  }
                                              };

            this.hardnessColumn.MakeGroupies(
                new int[] { 1, 2, 3, 4, 5 },
                new string[] { "Unprocessed", "Very Easy", "Easy", "Moderate", "Hard", "Very Hard" });

            this.percentageColumn.MakeGroupies(
                new Double[] { 25, 50, 75 },
                new string[] { "Hard", "Moderate", "Easy", "Very Easy" });


            ResetWebBrowsers();

            //photohelper = new DataGridViewPhotoHelper(gridWordDefinition);

            var list2 = (from w in _entities.ListNames
                         select w).ToList();
            List<ListName> list = new List<ListName>();

            list.Add(new ListName() { Id = -1, Name = "None" });
            list.Add(new ListName() { Id = 0, Name = "All Words" });
            list.AddRange(list2);
            comboList.DisplayMember = "Name";
            comboList.ValueMember = "Id";
            comboList.DataSource = list;
        }
        private void LoadWordList()
        {
            long listNameId = Convert.ToInt64(comboList.SelectedValue);

            List<GreWord> words = null;
            if (listNameId > 0)
            {
                words = (from w in _entities.ListedWords
                         where w.ListName.Id == listNameId
                         orderby w.GreWord.Word
                         select w.GreWord ).ToList();
            }
            else if (listNameId == 0)
            {
                words = (from w in _entities.GreWords
                         orderby w.Word
                         select w).ToList();
            }
            else
            {
                words = new List<GreWord>();
            }

            //listBox1.Items.Clear();
            wordsDataListView.Items.Clear();
            wordsDataListView.DataSource = words;
        }
        private void LoadWordInformation(string word, bool chkAffinity)
        {
            if (_isCommentDirty)
            {
                SaveComment(_currentWord);
            }
            _currentWord = word;

            if (chkAffinity)
            {
                try
                {
                    listViewRelation.Items.Clear();

                    var affinity = (from w in _entities.GreWordAffinities
                                    where w.GreWord.Word == word
                                    orderby w.Affinity
                                    select new
                                               {
                                                   synonym = w.GreWord1.Word,
                                                   relation = w.Affinity,
                                                   hardness = w.GreWord1.Hardness
                                               }).ToList();

                    foreach (var aword in affinity)
                    {
                        ListViewItem lvi = new ListViewItem { Text = aword.synonym };
                        lvi.SubItems.Add(aword.relation + "");
                        lvi.ToolTipText = " [" + aword.hardness + "]";
                        lvi.BackColor = aword.relation == 1 ? Color.LightGreen : Color.Cornsilk;
                        listViewRelation.Items.Add(lvi);
                    }
                }
                catch { }
            }

            //
            List<string> listNames = (from o in _entities.ListedWords where o.GreWord.Word == word select o.ListName.Name).ToList();

            statusListNames.Text = "";
            foreach (var listName in listNames)
            {
                statusListNames.Text += "**" + listName + ",  ";
            }

            GreWord greWord = (from o in _entities.GreWords where o.Word == word select o).FirstOrDefault();
            statusRemembered.Text = greWord.Remembered + "";
            statusFailed.Text = greWord.Forgotten + "";
            statusTried.Text = (greWord.Remembered + greWord.Forgotten) + "";

            try
            {
                String filename = textBanglaDictionary.Text + "\\" + word + ".jpg";
                pictureBoxBanglaDictionary.Image = Image.FromFile(filename);
            }
            catch
            {
                pictureBoxBanglaDictionary.Image = null;
            }

            rtfMnemonics.Text = "";
            //Featured Mnemonics
            {
                List<FeaturedMnemonic> selected_mnemonics = (from w in _entities.FeaturedMnemonics
                                                             where w.GreWord.Word == word
                                                             select w).ToList();
                foreach (FeaturedMnemonic mnemonic in selected_mnemonics)
                {
                    rtfMnemonics.SelectionBackColor = _colorBackground[_cindex++ % 4];
                    rtfMnemonics.AppendText(mnemonic.Mnemonic + "\r\n");
                }
            }

            //Basic Mnemonics
            {
                List<BasicMnemonic> all_mnemonics = (from w in _entities.BasicMnemonics
                                                     where w.GreWord.Word == word
                                                     select w).ToList();
                foreach (BasicMnemonic mnemonic in all_mnemonics)
                {
                    rtfMnemonics.SelectionBackColor = _colorBackground[_cindex++ % 4];
                    rtfMnemonics.AppendText("[" + mnemonic.Helpful + "][" + mnemonic.NotHelpful + "]  " + mnemonic.Mnemonic + "\r\n");
                }
            }

            //Bengali Definition
            {
                List<BengaliDefinition> wordDefinition = (from w in _entities.BengaliDefinitions
                                                          where w.GreWord.Word == word
                                                          select w).Distinct().ToList();
                textBengali.Text = "";
                foreach (BengaliDefinition mnemonic in wordDefinition)
                {
                    textBengali.Text += mnemonic.Bengali + @", ";
                }
            }

            //Google Synonym
            {
                List<GoogleSynonym> wordDefinition = (from w in _entities.GoogleSynonyms
                                                      where w.GreWord.Word == word
                                                      select w).Distinct().ToList();
                textBengali.Text += Environment.NewLine;
                foreach (GoogleSynonym mnemonic in wordDefinition)
                {
                    textBengali.Text += mnemonic.Synonym + @", ";
                }
            }

            //Comment
            {
                var wordDefinition = (from w in _entities.GreWords
                                      where w.Word == word
                                      select w).FirstOrDefault();
                rtfComment.Text = "";

                if (wordDefinition != null)
                    rtfComment.Rtf = wordDefinition.Comment;

                _isCommentDirty = false;

            }

            //Etymology
            {
                WordEtymology wordDefinition = (from w in _entities.WordEtymologies
                                                where w.GreWord.Word == word
                                                select w).FirstOrDefault();
                rtfEtymology.Text = "";

                if (wordDefinition != null)
                    rtfEtymology.Text = wordDefinition.Etymology;
            }

            //Google Phrase
            {
                List<GooglePhrase> wordDefinition = (from w in _entities.GooglePhrases
                                                     where w.GreWord.Word == word
                                                     select w).ToList();
                textGooglePhrase.Text = "";
                foreach (GooglePhrase mnemonic in wordDefinition)
                {
                    textGooglePhrase.Text += mnemonic.EnglishPhrase + ": " + mnemonic.BengaliPhrase + "\r\n";
                }
            }

            //WordNet Definitions
            {
                List<GreWordDefinition> greWordDefinitions = (from w in _entities.GreWordDefinitions
                                                              where w.GreWord.Word == word
                                                              select w).ToList();
                rtfWordnetDefinitions.Text = "";
                foreach (GreWordDefinition definition in greWordDefinitions)
                {
                    Font f12N = new Font(rtfWordnetDefinitions.SelectionFont.FontFamily, 12.0f);
                    Font f12B = new Font(rtfWordnetDefinitions.SelectionFont.FontFamily, 12.0f, FontStyle.Bold);
                    Font f12I = new Font(rtfWordnetDefinitions.SelectionFont.FontFamily, 12.0f, FontStyle.Italic);
                    Font f10B = new Font(rtfWordnetDefinitions.SelectionFont.FontFamily, 10.0f, FontStyle.Bold);

                    rtfWordnetDefinitions.SelectionFont = f12N;
                    rtfWordnetDefinitions.AppendText(definition.Serial + ".");

                    rtfWordnetDefinitions.SelectionFont = f10B;
                    rtfWordnetDefinitions.AppendText(" (" + definition.PartsOfSpeech + ") ");

                    rtfWordnetDefinitions.SelectionFont = f12B;
                    rtfWordnetDefinitions.SelectionColor = Color.DarkBlue;
                    rtfWordnetDefinitions.AppendText(definition.SimilarWords + "\n");
                    rtfWordnetDefinitions.SelectionColor = Color.Black;

                    if (!string.IsNullOrEmpty(definition.Definitions))
                    {
                        rtfWordnetDefinitions.SelectionFont = f12N;
                        rtfWordnetDefinitions.AppendText(definition.Definitions + "\n");
                    }
                    if (!string.IsNullOrEmpty(definition.Sentences))
                    {
                        rtfWordnetDefinitions.SelectionFont = f12I;
                        rtfWordnetDefinitions.SelectionColor = Color.FromArgb(0, 100, 100, 100);
                        rtfWordnetDefinitions.AppendText(definition.Sentences + "\n");
                        rtfWordnetDefinitions.SelectionColor = Color.Black;
                    }
                    rtfWordnetDefinitions.AppendText("\n");
                }

                rtfWordnetDefinitions.SelectionStart = 0;
            }

            {
                List<GreWordSynonym> greWordDefinitions = (from w in _entities.GreWordSynonyms
                                                           where w.GreWord.Word == word
                                                           select w).ToList();
                rtfWordnetSynonyms.Text = "";
                foreach (GreWordSynonym definition in greWordDefinitions)
                {
                    Font f12N = new Font(rtfWordnetSynonyms.SelectionFont.FontFamily, 12.0f);
                    Font f12B = new Font(rtfWordnetSynonyms.SelectionFont.FontFamily, 12.0f, FontStyle.Bold);
                    Font f12I = new Font(rtfWordnetSynonyms.SelectionFont.FontFamily, 12.0f, FontStyle.Italic);
                    Font f10B = new Font(rtfWordnetSynonyms.SelectionFont.FontFamily, 10.0f, FontStyle.Bold);

                    rtfWordnetSynonyms.SelectionFont = f12N;
                    rtfWordnetSynonyms.AppendText(definition.Serial + ".");

                    rtfWordnetSynonyms.SelectionFont = f10B;
                    rtfWordnetSynonyms.AppendText(" (" + definition.PartsOfSpeech + ") ");

                    rtfWordnetSynonyms.SelectionFont = f12B;
                    rtfWordnetSynonyms.SelectionColor = Color.DarkBlue;
                    rtfWordnetSynonyms.AppendText(definition.SimilarWords + "\n");
                    rtfWordnetSynonyms.SelectionColor = Color.Black;

                    if (!string.IsNullOrEmpty(definition.Synonyms))
                    {
                        rtfWordnetSynonyms.SelectionFont = f10B;
                        rtfWordnetSynonyms.AppendText("Synonym: ");

                        rtfWordnetSynonyms.SelectionFont = f12N;
                        rtfWordnetSynonyms.AppendText(definition.Synonyms + "\n");
                    }

                    if (!string.IsNullOrEmpty(definition.Antonyms))
                    {
                        rtfWordnetSynonyms.SelectionFont = f10B;
                        rtfWordnetSynonyms.AppendText("Antonym: ");

                        rtfWordnetSynonyms.SelectionFont = f12N;
                        rtfWordnetSynonyms.AppendText(definition.Antonyms + "\n");
                    }

                    rtfWordnetSynonyms.AppendText("\n");
                }
                rtfWordnetSynonyms.SelectionStart = 0;
            }
        }
        private void LoadWord(string word, string hardness, int index)
        {
            try
            {
                this.Text = string.Format("Currently Studying #{1}: {0}", word, index);

                labelWord.Text = word.ToUpper();
                LoadWordInformation(word, true);

                int i = Convert.ToInt32(hardness);
                wordHardness.Rating = i;
            }
            catch { }
        }

        private void DeleteWord(string word)
        {
            try
            {
                long listNameId = Convert.ToInt64(comboList.SelectedValue);

                if (listNameId != 0)
                {
                    var words = (from w in _entities.ListedWords
                                 where w.ListName.Id == listNameId && w.GreWord.Word == word
                                 select w).ToList();


                    if (words.Count > 0)
                    {
                        _entities.DeleteObject(words.First());
                        _entities.SaveChanges();
                    }
                }
                else
                {
                    var affineWords = (from w in _entities.GreWordAffinities
                                       where w.GreWord1.Word == word
                                       select w).ToList();

                    foreach (var w in affineWords)
                    {
                        _entities.DeleteObject(w);
                    }

                    var words = (from w in _entities.ListedWords
                                 where w.GreWord.Word.Equals(word)
                                 select w.GreWord).ToList();

                    if (words.Count > 0)
                    {
                        _entities.DeleteObject(words.First());
                        _entities.SaveChanges();
                    }

                }

            }
            catch (Exception exp)
            {
                Console.Write(exp.StackTrace);
            }
        }
        private void DeleteSelectedList()
        {
            long listNameId = Convert.ToInt64(comboList.SelectedValue);
            try
            {
                if (listNameId != 0)
                {
                    var words = (from w in _entities.ListNames
                                 where w.Id == listNameId
                                 select w).ToList();


                    if (words.Count > 0)
                    {
                        _entities.DeleteObject(words.First());
                        _entities.SaveChanges();
                    }

                    comboList.Items.Remove(comboList.SelectedItem);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("List Delete Problem:\n" + exception.Message, "Deletion Problem");
            }

            LoadWordList();
        }
        private void SetHardness(int level)
        {
            try
            {
                foreach (ListViewItem item in wordsDataListView.SelectedItems)
                {
                    string word = item.Text;
                    GreWord greword = (from w in _entities.GreWords
                                       where w.Word == word
                                       select w).FirstOrDefault();

                    greword.Hardness = level;
                    _entities.SaveChanges();


                    item.SubItems[1].Text = greword.Hardness + "";
                    wordsDataListView.EnsureVisible(item.Index);

                    item.Font = greword.Hardness > 1 ? new Font(wordsDataListView.Font, FontStyle.Bold) : new Font(wordsDataListView.Font, FontStyle.Regular);
                    item.ForeColor = _hardnessForeground[greword.Hardness];
                    item.BackColor = _hardnessBackground[greword.Hardness];
                }
                wordsDataListView.Focus();
            }
            catch { }
        }


        private void Remembered()
        {
            UpdateRememberCount(1, 0);
        }
        private void Forgotten()
        {
            UpdateRememberCount(0, 1);
        }
        private void UpdateRememberCount(int countRemember, int countForgot)
        {
            try
            {
                foreach (ListViewItem item in wordsDataListView.SelectedItems)
                {
                    string word = item.Text;
                    GreWord greword = (from w in _entities.GreWords
                                       where w.Word == word
                                       select w).FirstOrDefault();

                    greword.Forgotten += countForgot;
                    greword.Remembered += countRemember;
                    _entities.SaveChanges();

                    item.SubItems[2].Text = greword.RememberPercentile;
                }
                wordsDataListView.Focus();
            }
            catch { }
        }
        #endregion

        #region Text Effects
        private FontStyle MakeFontStyle(bool bold, bool italic, bool underline, bool strike)
        {
            FontStyle fs = FontStyle.Regular;
            if (bold)
                fs = fs | FontStyle.Bold;
            if (italic)
                fs = fs | FontStyle.Italic;
            if (underline)
                fs = fs | FontStyle.Underline;
            if (strike)
                fs = fs | FontStyle.Strikeout;
            return fs;
        }

        private void MakeBold()
        {
            FontStyle fs = MakeFontStyle(!rtfComment.SelectionFont.Bold, rtfComment.SelectionFont.Italic, rtfComment.SelectionFont.Underline, rtfComment.SelectionFont.Strikeout);
            Font newFont = new Font(rtfComment.SelectionFont, fs);
            rtfComment.SelectionFont = newFont;
        }

        private void MakeItalic()
        {
            FontStyle fs = MakeFontStyle(rtfComment.SelectionFont.Bold, !rtfComment.SelectionFont.Italic, rtfComment.SelectionFont.Underline, rtfComment.SelectionFont.Strikeout);
            Font newFont = new Font(rtfComment.SelectionFont, fs);
            rtfComment.SelectionFont = newFont;
        }

        private void MakeUnderline()
        {
            FontStyle fs = MakeFontStyle(rtfComment.SelectionFont.Bold, rtfComment.SelectionFont.Italic, !rtfComment.SelectionFont.Underline, rtfComment.SelectionFont.Strikeout);
            Font newFont = new Font(rtfComment.SelectionFont, fs);
            rtfComment.SelectionFont = newFont;
        }

        private void MakeStrikethrough()
        {
            FontStyle fs = MakeFontStyle(rtfComment.SelectionFont.Bold, rtfComment.SelectionFont.Italic, rtfComment.SelectionFont.Underline, !rtfComment.SelectionFont.Strikeout);
            Font newFont = new Font(rtfComment.SelectionFont, fs);
            rtfComment.SelectionFont = newFont;
        }

        private void SetFontSizeAsIncrement(float increment)
        {
            try
            {
                SetFontSize(rtfComment.SelectionFont.Size + increment);
            }
            catch { }
        }

        private void SetFontSize(float fontsize)
        {
            try
            {
                rtfComment.SelectionFont = new Font(rtfComment.SelectionFont.FontFamily, (float)(fontsize), MakeFontStyle(rtfComment.SelectionFont.Bold, rtfComment.SelectionFont.Italic, rtfComment.SelectionFont.Underline, rtfComment.SelectionFont.Strikeout));
            }
            catch { }
        }

        private void SetCommentFont(Font font)
        {
            font = new Font(font.FontFamily, rtfComment.SelectionFont.Size, MakeFontStyle(rtfComment.SelectionFont.Bold, rtfComment.SelectionFont.Italic, rtfComment.SelectionFont.Underline, rtfComment.SelectionFont.Strikeout));
            if (rtfComment.SelectedText.Length == 0)
            {
                rtfComment.Font = font;
            }
            else
            {
                rtfComment.SelectionFont = font;
            }
        }
        private void SetCommentColor(object sender)
        {
            rtfComment.SelectionColor = ((ToolStripMenuItem)sender).ForeColor;
        }

        private void SetCommentBackgroundColor(object sender)
        {
            rtfComment.SelectionBackColor = ((ToolStripMenuItem)sender).BackColor;
        }

        #endregion

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveComment(_currentWord);
        }

        private void GREWordStudyForm_Load(object sender, EventArgs e)
        {
            textBanglaDictionary.Text = Properties.Settings.Default.BengaliDictionaryPath;

            toolStripWebSites.ImageList = imageList1;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                long listNameId = Convert.ToInt64(comboList.SelectedValue);
                List<GreWord> words = (from w in _entities.ListedWords
                                       where w.ListName.Id == listNameId
                                       orderby w.GreWord.Word
                                       select w.GreWord).ToList();

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);

                    foreach (var greWord in words)
                    {
                        streamWriter.WriteLine(greWord.Word);
                    }

                    streamWriter.Close();
                }
            }
            finally
            {

            }
        }

        private void rtfComment_TextChanged(object sender, EventArgs e)
        {
            _isCommentDirty = true;
        }


        private void ResetWebBrowsers()
        {
            var wurls = (from url in _entities.WebUrls
                         orderby url.Priority
                         select url).ToArray();

            toolStripWebSites.Items.Clear();
            _webUrls.Clear();

            foreach (WebUrl url in wurls)
            {
                if (!_webUrls.ContainsKey(url.WebTitle))
                {
                    _webUrls.Add(url.WebTitle, url);

                    ToolStripButton button = new ToolStripButton
                    {
                        Text = url.WebTitle,
                        DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
                        ImageIndex = url.ImageIndex
                    };


                    toolStripWebSites.Items.Add(button);
                    button.Click += buttonBrowseWord_Click;
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GREWordCollectorForm greWordCollector = new GREWordCollectorForm();
            greWordCollector.Show(this);
        }

        private void singWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleWordCollectorForm form = new SingleWordCollectorForm();
            form.Show(this);
        }

        private void copyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyImage();
        }

        private void buttonCopyImage_Click(object sender, EventArgs e)
        {
            CopyImage();
        }

        private void CopyImage()
        {
            try
            {
                Clipboard.SetImage(pictureBoxBanglaDictionary.Image);
            }
            catch
            {
            }
        }

        private void NavigateTo(string title, string address, int iconindex = 0)
        {
            if (openInDefaultBrowserToolStripMenuItem.Checked)
            {
                new ShellExecute() { Path = address, Verb = ShellExecute.OpenFile }.Execute();
            }
            else
            {
                MaxBrowser mb = new MaxBrowser(address);
                Crownwood.DotNetMagic.Controls.TabPage newPage = new Crownwood.DotNetMagic.Controls.TabPage(title, mb,
                                                                                                            iconindex) { Selected = true };

                if (tabbedGroupsWebSites.ActiveLeaf != null)
                {
                    tabbedGroupsWebSites.ActiveLeaf.TabPages.Add(newPage);
                    mb.Navigate(address);
                }
            }
        }


        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NavigateTo(toolStripTextBox1.Text, Properties.Settings.Default.GoogleSearch + toolStripTextBox1.Text);
            }
        }


        private void tsBold_Click(object sender, EventArgs e)
        {
            MakeBold();
        }

        private void tsItalic_Click(object sender, EventArgs e)
        {
            MakeItalic();
        }

        private void tsUnderline_Click(object sender, EventArgs e)
        {
            MakeUnderline();
        }

        private void tsStrikethrough_Click(object sender, EventArgs e)
        {
            MakeStrikethrough();
        }

        private void tsFontSegoe_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontSegoe.Font);
        }

        private void tsFontPalatino_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontPalatino.Font);
        }
        private void tsFontCandara_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontCandara.Font);
        }

        private void tsFontCorbel_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontCorbel.Font);
        }

        private void tsFontVrinda_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontVrinda.Font);
        }

        private void tsFontBangla_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontBangla.Font);
        }

        private void tsFontIncrease_Click(object sender, EventArgs e)
        {
            SetFontSizeAsIncrement((float)4.0);
        }

        private void tsFontDecrease_Click(object sender, EventArgs e)
        {
            SetFontSizeAsIncrement((float)-4.0);
        }



        private void tsColorRed_Click(object sender, EventArgs e)
        {
            SetCommentColor(sender);
        }

        private void tsGreen_Click(object sender, EventArgs e)
        {
            SetCommentColor(sender);
        }

        private void tsBlue_Click(object sender, EventArgs e)
        {
            SetCommentColor(sender);
        }

        private void tsNormalColor_Click(object sender, EventArgs e)
        {
            SetCommentColor(sender);
            SetCommentBackgroundColor(sender);
        }

        private void tsYellowBackground_Click(object sender, EventArgs e)
        {
            SetCommentBackgroundColor(sender);
        }

        private void tsLightGreenBackground_Click(object sender, EventArgs e)
        {
            SetCommentBackgroundColor(sender);
        }

        private void tsDictionaryImage_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetImage(pictureBoxBanglaDictionary.Image);
                rtfComment.Paste();
                _isCommentDirty = true;
            }
            catch
            {

            }
        }

        private void tsSaveComment_Click(object sender, EventArgs e)
        {
            SaveComment(_currentWord);
        }

        private void tsRemembered_Click(object sender, EventArgs e)
        {
            Remembered();
        }

        private void tsForgot_Click(object sender, EventArgs e)
        {
            Forgotten();
        }

        private void wordRating_RatingChanged(object sender, ThirstyCrow.WinForms.Controls.RatingChangedEventArgs e)
        {
            SetHardness(e.NewRating);
        }



        private void tsFontSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetFontSize((float)Convert.ToDouble(tsFontSize.Text));
            }
            catch { }
        }

        private void tabbedGroupsWebSites_PageCloseRequest(Crownwood.DotNetMagic.Controls.TabbedGroups tg, Crownwood.DotNetMagic.Controls.TGCloseRequestEventArgs e)
        {
            try
            {
                e.TabPage.Dispose();
            }
            catch { }

        }

        private void stickyNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StickyNoteForm snf = new StickyNoteForm();
            snf.TopMost = true;
            snf.Show(this);
        }


        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                TabPageCollection pages = tabbedGroupsWebSites.ActiveLeaf.TabPages;
                foreach (Crownwood.DotNetMagic.Controls.TabPage tabPage in pages)
                {
                    tabPage.Dispose();
                }
                tabbedGroupsWebSites.ActiveLeaf.TabPages.Clear();
            }
            catch
            {
            }
        }


        OpenFileDialog excelOfd = new OpenFileDialog();
        private void excelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excelOfd.Filter = "Excel|*.xlsx";
            excelOfd.FileName = Properties.Settings.Default.ExcelPath;
            if (excelOfd.ShowDialog(this) == DialogResult.OK)
            {
                Properties.Settings.Default.ExcelPath = excelOfd.FileName;
                Properties.Settings.Default.Save();

                ShellExecute execute = new ShellExecute
                                                    {
                                                        Verb = ShellExecute.OpenFile,
                                                        Path = excelOfd.FileName
                                                    };
                execute.Execute();
            }
        }

        OpenFileDialog pdfOfd = new OpenFileDialog();


        private void pdfFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfOfd.Filter = "PDF|*.pdf";
            pdfOfd.FileName = Properties.Settings.Default.PdfPath;
            if (pdfOfd.ShowDialog(this) == DialogResult.OK)
            {
                Properties.Settings.Default.PdfPath = pdfOfd.FileName;
                Properties.Settings.Default.Save();

                ShellExecute execute = new ShellExecute
                {
                    Verb = ShellExecute.OpenFile,
                    Path = pdfOfd.FileName
                };
                execute.Execute();
            }
        }

        private void stickyBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new StickyBrowser() { TopMost = true }).Show(this);
        }

        private void tsPaste_Click(object sender, EventArgs e)
        {
            rtfComment.Paste();
            _isCommentDirty = true;
        }

        private void wordsDataListView_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            GreWord w = (GreWord)e.Model;
            e.Item.ForeColor = _hardnessForeground[w.Hardness];
            e.Item.BackColor = _hardnessBackground[w.Hardness];
            e.Item.Font = w.Hardness > 0 ? new Font(wordsDataListView.Font, FontStyle.Bold) : new Font(wordsDataListView.Font, FontStyle.Regular);
        }

        private void wordsDataListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wordsDataListView.SelectedItem != null)
                LoadWord(wordsDataListView.SelectedItem.Text, wordsDataListView.SelectedItem.SubItems[1].Text, wordsDataListView.SelectedIndex);
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (wordsDataListView.SelectedItem != null)
            {
                if (MessageBox.Show(this, "Are you sure to delete these words?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (ListViewItem selectedItem in wordsDataListView.SelectedItems)
                    {
                        DeleteWord(selectedItem.Text);
                        wordsDataListView.Items.Remove((ListViewItem)selectedItem);
                    }

                }
            }
        }

        private void deleteSelectedListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedList();
        }

        private void fetchSelectedWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordsDataListView.SelectedItem != null)
            {
                SingleWordCollectorForm form = new SingleWordCollectorForm(comboList.Text,
                                                                           wordsDataListView.SelectedItem.Text);
                form.Show(this);
            }
        }





        private void tsPasteImage_Click(object sender, EventArgs e)
        {
            try
            {
                picBmp.Image = Clipboard.GetImage();
            }
            catch
            {
            }
        }

        private void tsScale_Click(object sender, EventArgs e)
        {
            ZoomFactor((float)(float.Parse(txtScale.Text) / 100.0), picBmp.Image);
        }

        private void tsCopyImage_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(picBmp.Image);
        }

        private void tsPictureClear_Click(object sender, EventArgs e)
        {
            picBmp.Image = null;
        }


        #region Mouse

        private void picBmp_MouseMove(object sender, MouseEventArgs e)
        {
            if (_captured)
            {
                tsTextX2.Text = e.X + "";
                tsTextY2.Text = e.Y + "";
                _pEnd = e.Location;

                //tsextHeight.Text = Math.Abs(pStart.Y - pEnd.Y) + "";
                //textWidth.Text = Math.Abs(pStart.X - pEnd.X) + "";

                picBmp.Refresh();
            }
        }

        private void picBmp_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_captured)
            {
                tsTextX1.Text = e.X + "";
                tsTextY1.Text = e.Y + "";
                _pStart = e.Location;


                _captured = true;
                //SetCapture(this.Handle);
            }
        }

        private void picBmp_MouseUp(object sender, MouseEventArgs e)
        {
            _captured = false;
            //ReleaseCapture(this.Handle);
        }

        private void picBmp_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.BlueViolet), GetCroppedRectangle());
        }

        private void tsCropAndScale_Click(object sender, EventArgs e)
        {
            _pStart.X = int.Parse(tsTextX1.Text);
            _pStart.Y = int.Parse(tsTextY1.Text);

            _pEnd.X = int.Parse(tsTextX2.Text);
            _pEnd.Y = int.Parse(tsTextY2.Text);

            //textHeight.Text = Math.Abs(pStart.Y - pEnd.Y) + "";
            //textWidth.Text = Math.Abs(pStart.X - pEnd.X) + "";

            picBmp.Refresh();
            ZoomFactor((float)(float.Parse(txtScale.Text) / 100.0), DrawAlbumArt());
        }

        #region Image Operation
        private void ZoomFactor(float factor, Image resultBitma)
        {
            Rectangle cropRect = new Rectangle(0, 0, resultBitma.Width, resultBitma.Height);
            Bitmap croppedBitmap = new Bitmap((int)(cropRect.Width * factor), (int)(cropRect.Height * factor));
            Graphics g = Graphics.FromImage(croppedBitmap);
            g.ScaleTransform(factor, factor);
            g.DrawImage(resultBitma, 0, 0, cropRect, GraphicsUnit.Pixel);
            g.Dispose();

            picBmp.Image = croppedBitmap;

        }

        private Bitmap DrawAlbumArt()
        {

            Bitmap bmp = (Bitmap)picBmp.Image;

            if (bmp != null)
            {


                Rectangle cropRect = GetCroppedRectangle();
                Bitmap croppedBitmap = new Bitmap(cropRect.Width, cropRect.Height);

                Graphics g = Graphics.FromImage(croppedBitmap);
                g.DrawImage(bmp, 0, 0, cropRect, GraphicsUnit.Pixel);
                g.Dispose();

                picBmp.Image = croppedBitmap;

                return croppedBitmap;

            }
            return null;
        }

        private Rectangle GetCroppedRectangle()
        {
            Rectangle r = new Rectangle();

            if (_pStart.X > _pEnd.X)
            {
                r.X = _pEnd.X;
                r.Width = _pStart.X - _pEnd.X + 1;
            }
            else
            {
                r.X = _pStart.X;
                r.Width = _pEnd.X - _pStart.X + 1;
            }

            if (_pStart.Y > _pEnd.Y)
            {
                r.Y = _pEnd.Y;
                r.Height = _pStart.Y - _pEnd.Y + 1;
            }
            else
            {
                r.Y = _pStart.Y;
                r.Height = _pEnd.Y - _pStart.Y + 1;
            }
            return r;
        }

        #endregion
        #endregion


        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openGoogleSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShellExecute execute = new ShellExecute { Path = "http://google.com/search?q=" + _currentWord, Verb = ShellExecute.OpenFile };
            execute.Execute();
        }

        private void openInDefaultBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openInDefaultBrowserToolStripMenuItem.Checked = !openInDefaultBrowserToolStripMenuItem.Checked;
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new WebUrlsForm(_entities);
            form.ShowDialog(this);

            ResetWebBrowsers();
        }



    }
}