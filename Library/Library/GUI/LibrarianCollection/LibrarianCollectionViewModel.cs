using Library.Core.Model;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.GUI.LibrarianCollection
{
    public class LibrarianCollectionViewModel : ViewModelBase
    {
        private readonly User _user;

        public ICommand OpenBookLoaning { get; }
        public ICommand OpenBookRetrieval { get; }

        public LibrarianCollectionViewModel(User user)
        {
            _user = user;
        }
    }
}
