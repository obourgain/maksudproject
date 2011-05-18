using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace HttpUtility
{
    public class HttpHelper
    {
        /// <summary>
        /// Returns the content of a given web adress as string.
        /// </summary>
        /// <param name="url">URL of the webpage</param>
        /// <returns>Website content</returns>
        public static string DownloadWebPage(string url)
        {
            try
            {
                // Open a connection
                var webRequestObject = (HttpWebRequest)HttpWebRequest.Create(url);

                // You can also specify additional header values like 
                // the user agent or the referer:
                webRequestObject.UserAgent = ".NET Framework/2.0";
                webRequestObject.Referer = "http://www.example.com/";

                // Request response:
                var response = webRequestObject.GetResponse();

                // Open data stream:
                var webStream = response.GetResponseStream();

                // Create reader object:
                var reader = new StreamReader(webStream);

                // Read the entire stream content:
                string pageContent = reader.ReadToEnd();

                // Cleanup
                reader.Close();
                webStream.Close();
                response.Close();

                return pageContent;
            }
            catch
            {
                return "";
            }
        }


        public static string Decode(string data)
        {
            return System.Web.HttpUtility.HtmlDecode(data);
        }
    }
}