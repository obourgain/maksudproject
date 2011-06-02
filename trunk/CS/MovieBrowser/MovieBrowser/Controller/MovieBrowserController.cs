using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using BrightIdeasSoftware;
using CommonUtilities;
using CommonUtilities.Extensions;
using CommonUtilities.FileSystem;
using MovieBrowser.Forms;
using MovieBrowser.Model;
using MovieBrowser.Parser;
using ShellLib;

namespace MovieBrowser.Controller
{
    public partial class MovieBrowserController
    {
        #region Private Variables
        readonly FolderBrowserDialog _dialog = new FolderBrowserDialog();
        private OLVListItem _selectedOlvListItem = null;
        private MovieDbEntities entities;
        #endregion


        #region Properties
        public bool DbLoggedIn { get; set; }
        public MovieDbEntities Db { get { return entities; } }
        #endregion


        public MovieBrowserController()
        {
            try
            {
                entities = new MovieDbEntities();
                DbLoggedIn = false;

            }
            catch
            {

            }
        }

        #region Event
        public event EventHandler OnDebugTextFired;
        public void InvokeOnDebugTextFired(string text)
        {
            var handler = OnDebugTextFired;
            if (handler != null) handler(this, new TextEventArgs(text));
        }

        public event EventHandler OnMovieInformationCollected;
        public void InvokeOnMovieInformationCollected(Movie movie, string message)
        {
            var handler = OnMovieInformationCollected;
            if (handler != null) handler(this, new MovieEventArgs(movie, message));
        }

        public event EventHandler OnNotificationFired;
        public void InvokeOnNotificationFired(string text)
        {
            var handler = OnNotificationFired;
            if (handler != null) handler(this, new TextEventArgs(text));
        }
        #endregion



        #region Constants
        public const string GoogleSearch = "http://www.google.com/search?q=";
        public const string ImdbSearch = "http://www.imdb.com/find?s=all&q=";
        public const string ImdbTitle = "http://www.imdb.com/title/";
        public const string ImdbKeywordUrl = "http://www.imdb.com/title/{0}/keywords";
        #endregion




        public WebBrowser Browser { get; set; }

        public bool RecentSearch { get; set; }

        public bool IntelligentSearch { get; set; }

        public List<Movie> Movies
        {
            get
            {
                return entities.Movies.ToList();
            }
        }

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

