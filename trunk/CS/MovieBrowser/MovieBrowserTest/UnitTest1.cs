using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieBrowser.Controller;
using MovieBrowser.Model;

namespace MovieBrowserTest
{
    [TestClass]
    public class UnitTest1
    {

        MovieBrowserController _controller = new MovieBrowserController();

        [TestMethod]
        public void TestMethod1()
        {
            var m = new Movie();
            Assert.IsNotNull(m);
        }

        [TestMethod]
        public void TestHttpGet()
        {
            string html = HttpHelper.FetchWebPage("http://google.com");

            Assert.IsNotNull(html);
            Assert.IsTrue(html.Length > 0);
        }

        [TestMethod]
        public void TestParseTitle()
        {
            const string url = "http://www.imdb.com/title/tt0822847/";
            var html = HttpHelper.FetchWebPage(url);

            var movie = _controller.ParseMovieInfo(html);
            Assert.IsTrue(movie.ImdbId == "tt0822847");
        }

        [TestMethod]
        public void TestParseTitleCredits()
        {
            const string url = "http://www.imdb.com/title/tt0822847/fullcredits";
            var html = HttpHelper.FetchWebPage(url);

            var movie = _controller.ParseMovieInfo(html);
            Assert.IsTrue(movie.ImdbId == "tt0822847");
        }
    }
}
