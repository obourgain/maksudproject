using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CommonUtilities;
using CommonUtilities.FileSystem;
using HttpUtility;
using MovieBrowser.Forms;
using MovieBrowser.Model;
using ShellLib;

namespace MovieBrowser.Controller
{
    public class DebugEventArgs : EventArgs
    {
        public string Text { get; set; }
        public DebugEventArgs(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public class MovieBrowserController
    {
        public event EventHandler OnDebugTextFired;

        public void InvokeOnDebugTextFired(string text)
        {
            var handler = OnDebugTextFired;
            if (handler != null) handler(this, new EventArgs() { });
        }

        public const string GoogleSearch = "http://www.google.com/search?q=";
        public const string ImdbSearch = "http://www.imdb.com/find?s=all&q=";
        public const string ImdbTitle = "http://www.imdb.com/title/";
        public const string ImdbKeywordUrl = "http://www.imdb.com/title/{0}/keywords";

        readonly FolderBrowserDialog _dialog = new FolderBrowserDialog();
        private MovieNode _selectedNode = null;

        public WebBrowser Browser { get; set; }
        //public TreeView MovieFolderTree { get; set; }
        //public ListView ListView1 { get; set; }
        public bool RecentSearch { get; set; }

        public bool IntelligentSearch { get; set; }


        public void LoadAllFolders(TreeView movieFolderTree)
        {
            movieFolderTree.Nodes.Clear();
            if (Properties.Settings.Default.Paths == null) return;
            foreach (var path in Properties.Settings.Default.Paths)
            {
                LoadFolderIntoTreeView(path, movieFolderTree);
            }
        }

        public void LoadListViewMovies(ListView listView1)
        {
            listView1.Items.Clear();
            var entities = new MovieDbEntities();
            var list = entities.Movies.ToList();
            foreach (var movie in list)
            {
                listView1.Items.Add(new MovieListViewItem(movie));
            }
        }

        public void LoadFolderIntoTreeViewDialog(TreeView treeView)
        {
            if (_dialog.ShowDialog() == DialogResult.OK)
            {
                LoadFolderIntoTreeView(_dialog.SelectedPath, treeView);
            }
        }
        private static void LoadFolderIntoTreeView(string folderPath, TreeView treeView)
        {

            var movie = Movie.FromFolderName(folderPath);
            var treeNode = new MovieNode(movie);
            treeView.Nodes.Add(treeNode);

            FolderBrowseRecursively(treeNode, folderPath);
        }
        private static void FolderBrowseRecursively(MovieNode treeNode, string selectedPath)
        {

            var directories = Directory.GetDirectories(selectedPath);
            if (directories.Count() == 0) return;

            foreach (var directory in directories)
            {
                var movie = Movie.FromFolderName(directory);
                var tn = new MovieNode(movie);
                treeNode.Nodes.Add(tn);


                var files = Directory.GetFiles(directory);
                foreach (var file in files)
                {
                    movie = Movie.FromFolderName(file);
                    var node = new MovieNode(movie);
                    tn.Nodes.Add(node);
                }

                FolderBrowseRecursively(tn, directory);
            }
        }

        public void SearchMovieTree(string address, MovieNode movie)
        {
            try
            {
                _selectedNode = movie;
                SearchMovie(address, movie.Movie);
            }
            catch { }
        }
        public void SearchMovie(string address, Movie movie)
        {
            try
            {
                RecentSearch = true;
                if (address.Equals(ImdbSearch) && movie != null && !string.IsNullOrEmpty(movie.ImdbId))
                {

                    Navigate(ImdbTitle + movie.ImdbId);
                }
                else
                {
                    if (movie != null) Navigate(address + IgnoreWords(movie.Title));
                }
            }
            catch { }
        }
        private static string IgnoreWords(string text)
        {
            text = text.ToLower();
            string[] ignored = Properties.Settings.Default.IgnoreWords.ToLower().Split();
            text = ignored.Aggregate(text, (current, s) => string.IsNullOrEmpty(s) ? current : current.Replace(s, ""));
            text = text.Replace(".", " ");
            return text;
        }


        public void UpdateMovie()
        {
            UpdateMovie(_selectedNode.Movie);
        }

        public string ChangeFolderName(Movie original)
        {
            var newdir = original.FilePath.Substring(0, original.FilePath.LastIndexOf("\\") + 1);
            newdir += HttpHelper.UrlDecode(original.FolderName).Clean();
            Directory.Move(original.FilePath, newdir);

            return newdir;
        }

        public void UpdateMovie(Movie nodeMovie)
        {
            try
            {
                var movie = ParseMovieInfo(Browser.DocumentText);
                movie.FilePath = _selectedNode.Movie.FilePath;

                movie.FilePath = ChangeFolderName(movie);
                movie.IsValidMovie = true;

                _selectedNode.Text = movie.TitleWithRating;
                _selectedNode.Tag = movie;
                _selectedNode.SelectedImageIndex = _selectedNode.ImageIndex = movie.ImageIndex;
            }
            catch
            {
            }
        }

        public string UpdateIgnoreWords()
        {
            string[] words = Properties.Settings.Default.IgnoreWords.ToLower().Split();
            //Array.Sort(words);

            var t = (from s in words
                     orderby s descending
                     select s).ToArray();

            string s2 = string.Join(" ", t);

            Properties.Settings.Default.IgnoreWords = s2;
            Properties.Settings.Default.Save();

            return s2;
        }

        public void SaveFolderListTree(TreeView movieFolderTree)
        {
            Properties.Settings.Default.Paths = new StringCollection();

            foreach (MovieNode node in movieFolderTree.Nodes)
            {
                Properties.Settings.Default.Paths.Add(((Movie)node.Tag).FilePath);
            }
            Properties.Settings.Default.Save();
        }

        public Movie ParseMovieInfo(string src)
        {
            try
            {
                var movie = new Movie();

                //var src = Browser.DocumentText;
                var rating = Regex.Match(src, @"<span class=""rating-rating"">([\d.]+)<span>").Groups[1].Value;
                var match = Regex.Match(src, @"<title>(.+?) \(.*?([\d.]+)\)");
                var imdbId = Regex.Match(src, @"<meta property=""og:url"" content=""http://www\.imdb\.com/title/(tt[0-9]+?)/"" />").Groups[1].Value;

                InvokeOnDebugTextFired("Title: " + match.Groups[1].Value + "\r\n");
                InvokeOnDebugTextFired("Year: " + match.Groups[2].Value + "\r\n");
                InvokeOnDebugTextFired("Rating: " + rating + "\r\n");

                movie.Rating = Convert.ToDouble(rating);
                movie.Title = HttpHelper.UrlDecode(match.Groups[1].Value);
                movie.Year = Convert.ToInt32(match.Groups[2].Value);
                movie.ImdbId = imdbId;
                movie.FilePath = "";
                movie.Runtime = Regex.Match(src, @"<.+?>Runtime:</.+?>\s+(.+?)\s+</div>").Groups[1].Value;
                movie.MPPA = Regex.Match(src, @"<div class=""infobar"">\s*(<img.+?title=""(.+?)"".+?>)").Groups[2].Value;

                movie.Genres = new List<Genre>();
                var genres = Regex.Matches(src, @"<a href=""/genre/(.+?)"">(.+?)</a>");
                foreach (Match m in genres)
                {
                    movie.Genres.Add(new Genre() { Code = m.Groups[1].Value, Name = m.Groups[2].Value });
                }

                movie.Countries = new List<Country>();
                var countries = Regex.Matches(src, @"<a href=""/country/(.+?)"">(.+?)</a>");
                foreach (Match m in countries)
                {
                    movie.Countries.Add(new Country() { Code = m.Groups[1].Value, Name = m.Groups[2].Value });
                }

                string keywordSrc = HttpUtility.HttpHelper.DownloadWebPage(string.Format(ImdbKeywordUrl, imdbId));
                movie.Keywords = new List<Keyword>();
                var keywords = Regex.Matches(keywordSrc, @"<a href=""/keyword/(.+?)/"">(.+?)</a>");
                foreach (Match m in keywords)
                {
                    movie.Keywords.Add(new Keyword() { Code = m.Groups[1].Value, Name = m.Groups[2].Value });
                }

                return movie;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public void DeleteNode(TreeView movieFolderTree)
        {
            try
            {

                if (MessageBox.Show(@"Sure To Delete", @"Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    movieFolderTree.SelectedNode.Remove();
            }
            finally
            {

            }
        }

        public void Open(string path)
        {
            var execute = new ShellExecute
            {
                Verb = ShellExecute.OpenFile,
                Path = path
            };
            execute.Execute();
        }
        void Navigate(string url)
        {
            Browser.Navigate(url);
        }

        public void Redirect(string srcurl, string src)
        {
            var match = Regex.Match(src, "Media from&nbsp;<a href=\"/title/(tt[0-9]+)/");
            var title = match.Groups[1].Value;
            if (!string.IsNullOrEmpty(title))
            {
                var url = "http://www.imdb.com/title/" + title;
                InvokeOnDebugTextFired(string.Format("Redirect to '{0}'...\r\n", url));
                Browser.Navigate(url);

                RecentSearch = false;
            }

            if (srcurl.StartsWith(ImdbSearch))
                RecentSearch = false;
        }

        public void LoadPenDrives(ToolStripComboBox tsPendrives)
        {
            tsPendrives.Items.Clear();

            var ss = FileHelper.UsbDrives();
            foreach (string t in ss)
            {
                tsPendrives.Items.Add(t);
            }
            if (ss.Count > 0) tsPendrives.SelectedIndex = 0;
        }

        public void AddMovieToDb(Movie movie)
        {
            var entities = new MovieDbEntities();

            if (entities.Movies.Where(o => o.ImdbId.Equals(movie.ImdbId)).ToList().Count() == 0)
            {
                entities.AddToMovies(movie);
                entities.SaveChanges();
            }
            else
            {
                //Already exists
                Console.WriteLine(@"Exists: {0}", movie.ImdbId);
            }

        }

        public void UpdateMovieDataBaseFromFileSystem(TreeView treeView)
        {
            foreach (var node in treeView.Nodes)
            {
                UpdateMovieDataBaseFromFileSystem((MovieNode)node);
            }
        }

        public void UpdateMovieDataBaseFromFileSystem(MovieNode movieNode)
        {
            if (movieNode.Movie.IsValidMovie)
            {
                AddMovieToDb(movieNode.Movie);
            }

            foreach (var node in movieNode.Nodes)
            {
                UpdateMovieDataBaseFromFileSystem((MovieNode)node);
            }
        }

        public void SendTo(TreeView treeView1, ToolStripComboBox tsPendrives)
        {
            try
            {
                var movie = (Movie)treeView1.SelectedNode.Tag;
                var stt = new SendToThread()
                {
                    Source = movie.FilePath,
                    Destination = Path.Combine(tsPendrives.SelectedItem.ToString(), movie.FolderName)
                };
                stt.SendTo();
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("SendTo:\r\n{0}", exception.Message));
            }
        }

        public Movie CollectAndAddMovieToDb(string src)
        {
            //string title = _selectedNode.Movie.ImdbId;
            //string src = HttpHelper.DownloadWebPage(ImdbTitle + title);
            Movie parseMovieInfo = ParseMovieInfo(src);

            if (parseMovieInfo == null) return null;

            var db = new MovieDbEntities();

            var movie = db.Movies.Where(o => o.ImdbId == parseMovieInfo.ImdbId).FirstOrDefault();
            if (movie == null)
            {
                movie = parseMovieInfo;
                db.AddToMovies(movie);
                db.SaveChanges();
            }
            else
            {
                movie.ImdbId = parseMovieInfo.ImdbId;
                movie.Title = parseMovieInfo.Title;
                movie.Year = parseMovieInfo.Year;
                movie.Rating = parseMovieInfo.Rating;
                movie.Language = parseMovieInfo.Language;
                movie.ReleaseDate = parseMovieInfo.ReleaseDate;
                movie.Runtime = parseMovieInfo.Runtime;
                movie.MPPA = parseMovieInfo.MPPA;

                db.SaveChanges();
            }


            if (parseMovieInfo.Genres.Count > 0)
            {
                foreach (var g in parseMovieInfo.Genres)
                {
                    var genre = db.Genres.Where(o => o.Name == g.Name).FirstOrDefault();
                    if (genre == null)
                    {
                        genre = new Genre() { Name = g.Name, Code = g.Code, Rated = 0 };
                        db.AddToGenres(genre);
                        db.SaveChanges();
                    }

                    var movieGenre = db.MovieGenres.Where(o => o.Movie.Id == movie.Id && o.Genre.Id == genre.Id).FirstOrDefault();

                    if (movieGenre == null)
                    {
                        movieGenre = new MovieGenre { Movie = movie, Genre = genre };
                        db.AddToMovieGenres(movieGenre);
                        db.SaveChanges();
                    }
                }
            }


            if (parseMovieInfo.Countries.Count > 0)
            {
                foreach (var g in parseMovieInfo.Countries)
                {
                    var country = db.Countries.Where(o => o.Name == g.Name).FirstOrDefault();
                    if (country == null)
                    {
                        country = new Country() { Name = g.Name, Code = g.Code };
                        db.AddToCountries(country);
                        db.SaveChanges();
                    }

                    var movieCountry = db.MovieCountries.Where(o => o.Movie.Id == movie.Id && o.Country.Id == country.Id).FirstOrDefault();

                    if (movieCountry == null)
                    {
                        movieCountry = new MovieCountry() { Movie = movie, Country = country };
                        db.AddToMovieCountries(movieCountry);
                        db.SaveChanges();
                    }
                }

            }

            if (parseMovieInfo.Keywords.Count > 0)
            {
                foreach (var g in parseMovieInfo.Keywords)
                {
                    var keyword = db.Keywords.Where(o => o.Name == g.Name).FirstOrDefault();
                    if (keyword == null)
                    {
                        keyword = new Keyword() { Name = g.Name, Code = g.Code };
                        db.AddToKeywords(keyword);
                        db.SaveChanges();
                    }

                    var movieGenre = db.MovieKeywords.Where(o => o.Movie.Id == movie.Id && o.Keyword.Id == keyword.Id).FirstOrDefault();

                    if (movieGenre == null)
                    {
                        movieGenre = new MovieKeyword() { Movie = movie, Keyword = keyword };
                        db.AddToMovieKeywords(movieGenre);
                        db.SaveChanges();
                    }
                }

            }

            return movie;
        }

        public Movie GuessMovie(string srcHtml)
        {
            var movie = new Movie();

            var match = Regex.Match(srcHtml, @"Media from&nbsp;<a href=""/title/(tt[0-9]+)/"".+?>(.+?)</a>(\s*\(([0-9]+?)\))?");
            movie.ImdbId = match.Groups[1].Value;
            movie.Title = match.Groups[2].Value;
            int year = 0;
            Int32.TryParse(match.Groups[4].Value, out year);
            movie.Year = year;
            return movie;
        }
    }
}
