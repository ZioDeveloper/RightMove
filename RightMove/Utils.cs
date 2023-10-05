using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace RightMove
{
    public static class Utils
    {
        public static string AppUser = "";
        public static string AppPassword = "";

        public static bool IsAuth = false;
        public static string AppOperatorID = "";

        public static string GetConnectionStringByName(string aName)
        {
            string returnValue = "";
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[aName];
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        public static string GetConnectionStringComplete(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
            {
                returnValue = settings.ConnectionString + "User ID=vig" + ";Password=vespa;Connection Timeout=3000";
            }
            return returnValue;
        }

        public static string Right(this string str, int length)
        {
            str = (str ?? string.Empty);
            return (str.Length >= length)
                ? str.Substring(str.Length - length, length)
                : str;
        }

        public static string Left(this string str, int length)
        {
            str = (str ?? string.Empty);
            return str.Substring(0, Math.Min(length, str.Length));
        }

        public static string DQuotedStr(this string aString)
        {
            return "\"" + aString + "\"";
        }

        public static string QuotedStr(this string aString)
        {
            return "'" + aString + "'";
        }

        
    }
}
