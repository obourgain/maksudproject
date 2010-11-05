using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GREWordStudy.Model;
using System.Data.Objects;

namespace GREWordStudy.Collector
{
    class ParserHelper
    {

        // delegate declaration
        public delegate void LogMessage(object sender, string message);

        // event
        public event LogMessage OnLogMessage;

        private readonly gredbEntities _entities;
        public ParserHelper(gredbEntities db)
        {
            _entities = db;
        }
        #region Fetch Data
        public void FetchDefinitionsNet() { FetchDefinitionsNet(null); }
        public void FetchDefinitionsNet(string word)
        {
            const string baseurl = "http://www.definitions.net/definition/";
            var unfetched = new List<string>();

            if (string.IsNullOrEmpty(word))
            {
                unfetched = _entities.GreWords.Select(w => w.Word).Except(_entities.DefinitionsNetHtmls.Select(w => w.Word)).ToList();
            }
            else { unfetched.Add(word); }

            FireLogMessage(unfetched.Count + " unfetched words found");

            foreach (string uw in unfetched)
            {
                string data = null;
                if ((data = FetchHttpGet(baseurl, uw, "Definitions.net data for: ")) != null)
                    AddDefinitionsNetHtml(uw, data);
            }
        }

        public void FetchEtymology() { FetchEtymology(null); }
        public void FetchEtymology(string word)
        {
            const string baseurl = "http://www.etymonline.com/index.php?searchmode=none&search=";
            var unfetched = new List<string>();
            if (string.IsNullOrEmpty(word))
            {
                unfetched = _entities.GreWords.Select(w => w.Word).Except(_entities.EtymologyHtmls.Select(w => w.Word)).ToList();
            }
            else
            {
                unfetched.Add(word);
            }
            FireLogMessage(unfetched.Count + " unfetched words found");
            foreach (string uw in unfetched)
            {
                string data = null;
                if ((data = FetchHttpGet(baseurl, uw, "etymonline data for: ")) != null)
                    AddEtymologyHtml(uw, data);
            }
        }

        public void FetchGoogleDictionary() { FetchGoogleDictionary(null); }
        public void FetchGoogleDictionary(string word)
        {
            const string baseurl = "http://www.google.com/dictionary?aq=f&langpair=en|bn&hl=en&q=";
            var unfetched = new List<string>();
            if (string.IsNullOrEmpty(word))
            {
                unfetched = _entities.GreWords.Select(w => w.Word).Except(_entities.GoogleDictionaryHtmls.Select(w => w.Word)).ToList();
            }
            else
            {
                unfetched.Add(word);
            }
            FireLogMessage(unfetched.Count + " unfetched words found");
            foreach (string uw in unfetched)
            {
                string data = null;
                if ((data = FetchHttpGet(baseurl, uw, "Google Dictionary data for: ")) != null)
                    AddGoogleHtml(uw, data);
            }
        }

        public void FetchMnemonicDictionary() { FetchMnemonicDictionary(null); }
        public void FetchMnemonicDictionary(string word)
        {
            const string baseurl = "http://www.mnemonicdictionary.com/include/ajaxSearch.php?event=search&word=";
            var unfetched = new List<string>();
            if (string.IsNullOrEmpty(word))
            {
                unfetched = _entities.GreWords.Select(w => w.Word).Except(_entities.MnemonicsDictionaryHtmls.Select(w => w.Word)).ToList();
            }
            else
            {
                unfetched.Add(word);
            }
            FireLogMessage(unfetched.Count + " unfetched words found");
            foreach (string uw in unfetched)
            {
                string data = null;
                if ((data = FetchHttpGet(baseurl, uw, "MnemonicDictionary data for: ")) != null)
                    AddMnemonicsHtml(uw, data);
            }
        }

        public void FetchSynonymsNet() { FetchDefinitionsNet(null); }
        public void FetchSynonymsNet(string word)
        {
            const string baseurl = "http://www.synonyms.net/synonym/";
            var unfetched = new List<string>();
            if (string.IsNullOrEmpty(word))
            {
                unfetched = _entities.GreWords.Select(w => w.Word).Except(_entities.SynonymsNetHtmls.Select(w => w.Word)).ToList();
            }
            else
            {
                unfetched.Add(word);
            }
            FireLogMessage(unfetched.Count + " unfetched words found");
            foreach (string uw in unfetched)
            {
                string data = null;
                if ((data = FetchHttpGet(baseurl, uw, "Synonyms.net data for: ")) != null)
                    AddSynonymsNetHtml(uw, data);
            }

        }

