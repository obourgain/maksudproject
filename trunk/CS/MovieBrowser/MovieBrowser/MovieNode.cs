using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonUtilities;

namespace MovieBrowser
{
    public class MovieNode : TreeNode
    {
        public MovieNode(Movie movie)
        {
            Text = movie.TitleWithRating;
            Tag = movie;
            SelectedImageIndex = ImageIndex = movie.ImageIndex;
        }
    }
}
