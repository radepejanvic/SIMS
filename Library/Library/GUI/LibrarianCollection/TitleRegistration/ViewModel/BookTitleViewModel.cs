using Library.Core.Enum;
using Library.Core.Model;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.GUI.LibrarianCollection.TitleRegistration.ViewModel
{
    public class BookTitleViewModel : ViewModelBase
    {
        private readonly BookTitle _bookTitle;

        public int Id => _bookTitle.Id;
        public string Title => _bookTitle.Title;
        public string PublicationYear => _bookTitle.PublicationYear.ToString("yyyy.");
        public string Description => _bookTitle.Description;
        public Language Language => _bookTitle.Language;
        public CoverType Cover => _bookTitle.Cover;
        public string ISBN => _bookTitle.ISBN;
        public string UDK => _bookTitle.UDK;

        public BookTitleViewModel(BookTitle bookTitle)
        {
            _bookTitle = bookTitle;
        }

        public bool Contains(string keyword)
        {
            return $"{Id}--{Title}--{PublicationYear}--{Description}--{Title}--{Language}--{Cover}--{ISBN}--{UDK}".ToLower().Contains(keyword.ToLower());
        }
    }
}
