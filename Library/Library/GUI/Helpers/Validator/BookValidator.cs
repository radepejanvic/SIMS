using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.Helpers.Validation
{
    public static class BookValidator
    {
        public static bool CheckPublicationYear(string year)
        {
            return DateTime.TryParseExact(year, "yyyy.", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        public static bool CheckISBN(string ISBN)
        {
            return ISBN?.Length == 13;
        }

        public static bool CheckUDK(string UDK)
        {
            return UDK?.Length == 10;
        }
    }
}
