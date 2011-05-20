using System.Windows.Forms;

namespace MovieBrowser.Model
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
