using Library.GUI.LibrarianCollection.Commands;
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
            return DateTime.TryParseExact(year, "yyyy.", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date) && date <= DateTime.Today;
        }

        public static bool CheckISBN(string ISBN)
        {
            return ISBN?.Length == 13;
        }

        public static bool CheckUDK(string UDK)
        {
            return UDK?.Length == 10;
        }

        public static bool CheckAuthors(List<int> authors)
        {
            return authors.Count != 0;
        }

        public static bool CheckPrice(float price)
        {
            return price >= 0;
        }

        public static bool CheckInventoryNumber(string inventoryNumber)
        {
            return inventoryNumber?.Length == 6;
        }
    }
}
