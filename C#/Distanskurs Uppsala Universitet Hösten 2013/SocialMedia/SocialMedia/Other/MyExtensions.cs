using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMedia.Other
{
    public static class MyExtensions
    {

        /// <summary>
        /// Method to convert from UTC to Swedish time as well as format it in YYYY-MM-DD format.
        /// </summary>
        /// <param name="dt">DateTime as UTC</param>
        /// <returns>String in swedish local time, and classic swedish format.</returns>
        public static string FormatSwedish(this DateTime dt)
        {
            return dt.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
        }

    }
}