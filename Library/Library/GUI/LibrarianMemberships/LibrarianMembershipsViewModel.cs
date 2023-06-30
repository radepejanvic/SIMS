using Library.Core.Model;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianMemberships
{
    public class LibrarianMembershipsViewModel : ViewModelBase
    {
        private readonly User _user;
        public LibrarianMembershipsViewModel(User user)
        {
            _user = user;
        }
    }
}
