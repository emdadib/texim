using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace texim.Helper
{
    public class SlugHelper
    {
        public static string RemoveAccent(string txt)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] bytes = Encoding.GetEncoding("windows-1254").GetBytes(txt);
            return Encoding.ASCII.GetString(bytes);
        }

        public static string GetEncodedTitle(string title)
        {
            string str = RemoveAccent(title).ToLower();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // Remove all non valid chars
            str = Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space
            str = Regex.Replace(str, @"\s", "-"); // //Replace spaces by dashes
            return str;
        }
    }
}