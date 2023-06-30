using Library.Core.Model;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.Member
{
    public class MemberViewModel : ViewModelBase
    {
        private readonly User _user;
        public MemberViewModel(User user)
        {
            _user = user;
        }
    }
}
