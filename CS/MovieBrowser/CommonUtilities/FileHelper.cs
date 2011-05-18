using System.Collections.Generic;

namespace CommonUtilities
{
    public static class FileHelper
    {
       
        public static string Extension(this string @this)
        {
            try { return @this.Substring(@this.LastIndexOf(".") + 1); }
            catch { return ""; }
        }

        public static bool ExistsIn(this string @this, List<string> extensions)
        {
            return extensions.Contains(@this);
        }

    }
}