        public void SearchMovieTree(string address, OLVListItem movie)
        {
            try
            {
                _selectedOlvListItem = movie;
                SearchMovie(address, (Movie)movie.RowObject);
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
            UpdateMovie(_selectedOlvListItem);
        }

        public string ChangeFolderName(Movie original)
        {
            var newdir = original.FilePath.Substring(0, original.FilePath.LastIndexOf("\\") + 1);
            newdir += original.FolderName.CleanFileName();
            Directory.Move(original.FilePath, newdir);

            return newdir;
        }

        public void UpdateMovie(OLVListItem nodeMovie)
        {
            try
            {

                var rowMovie = ((Movie)_selectedOlvListItem.RowObject);
                var movie = ParseMovieInfo(Browser.DocumentText);
                if (movie == null) return;

                movie.FilePath = rowMovie.FilePath;

                rowMovie.FilePath = ChangeFolderName(movie);
                rowMovie.IsValidMovie = true;

                InvokeOnNotificationFired("Movie: " + rowMovie.Title + " is updated.");
            }
            catch (Exception exception)
            {
                Logger.Exception(exception, 2);
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

        public void SaveFolderListTree(ArrayList movieFolderTree)
        {
            Properties.Settings.Default.Paths = new StringCollection();

            foreach (Movie node in movieFolderTree)
            {
                Properties.Settings.Default.Paths.Add(node.FilePath);
            }
            Properties.Settings.Default.Save();
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
            var title = ImdbParser.MediaFrom(src);
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

        public void SendTo(IEnumerable<Movie> movies, ToolStripComboBox tsPendrives)
        {
            try
            {
                foreach (var movie in movies)
                {
                    var stt = new SendToThread()
                    {
                        Source = movie.FilePath,
                        Destination = Path.Combine(tsPendrives.SelectedItem.ToString(), movie.FolderName)
                    };
                    stt.SendTo();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("SendTo:\r\n{0}", exception.Message));
            }
        }

        public Movie CollectAndAddMovieToDb(Movie movie2, string html = null)
        {
            if (string.IsNullOrEmpty(html))
            {
                InvokeOnNotificationFired("Started collecting movie: " + movie2.Title);
                html = HttpHelper.FetchWebPage(MovieBrowserController.ImdbTitle + movie2.ImdbId);
            }

            var parseMovieInfo = ParseMovieInfo(html);

            if (parseMovieInfo == null) return null;



            var movie = entities.Movies.Where(o => o.ImdbId == parseMovieInfo.ImdbId).FirstOrDefault();
            if (movie == null)
            {
                movie = parseMovieInfo;
                entities.AddToMovies(movie);
                entities.SaveChanges();
            }
            else
            {
                movie.CopyFromMovie(parseMovieInfo);
                entities.SaveChanges();
            }


            if (parseMovieInfo.Genres.Count > 0)
            {
                foreach (var g in parseMovieInfo.Genres)
                {
                    var genre = entities.Genres.Where(o => o.Name == g.Name).FirstOrDefault();
                    if (genre == null)
                    {
                        genre = new Genre() { Name = g.Name, Code = g.Code, Rated = 0 };
                        entities.AddToGenres(genre);
                        entities.SaveChanges();
                    }

                    var movieGenre = entities.MovieGenres.Where(o => o.Movie.Id == movie.Id && o.Genre.Id == genre.Id).FirstOrDefault();

                    if (movieGenre == null)
                    {
                        movieGenre = new MovieGenre { Movie = movie, Genre = genre };
                        entities.AddToMovieGenres(movieGenre);
                        entities.SaveChanges();
                    }
                }
            }

            if (parseMovieInfo.Languages.Count > 0)
            {
                foreach (var g in parseMovieInfo.Languages)
                {
                    var genre = entities.Languages.Where(o => o.Name == g.Name).FirstOrDefault();
                    if (genre == null)
                    {
                        genre = new Language() { Name = g.Name, Code = g.Code };
                        entities.AddToLanguages(genre);
                        entities.SaveChanges();
                    }

                    var movieGenre = entities.MovieLanguages.Where(o => o.Movie.Id == movie.Id && o.Language.Id == genre.Id).FirstOrDefault();

                    if (movieGenre == null)
                    {
                        movieGenre = new MovieLanguage() { Movie = movie, Language = genre };
                        entities.AddToMovieLanguages(movieGenre);
                        entities.SaveChanges();
                    }
                }
            }


            if (parseMovieInfo.Countries.Count > 0)
            {
                foreach (var g in parseMovieInfo.Countries)
                {
                    var country = entities.Countries.Where(o => o.Name == g.Name).FirstOrDefault();
                    if (country == null)
                    {
                        country = new Country() { Name = g.Name, Code = g.Code };
                        entities.AddToCountries(country);
                        entities.SaveChanges();
                    }

                    var movieCountry = entities.MovieCountries.Where(o => o.Movie.Id == movie.Id && o.Country.Id == country.Id).FirstOrDefault();

                    if (movieCountry == null)
                    {
                        movieCountry = new MovieCountry() { Movie = movie, Country = country };
                        entities.AddToMovieCountries(movieCountry);
                        entities.SaveChanges();
                    }
                }

            }

            var keywordSrc = HttpHelper.FetchWebPage(string.Format(ImdbKeywordUrl, parseMovieInfo.ImdbId));
            parseMovieInfo.Keywords = ImdbParser.ParseKeywords(keywordSrc);

            if (parseMovieInfo.Keywords.Count > 0)
            {
                foreach (var g in parseMovieInfo.Keywords)
                {
                    var keyword = entities.Keywords.Where(o => o.Name == g.Name).FirstOrDefault();
                    if (keyword == null)
                    {
                        keyword = new Keyword() { Name = g.Name, Code = g.Code };
                        entities.AddToKeywords(keyword);
                        entities.SaveChanges();
                    }

                    var movieGenre = entities.MovieKeywords.Where(o => o.Movie.Id == movie.Id && o.Keyword.Id == keyword.Id).FirstOrDefault();

                    if (movieGenre == null)
                    {
                        movieGenre = new MovieKeyword() { Movie = movie, Keyword = keyword };
                        entities.AddToMovieKeywords(movieGenre);
                        entities.SaveChanges();
                    }
                }

            }

            InvokeOnNotificationFired("Fiished collecting movie: " + movie.Title);

            return movie;
        }

        public Movie GuessMovie(string srcHtml)
        {
            return ImdbParser.GuessMovie(srcHtml);
        }

        #region Imdb Parser
        public Movie ParseMovieInfo(string html)
        {
            try
            {
                var movie = new Movie();

                //var src = Browser.DocumentText;
                var rating = ImdbParser.ParseRating(html);
                var title = ImdbParser.ParseTitle(html);
                var year = ImdbParser.ParseYear(html);
                var imdbId = ImdbParser.ParseId(html);

                InvokeOnDebugTextFired("Title: " + title + "\r\n");
                InvokeOnDebugTextFired("Year: " + year + "\r\n");
                InvokeOnDebugTextFired("Rating: " + rating + "\r\n");

                movie.Rating = Convert.ToDouble(rating);
                movie.Title = HttpHelper.HtmlDecode(HttpHelper.UrlDecode(ImdbParser.ParseTitle(html)));
                movie.Year = Convert.ToInt32(year);
                movie.ImdbId = imdbId;
                movie.FilePath = "";
                movie.Runtime = ImdbParser.ParseRuntime(html);
                movie.MPAA = ImdbParser.ParseMpaa(html);
                movie.MPAAReason = ImdbParser.ParseMpaaReason(html);
                movie.Highlight = ImdbParser.ParseHighlight(html);
                movie.Genres = ImdbParser.ParseGenres(html);
                movie.Countries = ImdbParser.ParseCountries(html);
                movie.Languages = ImdbParser.ParseLanguages(html);


                return movie;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        #endregion

        #region Db Access
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
        #endregion

        public void RemoveMovie(string imdbId)
        {

            entities.DeleteObjects(entities.MovieGenres.Where(o => o.Movie.ImdbId == imdbId));
            entities.DeleteObjects(entities.MovieCountries.Where(o => o.Movie.ImdbId == imdbId));
            entities.DeleteObjects(entities.MovieKeywords.Where(o => o.Movie.ImdbId == imdbId));
            entities.DeleteObjects(entities.MovieLanguages.Where(o => o.Movie.ImdbId == imdbId));
            entities.DeleteObjects(entities.MoviePersonalNotes.Where(o => o.Movie.ImdbId == imdbId));
            entities.DeleteObjects(entities.MovieUserLists.Where(o => o.Movie.ImdbId == imdbId));


            entities.DeleteObjects(entities.Movies.Where(o => o.ImdbId == imdbId));


            entities.SaveChanges();
        }

        public void RemoveAllInfo()
        {

            entities.DeleteObjects(entities.Keywords);
            entities.SaveChanges();
        }


        private MoviePersonalNote GetNote(MovieDbEntities db, User loggedInUser, Movie rowMovie)
        {
            var user = db.Users.Where(o => o.Username == loggedInUser.Username).FirstOrDefault();
            var movie = db.Movies.Where(o => o.ImdbId == rowMovie.ImdbId).FirstOrDefault();

            if (movie == null)
            {
                db.AddToMovies(rowMovie);
                movie = rowMovie;
            }

            var personalNote = db.MoviePersonalNotes.Where(o => o.User.Id == loggedInUser.Id && o.Movie.Id == movie.Id).FirstOrDefault();

            if (personalNote == null)
            {
                personalNote = new MoviePersonalNote { Comment = "", Movie = movie, User = user };
                db.AddToMoviePersonalNotes(personalNote);
            }
            return personalNote;
        }



        public MoviePersonalNote UpdateUserRating(User loggedInUser, Movie rowMovie, double rating)
        {

            var note = GetNote(entities, loggedInUser, rowMovie);
            note.Rating = rating;
            entities.SaveChanges();
            return note;
        }

        public MoviePersonalNote ToggleWanted(User loggedInUser, Movie rowMovie, bool? value = null)
        {

            var note = GetNote(entities, loggedInUser, rowMovie);
            if (value != null)
                note.Wishlist = value.Value;
            else
                note.Wishlist = !note.Wishlist;
            entities.SaveChanges();
            return note;
        }
        public MoviePersonalNote SetFavourite(User loggedInUser, Movie rowMovie, bool val)
        {

            var note = GetNote(entities, loggedInUser, rowMovie);

            if (val)
            {
                if (note.Favourite > 0)
                    note.Favourite = 0;
                else
                    note.Favourite = 1;
            }
            else
            {
                if (note.Favourite < 0)
                    note.Favourite = 0;
                else
                    note.Favourite = -1;
            }
            entities.SaveChanges();
            return note;
        }
        public MoviePersonalNote ToggleSeenIt(User loggedInUser, Movie rowMovie, bool? val = null)
        {
            var note = GetNote(entities, loggedInUser, rowMovie);
            note.Seen = val ?? !note.Seen;
            entities.SaveChanges();
            return note;
        }
        public MoviePersonalNote ToggleHaveIt(User loggedInUser, Movie rowMovie, bool? val = null)
        {
            var note = GetNote(entities, loggedInUser, rowMovie);
            note.Have = val ?? !note.Have;
            entities.SaveChanges();
            return note;
        }

        public void AddToUserList(Movie movie, string selectedText)
        {
            var list = entities.UserLists.Where(o => o.ListName == selectedText).FirstOrDefault();
            if (list == null) return;
            var a = new MovieUserList { UserList = list, Movie = movie };
            entities.AddToMovieUserLists(a);
            entities.SaveChanges();
        }
    }
}
