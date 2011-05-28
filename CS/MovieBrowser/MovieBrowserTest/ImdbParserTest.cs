using CommonUtilities;
using MovieBrowser.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MovieBrowser.Model;
using System.Collections.Generic;
using MovieBrowser.Parser;

namespace MovieBrowserTest
{


    /// <summary>
    ///This is a test class for ImdbParserTest and is intended
    ///to contain all ImdbParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ImdbParserTest
    {
        private string _priest2011 = "http://www.imdb.com/title/tt0822847";
        private string _godfather1972 = "http://www.imdb.com/title/tt0068646/";
        private string _moss = "http://www.imdb.com/name/nm0005251/";


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ImdbParser Constructor
        ///</summary>
        [TestMethod()]
        public void ImdbParserConstructorTest()
        {
            ImdbParser target = new ImdbParser();

        }

        /// <summary>
        ///A test for GuessMovie
        ///</summary>
        [TestMethod()]
        public void GuessMovieTest()
        {
            string srcHtml = string.Empty; // TODO: Initialize to an appropriate value
            Movie expected = null; // TODO: Initialize to an appropriate value
            Movie actual;
            actual = ImdbParser.GuessMovie(srcHtml);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for MediaFrom
        ///</summary>
        [TestMethod()]
        public void MediaFromTest()
        {
            string html = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = ImdbParser.MediaFrom(html);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for ParseCountries
        ///</summary>
        [TestMethod()]
        public void ParseCountriesTest()
        {
            string html = string.Empty; // TODO: Initialize to an appropriate value
            List<Country> expected = null; // TODO: Initialize to an appropriate value
            List<Country> actual;
            actual = ImdbParser.ParseCountries(html);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for ParseGenres
        ///</summary>
        [TestMethod()]
        public void ParseGenresTest()
        {
            string html = string.Empty; // TODO: Initialize to an appropriate value
            List<Genre> expected = null; // TODO: Initialize to an appropriate value
            List<Genre> actual;
            actual = ImdbParser.ParseGenres(html);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for ParseHighlight
        ///</summary>
        [TestMethod()]
        public void ParseHighlightTest()
        {
            //var html = HttpHelper.FetchWebPage(_godfather1972);
            //var html = HttpHelper.FetchWebPage(_priest2011);
            var html = HttpHelper.FetchWebPage(_moss);
            string actual;
            actual = ImdbParser.ParseHighlight(html);
            Assert.IsTrue(actual.Length > 0);

        }

        /// <summary>
        ///A test for ParseId
        ///</summary>
        [TestMethod()]
        public void ParseIdTest()
        {
            string html = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = ImdbParser.ParseId(html);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for ParseKeywords
        ///</summary>
        [TestMethod()]
        public void ParseKeywordsTest()
        {
            string html = string.Empty; // TODO: Initialize to an appropriate value
            List<Keyword> expected = null; // TODO: Initialize to an appropriate value
            List<Keyword> actual;
            actual = ImdbParser.ParseKeywords(html);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for ParseMoviePoster
        ///</summary>
        [TestMethod()]
        public void ParseMoviePosterTest()
        {
            string html = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = ImdbParser.ParseMoviePoster(html);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for ParseMpaa
        ///</summary>
        [TestMethod()]
        public void ParseMpaaTest()
        {
            string html = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = ImdbParser.ParseMpaa(html);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for ParseRating
        ///</summary>
        [TestMethod()]
        public void ParseRatingTest()
        {
            string html = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = ImdbParser.ParseRating(html);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for ParseRuntime
        ///</summary>
        [TestMethod()]
        public void ParseRuntimeTest()
        {
            var html = HttpHelper.FetchWebPage(_priest2011);
            string expected = "87 min";
            string actual;
            actual = ImdbParser.ParseRuntime(html);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for ParseTitle
        ///</summary>
        [TestMethod()]
        public void ParseTitleTest()
        {
            var html = HttpHelper.FetchWebPage(_priest2011);
            string expected = "Priest";
            string actual;
            actual = ImdbParser.ParseTitle(html);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for ParseYear
        ///</summary>
        [TestMethod()]
        public void ParseYearTest()
        {
            var html = HttpHelper.FetchWebPage(_priest2011);
            string expected = "2011";
            string actual;
            actual = ImdbParser.ParseYear(html);
            Assert.AreEqual(expected, actual);

        }
    }
}
