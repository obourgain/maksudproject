using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using CommonUtilities;

namespace MovieBrowser.Model
{
    public partial class Movie
    {
        public static readonly List<string> MovieFiles = new List<string>() { "avi", "mkv", "flv", "mp4" };
        public static readonly List<string> SubtitleFiles = new List<string>() { "srt", "sub" };

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

        public static Movie FromFolderName(string folderPath)
        {
            var folderName = "";
            var i = folderPath.LastIndexOf("\\");
            if (i > 0)
            {
                folderName = folderPath.Substring(i + 1);
            }

            var match = Regex.Match(folderName, @"(.+) \((\d+)\), \[([\d.]+)\]\s*(\[(tt\d+)\])?");
            if (match.Success)
            {
                return new Movie()
                {
                    Title = match.Groups[1].Value,
                    Year = int.Parse(match.Groups[2].Value),
                    Rating = double.Parse(match.Groups[3].Value),
                    ImdbId = match.Groups[5].Value,
                    FilePath = folderPath,
                    IsValidMovie = true
                };
            }
            return new Movie() { Title = folderName, FilePath = folderPath, IsValidMovie = false };
        }

        public bool IsFolder
        {
            get
            {
                return Directory.Exists(FilePath);
            }
        }
        public bool IsValidMovie { get; set; }
        public string FilePath { get; set; }

        public string FolderName { get { return string.Format("{0} ({1}), [{2}] [{3}]", Title, Year, Rating, ImdbId); } }
        public int ImageIndex
        {
            get
            {
                if (IsValidMovie)
                    return 0; // Movie

                else if (IsFolder)
                    return 1; // Folder
                else
                {
                    if (FilePath.Extension().ExistsIn(MovieFiles))
                        return 2; // Video
                    else if (FilePath.Extension().ExistsIn(SubtitleFiles))
                        return 3; // Subtitles
                    else
                    {
                        return 4; // File
                    }
                }
            }
        }
    }
}
