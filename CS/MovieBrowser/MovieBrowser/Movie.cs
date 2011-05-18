using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieBrowser
{
    public class Movie
    {
        public string TitleWithRating
        {
            get
            {
                if (Rating > 0)
                {
                    return Title + " [" + Rating + "]";
                }
                else
                {
                    return Title;
                }
            }
        }
        public string FilePath { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }
        public string ImdbId { get; set; }
    }
}
