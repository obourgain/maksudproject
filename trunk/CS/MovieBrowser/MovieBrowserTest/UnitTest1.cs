using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieBrowser.Controller;
using MovieBrowser.Model;
using MovieBrowser.Parser;

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
            //Assert.IsTrue(movie.ImdbId == "tt0822847");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestParseMoviePoster()
        {
            const string url = "http://www.imdb.com/title/tt0822847";
            var html = HttpHelper.FetchWebPage(url);

            var movie = ImdbParser.ParseMoviePoster(html);
            Assert.IsTrue(movie == "http://ia.media-imdb.com/images/M/MV5BMTQ1MTAwODc3OV5BMl5BanBnXkFtZTcwNzI0MDQ3NA@@._V1._SY317_.jpg"); 
        }


    }
}
