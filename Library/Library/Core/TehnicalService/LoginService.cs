using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock.Layout;
using Library.Model;
using Library.ViewModel;
using System.Windows;
using System.Security.AccessControl;
using System.Data.SqlTypes;
using System.Timers;
using Library.Repository.Interface;
using Library.Core.Repository.Interface;
using Library.Core.Model;
using Library.Core.Enum;
using Library.Core.TehnicalService.Interface;

namespace Library.Service.TehnicalService
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepo;

        public LoginService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public User? Login(string username, string password)
        {
            var user = _userRepo.Get(username);
            return (user is not null && user.CheckPassword(password)) ? user : null;
        }
    }
}