        private string FetchHttpGet(string baseurl, string word, string message)
        {
            int retry = 0;
            FireLogMessage("START: " + message + word);

            HttpFetcher hf = new HttpFetcher(baseurl + word);
            string data = "";
            while (retry < 5)
            {
                data = hf.GetHttpHtml;

                if (data != null)
                    break;

                retry++;
                FireLogMessage("RETRY " + retry + " : " + message + word);

                Thread.Sleep(100);
                continue;
            }

            if (retry < 5)
            {
                FireLogMessage("SUCCESS: " + message + word);

                try
                {
                    return data;
                }
                catch (Exception exp)
                {
                    return null;
                }
            }
            else
            {
                FireLogMessage("FAILED: " + message + word);
                return null;
            }
        }
        #endregion


        private void AddDefinitionsNetHtml(string word, string data)
        {
            var sql = from w in _entities.DefinitionsNetHtmls
                      where w.Word.Equals(word)
                      select w;

            if (sql.Count() == 0)
            {
                DefinitionsNetHtml mh = new DefinitionsNetHtml() { Word = word, Html = data };
                _entities.AddToDefinitionsNetHtmls(mh);
                _entities.SaveChanges();
            }
            else
            {
                sql.First().Html = data;
                _entities.SaveChanges();
            }
        }
        private void AddEtymologyHtml(string word, string data)
        {
            var sql = from w in _entities.EtymologyHtmls
                      where w.Word.Equals(word)
                      select w;

            if (sql.Count() == 0)
            {
                var mh = new EtymologyHtml()
                {
                    Word = word,
                    Html = data
                };
                _entities.AddToEtymologyHtmls(mh);
                _entities.SaveChanges();
            }
            else
            {
                sql.First().Html = data;
                _entities.SaveChanges();
            }
        }
        private void AddGoogleHtml(string word, string data)
        {
            var sql = from w in _entities.GoogleDictionaryHtmls
                      where w.Word.Equals(word)
                      select w;

            if (sql.Count() == 0)
            {
                GoogleDictionaryHtml mh = new GoogleDictionaryHtml()
                {
                    Word = word,
                    Html = data
                };
                _entities.AddToGoogleDictionaryHtmls(mh);
                _entities.SaveChanges();
            }
            else
            {
                sql.First().Html = data;
                _entities.SaveChanges();
            }
        }
        private void AddMnemonicsHtml(string word, string data)
        {
            var allItems = _entities.MnemonicsDictionaryHtmls.ToList();

            var sql = from w in allItems
                      where w.Word.Equals(word)
                      select w;

            if (sql.Count() == 0)
            {
                MnemonicsDictionaryHtml mh = new MnemonicsDictionaryHtml()
                {
                    Word = word,
                    Html = data
                };
                _entities.AddToMnemonicsDictionaryHtmls(mh);
                _entities.SaveChanges();
            }
            else
            {
                sql.First().Html = data;
                _entities.SaveChanges();
            }
        }
        private void AddSynonymsNetHtml(string word, string data)
        {
            var e = _entities.EtymologyHtmls;
            var sql = from w in _entities.SynonymsNetHtmls
                      where w.Word.Equals(word)
                      select w;

            if (sql.Count() == 0)
            {
                SynonymsNetHtml mh = new SynonymsNetHtml()
                {
                    Word = word,
                    Html = data
                };
                _entities.AddToSynonymsNetHtmls(mh);
                _entities.SaveChanges();
            }
            else
            {
                sql.First().Html = data;
                _entities.SaveChanges();
            }
        }


        //Parsers


