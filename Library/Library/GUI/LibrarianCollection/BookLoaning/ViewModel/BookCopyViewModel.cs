using Library.ViewModel;
using Library.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.BookLoaning.ViewModel
{
    public class BookCopyViewModel : ViewModelBase
    {
        private readonly BookCopy _bookCopy;
        private readonly string _title;

        public int Id => _bookCopy.Id;
        public string ISBN => _bookCopy.ISBN;
        public string InventoryNumber => _bookCopy.InventoryNumber;
        public float Price => _bookCopy.Price;
        public string Title => _title;

        public BookCopyViewModel(BookCopy bookCopy, string title)
        {
            _bookCopy = bookCopy;
            _title = title;
        }

        public bool Contains(string keyword)
        {
            return $"{Id}--{ISBN}--{InventoryNumber}--{Title}".ToLower().Contains(keyword.ToLower());
        }
    }
}
