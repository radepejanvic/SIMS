using Library.Core.Model;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection
{
    public class LibrarianCollectionViewModel : ViewModelBase
    {
        private readonly User _user;
        public LibrarianCollectionViewModel(User user)
        {
            _user = user;
        }
    }
}