        public void ParseAffinity()
        {
            var words = (from w in _entities.GreWords
                         select w.Word).ToList();

            var done = (from w in _entities.GreWordAffinities
                        select w.GreWord.Word).ToList();
            words = words.Except(done).ToList();

            foreach (string word in words)
            {
                FireLogMessage("Processing Word: " + word);

                var greword = (from w in _entities.GreWords
                               where w.Word == word
                               select w).FirstOrDefault();

                var synonyms = (from w in _entities.GoogleSynonyms
                                where w.GreWord.Word == word
                                select w.Synonym).ToList();

                foreach (var synonym in synonyms)
                {
                    var present = (from w in _entities.GreWords
                                   where w.Word == synonym
                                   select w).FirstOrDefault();
                    if (present != null)
                    {
                        GreWordAffinity gwa = new GreWordAffinity()
                        {
                            GreWord = greword,
                            GreWord1 = present,
                            Affinity = 1
                        };

                        _entities.AddToGreWordAffinities(gwa);
                        _entities.SaveChanges();
                    }

                    //Secondary Relation...
                    var grewords2 = (from w in _entities.GoogleSynonyms
                                     where w.Synonym == synonym
                                     select w.GreWord).ToList();


                    foreach (var gword in grewords2)
                    {
                        if (gword.Word == greword.Word)
                            continue;

                        var present2 = (from w in _entities.GreWordAffinities
                                        where w.GreWord.Word == greword.Word && w.GreWord1.Word == gword.Word
                                        select w).FirstOrDefault();

                        if (present2 == null)
                        {
                            GreWordAffinity gwa = new GreWordAffinity()
                            {
                                GreWord = greword,
                                GreWord1 = gword,
                                Affinity = 2
                            };

                            _entities.AddToGreWordAffinities(gwa);
                            _entities.SaveChanges();
                        }
                    }
                }
            }
        }

