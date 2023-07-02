using Library.Core.Model;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.TitleRegistration.ViewModel
{
    public class AuthorViewModel : ViewModelBase
    {
        private readonly Author _author;

        public int Id => _author.Id;
        public string Name => _author.Name;
        public string Surname => _author.Surname;

        public AuthorViewModel(Author author)
        {
            _author = author;
        }

        public bool Contains(string keyword)
        {
            return $"{Id}--{Name}--{Surname}".ToLower().Contains(keyword.ToLower());
        }
    }
}
