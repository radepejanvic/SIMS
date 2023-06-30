using Library.Core.Model;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.Admin
{
    public class AdminViewModel : ViewModelBase
    {
        private readonly User _user;
        public AdminViewModel(User user)
        {
            _user = user;
        }
    }
}