        //1
        public void ParseEtymology()
        {
            List<EtymologyHtml> etymologyHtmls = (from w in _entities.EtymologyHtmls select w).ToList();
            foreach (EtymologyHtml etymologyHtml in etymologyHtmls)
            {
                ParseEtymology(etymologyHtml);
            }
        }
        public void ParseEtymology(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                ParseEtymology(_entities.EtymologyHtmls.Where(w => w.Word.Equals(word, StringComparison.CurrentCultureIgnoreCase)).Select(o => o).FirstOrDefault());
            }
        }
        private void ParseEtymology(EtymologyHtml html)
        {
            WordEtymology etymology = (_entities.WordEtymologies.Where(w => w.GreWord.Word == html.Word)).FirstOrDefault();
            if (etymology != null) return;

            Regex regex = new Regex("<dt.*?><a.*?>" + html.Word + "<.*?dt>.+?<dd.*?>(.+?)</dd>", RegexOptions.Singleline);
            Match match = regex.Match(html.Html);
            if (!match.Success) return;

            FireLogMessage("Adding Etymology for Word: " + html.Word);

            string setymology = null;
            setymology = match.Groups[1].Value;
            setymology = Regex.Replace(setymology, "<span.*?>(.+?)</span>", "$1", RegexOptions.Singleline);
            setymology = Regex.Replace(setymology, "<a.*?>(.+?)</a>", "$1", RegexOptions.Singleline);
            setymology = CleanText(setymology);

            etymology = new WordEtymology { GreWord = GetGreWord(html.Word), Etymology = setymology };
            _entities.AddToWordEtymologies(etymology);
            _entities.SaveChanges();
        }
        //2
        public void ParseGoogleBengali()
        {
            List<string> words = (_entities.GoogleDictionaryHtmls.Select(w => w.Word)).ToList();
            List<string> wordsSynonyms = (_entities.BengaliDefinitions.Select(w => w.GreWord.Word)).ToList();
            words = words.Except(wordsSynonyms).ToList();

            foreach (string word in words)
            {
                ParseGoogleBengali(word);
            }
        }
        public void ParseGoogleBengali(string word)
        {
            FireLogMessage("GoogleBengali for " + word);

            GreWord greWord = GetGreWord(word);
            GoogleDictionaryHtml gd = (_entities.GoogleDictionaryHtmls.Where(w => w.Word == word)).FirstOrDefault();
            if (gd == null) return;

            string text = gd.Html;
            Regex regexWord = new Regex(@"<div  class=""dct-em"">\s+<span class=""dct-tt"">(.+?)</span>", RegexOptions.Singleline | RegexOptions.IgnoreCase);

            MatchCollection meanings = regexWord.Matches(text);
            foreach (string def in from Match m in meanings select CleanText(m.Groups[1].Value))
            {
                UpdateGoogleBengaliWord(greWord, def);
            }
        }
        //3
        public void ParseGooglePhrase()
        {
            List<string> words = (_entities.GoogleDictionaryHtmls.Select(w => w.Word)).ToList();
            List<string> parsed = (_entities.GooglePhrases.Select(w => w.GreWord.Word)).ToList();
            List<string> unparsed = words.Except(parsed).ToList();

            foreach (string word in unparsed)
            {
                ParseGooglePhrase(word);
            }
        }
        public void ParseGooglePhrase(string word)
        {
            FireLogMessage("GooglePhrase Parsing " + word);

            try
            {
                string html = (_entities.GoogleDictionaryHtmls.Where(w => w.Word == word).Select(w => w.Html)).FirstOrDefault();

                Regex ul = new Regex("<ul class=\"rlt-snt\">(.*?)</ul>", RegexOptions.Singleline);
                string list = ul.Match(html).Groups[1].Value;
                Regex li = new Regex("<li>.+?<a.+?>(.+?)</a></b>.+?</div>(.+?)</li>", RegexOptions.Singleline);

                MatchCollection mc = li.Matches(list);
                GreWord gw = GetGreWord(word);

                foreach (Match m in mc)
                {
                    string en = m.Groups[1].Value;
                    string bn = m.Groups[2].Value;

                    bn = bn.Replace("\n", "").Replace("<b>", "").Replace("</b>", "").Replace("&nbsp;", " ");

                    UpdateGooglePhrase(gw, en, bn);
                }
            }
            catch (Exception exp)
            {
            }
        }
        //4
        public void ParseGoogleSynonym()
        {
            List<string> words = (from w in _entities.GreWords
                                  select w.Word).ToList();

            List<string> parsed = (from w in _entities.GoogleSynonyms
                                   select w.GreWord.Word).ToList();

            words = words.Except(parsed).ToList();

            foreach (string word in words)
            {
                this.ParseGoogleSynonym(word);
            }
        }
        public void ParseGoogleSynonym(string word)
        {
            GreWord greWord = GetGreWord(word);
            GoogleDictionaryHtml gd = (_entities.GoogleDictionaryHtmls.Where(w => w.Word == word)).FirstOrDefault();

            FireLogMessage("GoogleSynonym Parsing " + word);

            if (gd == null) return;

            string text = gd.Html;
            Regex regexWord = new Regex(@"<a href=""/dictionary\?hl=en&q=.+?&sl=en&tl=bn&oi=dict_lk"">(.+?)</a>");

            MatchCollection meanings = regexWord.Matches(text);
            foreach (Match m in meanings)
            {
                string def = CleanText(m.Groups[1].Value);
                UpdateGoogleSynonym(greWord, def);
            }
        }
        //5
        public void ParseMnemonicDictionary()
        {
            List<string> words = (from w in _entities.MnemonicsDictionaryHtmls
                                  select w.Word).ToList();

            List<string> wordsParsedBasic = (from w in _entities.BasicMnemonics
                                             select w.GreWord.Word).ToList();
            var wordsParsedSelected = (from w in _entities.FeaturedMnemonics
                                       select w.GreWord.Word).ToList();
            var wordsParsedDefinition = (from w in _entities.WordDefinitions
                                         select w.GreWord.Word).ToList();

            words = words.Except(wordsParsedBasic).ToList();
            words = words.Except(wordsParsedSelected).ToList();
            words = words.Except(wordsParsedDefinition).ToList();

            foreach (string word in words)
            {
                ParseMnemonicDictionary(word);
            }

        }
        public void ParseMnemonicDictionary(string word)
        {
            FireLogMessage("Parsing Mnemonics for: " + word);

            GreWord greWord = GetGreWord(word);
            MnemonicsDictionaryHtml gd = (_entities.MnemonicsDictionaryHtmls.Where(w => w.Word == word)).FirstOrDefault();
            if (gd == null)
                return;

            string text = gd.Html;
            Regex regexWordUl = new Regex("<ul class='wordnet'>(.+?)</ul>", RegexOptions.Singleline);
            Regex regexWordLi = new Regex("<li>(.+?)</li>", RegexOptions.Singleline);


            Regex regexImage = new Regex("<div class=\"floatright\">.+?<img src=\"(.+?)\".+?</div>", RegexOptions.Singleline);
            Regex regexTag = new Regex("<div class=\"floatleft\">(.+?)</div>", RegexOptions.Singleline);

            Match meaningMatch = regexWordUl.Match(text);
            if (meaningMatch.Success)
            {
                MatchCollection meanings = regexWordLi.Matches(meaningMatch.Value);

                foreach (Match m in meanings)
                {
                    string tag = "";
                    string img = "";

                    string def = CleanText(m.Groups[1].Value);
                    MatchCollection mci = regexImage.Matches(def);
                    foreach (Match mi in mci)
                    {
                        Match mt = regexTag.Match(def);

                        img = mi.Groups[1].Value;
                        tag = mt.Groups[1].Value.Replace("\r\n", "");

                        def = regexImage.Replace(def, "");
                        def = regexTag.Replace(def, "");
                        def = def.Replace("<div class='clear'></div>", "");
                    }

                    WordDefinition wordDefinition = new WordDefinition { Definition = def, Image = img, Tag = tag, GreWord = greWord, };
                    _entities.AddToWordDefinitions(wordDefinition);
                    _entities.SaveChanges();
                }
            }


            Regex regexSelectedMnemonicDiv = new Regex("<div class='mnemonics'>(.+?)</div>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            Regex regexSelectedMnemonicLi = new Regex(@"<li><p>(.+?)</p><p>\s+added by.+?</li>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            Match selectedMnemonic = regexSelectedMnemonicDiv.Match(text);
            if (selectedMnemonic.Success)
            {
                MatchCollection selectedMnemonics = regexSelectedMnemonicLi.Matches(selectedMnemonic.Groups[1].Value);

                foreach (Match m in selectedMnemonics)
                {
                    //listSelectedMnemonics.Items.Add(clarify(m.Groups[1].Value));
                    string def = CleanText(m.Groups[1].Value);
                    FeaturedMnemonic mnemonics = new FeaturedMnemonic()
                    {
                        Mnemonic = def
                    };
                    mnemonics.GreWord = greWord;
                    _entities.AddToFeaturedMnemonics(mnemonics);
                    _entities.SaveChanges();
                }
            }

            Regex regexAllMnemonicDIV = new Regex("<div class='mnemonic'>(.+?)</div>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            Regex regexAllMnemonicLI = new Regex(@"<li><p>(.+?)</p><p>\s+added by.+?<p>Was this mnemonic useful \?&nbsp; &nbsp;\s+<strong id='hallo\d+'>(.+?)</strong>.+?<strong id='hallo\d+'>&nbsp;(.+?)</strong>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            Match allMnemonic = regexAllMnemonicDIV.Match(text);
            if (selectedMnemonic != null)
            {
                MatchCollection meanings = regexAllMnemonicLI.Matches(allMnemonic.Groups[1].Value);

                foreach (Match m in meanings)
                {
                    string def = CleanText(m.Groups[1].Value);
                    BasicMnemonic mnemonics = new BasicMnemonic()
                    {
                        Mnemonic = def,
                        Helpful = m.Groups[2].Value,
                        NotHelpful = m.Groups[3].Value
                    };
                    mnemonics.GreWord = greWord;
                    _entities.AddToBasicMnemonics(mnemonics);
                    _entities.SaveChanges();
                }
            }
        }
        //6
        public void ParseMnemonicDictionarySynonym()
        {
            List<WordDefinition> words = (_entities.WordDefinitions.Select(w => w)).ToList();

            foreach (WordDefinition w in words)
            {
                try
                {

                    string text = w.Definition;
                    text = text.Replace("<u>synonyms</u> : ", " ");
                    Regex regexWord = new Regex(@"<a href='http://www\.mnemonicdictionary\.com/word/.+?' onclick=""ajaxSearch\('.+?','click'\); return false;"">(.+?)</a>", RegexOptions.IgnoreCase);

                    MatchCollection meanings = regexWord.Matches(text);
                    foreach (Match m in meanings)
                    {
                        string def = m.Groups[1].Value;

                        text = text.Replace(m.Groups[0].Value, "\'" + def + "'");
                    }


                    Regex regexAddedBy = new Regex(@" -added by <a href='http://www.mnemonicdictionary.com/phpbb/profile.php\?mode=viewprofile&amp;u=.+?'>.+?</a>", RegexOptions.IgnoreCase);
                    meanings = regexAddedBy.Matches(text);
                    foreach (Match m in meanings)
                    {
                        text = text.Replace(m.Groups[0].Value, "");
                    }
                    w.Definition = text;
                    _entities.SaveChanges();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
        //7
        public void ParseWordnetDefinitions()
        {
            List<string> words = (from w in _entities.DefinitionsNetHtmls select w.Word).ToList();

            foreach (string word in words)
            {
                this.ParseWordnetDefinitions(word);
            }
        }

        public void ParseWordnetDefinitions(string word)
        {

            FireLogMessage("WordnetDefinitions Parsing: " + word);
            var html = (from w in _entities.DefinitionsNetHtmls where w.Word == word select w).FirstOrDefault();
            var greWord = GetGreWord(word);

            try
            {
                Regex r = new Regex("Wordnet</span>.+?<td class=\"dsc2\" width=100%>(.+?)</td>", RegexOptions.Singleline);
                string resultstring = r.Match(html.Html).Groups[1].Value;

                Regex regexObj = new Regex(@"<br><b>([0-9]+)\.&nbsp;<span style=""color:#000055;font-size:10px"">\((.+?)\)</span></b>&nbsp;<b>(.+?)</b>\s*<br>(.+?)<br>\s*(<i><span style=""color:#666666"">(.+?)</span></i><br>)?");

                MatchCollection mc = regexObj.Matches(resultstring);
                foreach (Match match in mc)
                {
                    string similar = match.Groups[3].Value;
                    var defs = (from w in _entities.GreWordDefinitions
                                where w.GreWord.Word == word && w.SimilarWords == similar
                                select w).FirstOrDefault();
                    if (defs == null)
                    {
                        defs = new GreWordDefinition()
                        {
                            GreWord = greWord,
                            Serial = match.Groups[1].Value,
                            PartsOfSpeech = match.Groups[2].Value,
                            SimilarWords = match.Groups[3].Value,
                            Definitions = match.Groups[4].Value,
                            Sentences = match.Groups[6].Value
                        };

                        defs.Definitions = Regex.Replace(defs.Definitions, "<a.+?>(.+?)</a>", "$1");
                        _entities.AddToGreWordDefinitions(defs);
                        _entities.SaveChanges();
                    }
                    else
                    {
                        defs.Serial = match.Groups[1].Value;
                        defs.PartsOfSpeech = match.Groups[2].Value;
                        defs.SimilarWords = match.Groups[3].Value;
                        defs.Definitions = match.Groups[4].Value;
                        defs.Sentences = match.Groups[6].Value;
                        defs.Definitions = Regex.Replace(defs.Definitions, "<a.+?>(.+?)</a>", "$1");
                        _entities.SaveChanges();
                    }
                }

            }
            catch (ArgumentException ex)
            {
                FireLogMessage(word + ": " + ex.Message);
                // Syntax error in the regular expression
            }
        }
        //8

        public void ParseWordnetSynonyms()
        {
            List<string> words = (from w in _entities.SynonymsNetHtmls select w.Word).ToList();

            foreach (string word in words)
            {
                ParseWordnetSynonyms(word);
            }
        }

        public void ParseWordnetSynonyms(string word)
        {
            FireLogMessage("WordnetSynonyms Parsing: " + word);

            var html = (from w in _entities.SynonymsNetHtmls where w.Word == word select w).FirstOrDefault();
            var greWord = GetGreWord(word);

            try
            {

                Regex regexObj = new Regex(@"<br><b>([0-9]+)\.&nbsp;<span style=""color:#000055;font-size:10px"">\((.+?)\)</span></b>&nbsp;<b>(.+?)</b>\s*<br><span style=""color:#666666;""><i>(.+?)</i></span>\s*<br>(<b>Synonyms:&nbsp;</b>(.+?)<br>)?(<b>Antonyms:&nbsp;</b>(.+?)\s*<br>)?", RegexOptions.Singleline | RegexOptions.IgnoreCase);

                MatchCollection mc = regexObj.Matches(html.Html);
                foreach (Match match in mc)
                {
                    string similar = match.Groups[3].Value;
                    var defs = (from w in _entities.GreWordSynonyms
                                where w.GreWord.Word == word && w.SimilarWords == similar
                                select w).FirstOrDefault();
                    if (defs == null)
                    {
                        defs = new GreWordSynonym()
                        {
                            GreWord = greWord,
                            Serial = match.Groups[1].Value,
                            PartsOfSpeech = match.Groups[2].Value,
                            SimilarWords = match.Groups[3].Value,
                            Definitions = match.Groups[4].Value,
                            Synonyms = match.Groups[6].Value,
                            Antonyms = match.Groups[8].Value
                        };

                        defs.Definitions = Regex.Replace(Regex.Replace(defs.Definitions, "<a.+?>(.+?)</a>", "$1"), "<span.+?>(.+?)</span>", "$1");
                        defs.Synonyms = Regex.Replace(Regex.Replace(defs.Synonyms, "<a.+?>(.+?)</a>", "$1"), "<span.+?>(.+?)</span>", "$1").Replace("\t", "").Replace("\r", "").Replace("\n", "");
                        defs.Antonyms = Regex.Replace(Regex.Replace(defs.Antonyms, "<a.+?>(.+?)</a>", "$1"), "<span.+?>(.+?)</span>", "$1");

                        _entities.AddToGreWordSynonyms(defs);
                        _entities.SaveChanges();
                    }
                    else
                    {
                        defs.Serial = match.Groups[1].Value;
                        defs.PartsOfSpeech = match.Groups[2].Value;
                        defs.SimilarWords = match.Groups[3].Value;
                        defs.Definitions = match.Groups[4].Value;
                        defs.Synonyms = match.Groups[6].Value;
                        defs.Antonyms = match.Groups[8].Value;

                        defs.Definitions = Regex.Replace(Regex.Replace(defs.Definitions, "<a.+?>(.+?)</a>", "$1"), "<span.+?>(.+?)</span>", "$1");
                        defs.Synonyms = Regex.Replace(Regex.Replace(defs.Synonyms, "<a.+?>(.+?)</a>", "$1"), "<span.+?>(.+?)</span>", "$1");
                        defs.Antonyms = Regex.Replace(Regex.Replace(defs.Antonyms, "<a.+?>(.+?)</a>", "$1"), "<span.+?>(.+?)</span>", "$1");
                        _entities.SaveChanges();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression
            }
        }

        static string CleanText(string str)
        {
            str = str.Replace("<em>", "");
            str = str.Replace("</em>", "");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("<p>", "");
            str = str.Replace("</p>", ", ");
            return str;
        }

        private GreWord GetGreWord(string word)
        {
            var sql = (_entities.GreWords.Where(w => w.Word == word)).FirstOrDefault();
            return sql;
        }

        void UpdateGoogleSynonym(GreWord word, string synonym)
        {
            GoogleSynonym gs = (_entities.GoogleSynonyms.Where(w => w.GreWord.Word == word.Word && w.Synonym == synonym)).FirstOrDefault();

            if (gs == null)
            {
                gs = new GoogleSynonym()
                {
                    GreWord = word,
                    Synonym = synonym
                };
                _entities.AddToGoogleSynonyms(gs);
                _entities.SaveChanges();
            }
        }

        void UpdateGoogleBengaliWord(GreWord word, string definition)
        {
            BengaliDefinition gs = (_entities.BengaliDefinitions.Where(w => w.GreWord.Word == word.Word && w.Bengali == definition)).FirstOrDefault();
            if (gs == null)
            {
                gs = new BengaliDefinition()
                {
                    GreWord = word,
                    Bengali = definition
                };
                _entities.AddToBengaliDefinitions(gs);
                _entities.SaveChanges();
            }
        }

        void UpdateGooglePhrase(GreWord word, string en, string bn)
        {
            var gs = (_entities.GooglePhrases.Where(w => w.GreWord.Word == word.Word && w.EnglishPhrase == en)).FirstOrDefault();
            if (gs == null)
            {
                gs = new GooglePhrase()
                {
                    GreWord = word,
                    EnglishPhrase = en,
                    BengaliPhrase = bn,
                };

                _entities.AddToGooglePhrases(gs);
                _entities.SaveChanges();
            }
        }


        public string WordToFetch { get; set; }
        public void FetchAndParseSingleWord()
        {
            FireLogMessage("STARTED");

            FetchDefinitionsNet(WordToFetch);
            FetchEtymology(WordToFetch);
            FetchGoogleDictionary(WordToFetch);
            FetchMnemonicDictionary(WordToFetch);
            FetchSynonymsNet(WordToFetch);


            ParseEtymology(WordToFetch);
            ParseGoogleBengali(WordToFetch);
            ParseGooglePhrase(WordToFetch);
            ParseGoogleSynonym(WordToFetch);
            ParseMnemonicDictionary(WordToFetch);
            ParseWordnetDefinitions(WordToFetch);
            ParseWordnetSynonyms(WordToFetch);

            FireLogMessage("FINISHED");
        }

        void FireLogMessage(string message)
        {
            if (OnLogMessage != null)
            {
                OnLogMessage(this, message);
            }
        }


    }
}
