using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace texim.Helper
{
    public class MenuActiveHelper
    {
        public static string IsActive(string url, string route)
        {
            if (url.Equals(route))
            {
                return "active";
            }
            else
            {
                return "";
            }
        }

        public static string IsActiveWeb(string url, string route)
        {
            if (url.Equals(route))
            {
                return "current_page_item";
            }
            else
            {
                return "";
            }
        }
    }
}