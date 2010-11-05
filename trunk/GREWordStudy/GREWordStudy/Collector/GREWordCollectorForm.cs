using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using GREWordStudy.Model;
using System.IO;

namespace GREWordStudy.Collector
{
    public partial class GREWordCollectorForm : Form
    {

        //gredbEntities entities;
        //ParserHelper parser;


        public GREWordCollectorForm()
        {
            InitializeComponent();

            //entities = new gredbEntities();
            //parser = new ParserHelper(entities);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long listNameId = -1;
            var entities = new gredbEntities();


            var list = entities.ListNames.Where(o => o.Name.ToLower().Equals(comboBoxList.Text.Trim().ToLower())).Select(o => o).FirstOrDefault();
            if (list == null)
            {

                ListName listName = new ListName();
                listName.Name = comboBoxList.Text.Trim();
                entities.AddToListNames(listName);
                entities.SaveChanges();

                listNameId = listName.Id;
            }
            else
            {
                listNameId = list.Id;
            }

            //if (textSetName.Text.Trim().Length > 0)
            //{
            //    ListName listName = new ListName();
            //    listName.Name = textSetName.Text.Trim();
            //    entities.AddToListNames(listName);
            //    entities.SaveChanges();

            //    listNameId = listName.Id;
            //}
            //else
            //{
            //    listNameId = Convert.ToInt64(comboBox1.SelectedValue);
            //}


            String str = Regex.Replace(textBox1.Text, "([0-9\\.]+|<.+?>)", "");
            Regex regex = new Regex("([^\\s]+)");

            ListName ln = (from n in entities.ListNames
                           where n.Id == listNameId
                           select n).FirstOrDefault();

            try
            {
                MatchCollection mc = regex.Matches(str);

                foreach (Match m in mc)
                {
                    try
                    {
                        GreWord word;
                        word = (from w in entities.GreWords
                                where w.Word.ToLower() == m.Value.ToLower()
                                select w).FirstOrDefault();

                        if (word == null)
                        {
                            word = new GreWord()
                            {
                                Word = m.Value.ToLower(),
                            };
                            entities.AddToGreWords(word);
                            entities.SaveChanges();
                        }

                        ListedWord lw;
                        lw = (from w in entities.ListedWords
                              where w.ListName.Id == ln.Id && w.GreWord.Word == word.Word
                              select w).FirstOrDefault();

                        if (lw == null)
                        {
                            lw = new ListedWord()
                            {
                                GreWord = word,
                                ListName = ln
                            };
                            entities.AddToListedWords(lw);
                            entities.SaveChanges();
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                }
                entities.Connection.Close();
            }
            catch (Exception exp)
            {
            }
        }


        private void buttonFetchMnemonicDictionary_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };


            workerThread = new Thread(new ThreadStart(parser.FetchMnemonicDictionary));
            workerThread.IsBackground = true;
            workerThread.Start();
        }



        Thread workerThread;
        private void buttonFetchGoogleDictionary_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };

