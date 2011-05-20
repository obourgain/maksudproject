using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MovieBrowser.Model
{
    public class MovieListViewItem : ListViewItem
    {

        public MovieListViewItem(Movie movie)
        {
            Text = movie.ImdbId;
            SubItems.Add(movie.Title);
            SubItems.Add(movie.Rating.ToString());
            SubItems.Add(movie.Year.ToString());
            Tag = movie;
        }

        public Movie Movie { get { return (Movie)Tag; } }

    }
}