            workerThread = new Thread(new ThreadStart(parser.FetchGoogleDictionary));
            workerThread.IsBackground = true;
            workerThread.Start();

        }

        #region Clear
        private void buttonGoogleSynonym_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };

            workerThread = new Thread(new ThreadStart(parser.ParseGoogleSynonym));
            workerThread.IsBackground = true;
            workerThread.Start();
        }
        private void buttonMnemonicDictionarySynonym_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };

            workerThread = new Thread(new ThreadStart(parser.ParseMnemonicDictionarySynonym));
            workerThread.IsBackground = true;
            workerThread.Start();
        }
        #endregion

        #region MakeJ2ME Data
        private void button6_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            GreWord[] greWords = (from w in entities.GreWords
                                  //where w.list_name == comboBox1.Text
                                  orderby w.Word
                                  select w).ToArray();

            String strGre = "";
            foreach (GreWord w in greWords)
            {
                strGre += w.Word + "\r\n";
                strGre += getGoogleSynonym(w) + "\r\n";
                strGre += getMnemonics(w) + "\r\n";
                strGre += "\r\n";
                strGre += "\r\n";
            }

            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(strGre);
                sw.Close();
            }

        }
        String getGoogleSynonym(GreWord gw)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            String synnonym = "";

            List<GoogleSynonym> gSyn = (from w in entities.GoogleSynonyms
                                        where w.GreWord.Word == gw.Word
                                        select w).ToList();
            foreach (GoogleSynonym gs in gSyn)
                synnonym += gs.Synonym + ", ";

            return synnonym;
        }
        String getMnemonics(GreWord gw)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            String mnemonics = "";

            List<FeaturedMnemonic> mSelected = (from w in entities.FeaturedMnemonics
                                                where w.GreWord.Word == gw.Word
                                                select w).ToList();
            foreach (FeaturedMnemonic ms in mSelected)
                mnemonics += "##:" + ms.Mnemonic + ", ";

            List<BasicMnemonic> mAll = (from w in entities.BasicMnemonics
                                        where w.GreWord.Word == gw.Word
                                        select w).ToList();
            foreach (BasicMnemonic ms in mAll)
                mnemonics += "#" + ms.Helpful + "," + ms.NotHelpful + ":" + ms.Mnemonic + ", ";

            mnemonics = Clean(mnemonics, @"\(Tag.+?\)");
            mnemonics = Clean(mnemonics);


            return mnemonics;
        }
        String Clean(String str, String pattern)
        {
            Regex rClean = new Regex(pattern);

            MatchCollection mc = rClean.Matches(str);
            foreach (Match m in mc)
            {
                str = str.Replace(m.Value, " ");
            }
            return str;
        }
        String Clean(String str)
        {
            string resultString = null;
            try
            {
                resultString = Regex.Replace(str, @"[\s\n\t]+", new MatchEvaluator(ComputeReplacement));
            }
            catch (ArgumentException)
            {
                // Syntax error in the regular expression
            }

            return resultString;

        }
        public String ComputeReplacement(Match m)
        {
            return " ";
        }
        #endregion

        private void buttonEtymologyFetch_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };

            workerThread = new Thread(new ThreadStart(parser.FetchEtymology));
            workerThread.IsBackground = true;
            workerThread.Start();
        }

        private void buttonGooglePhrase_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };

            workerThread = new Thread(new ThreadStart(parser.ParseGooglePhrase));
            workerThread.IsBackground = true;
            workerThread.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };

            workerThread = new Thread(new ThreadStart(parser.ParseMnemonicDictionary));
            workerThread.IsBackground = true;
            workerThread.Start();
        }

        private void MnemonicsCollector_Load(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            comboBoxList.DataSource = (from w in entities.ListNames select w).ToList();
        }

        private void buttonAffinity_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);


            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };

            workerThread = new Thread(new ThreadStart(parser.ParseAffinity));
            workerThread.IsBackground = true;
            workerThread.Start();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            GreWord[] greWords = (from w in entities.GreWords
                                  where w.Hardness > 4
                                  orderby w.Hardness descending
                                  select w).ToArray();

            String strGre = "";
            foreach (GreWord w in greWords)
            {
                strGre += w.Word + "\r\n";
                strGre += getGoogleSynonym(w) + "\r\n";
                strGre += getMnemonics(w) + "\r\n";
                strGre += "\r\n";
                strGre += "\r\n";
            }

            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(strGre);
                sw.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            GreWord[] greWords = (from w in entities.GreWords
                                  where w.Hardness > 3
                                  orderby w.Hardness descending
                                  select w).ToArray();

            String strGre = "";
            foreach (GreWord w in greWords)
            {
                strGre += w.Word + "\t[ " + w.Hardness + " ]\r\n";
            }

            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(strGre);
                sw.Close();
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };

            workerThread = new Thread(new ThreadStart(parser.ParseGoogleBengali));
            workerThread.IsBackground = true;
            workerThread.Start();
        }

        private void buttonDefinitionsNet_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };

            workerThread = new Thread(new ThreadStart(parser.FetchDefinitionsNet));
            workerThread.IsBackground = true;
            workerThread.Start();
        }

        private void buttonSynonymsNet_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };

            workerThread = new Thread(new ThreadStart(parser.FetchSynonymsNet));
            workerThread.IsBackground = true;
            workerThread.Start();
        }

        private void buttonParseWordnetDefinitions_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };

            workerThread = new Thread(new ThreadStart(parser.ParseWordnetDefinitions));
            workerThread.IsBackground = true;
            workerThread.Start();
        }

        private void buttonParseWordnetSynonyms_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };

            workerThread = new Thread(new ThreadStart(parser.ParseWordnetSynonyms));
            workerThread.IsBackground = true;
            workerThread.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += (sender2, person) => this.Invoke((MethodInvoker)(() => textBox2.AppendText(person + "\r\n")));

            workerThread = new Thread(new ThreadStart(parser.ParseEtymology)) { IsBackground = true };
            workerThread.Start();
        }
    }
}
