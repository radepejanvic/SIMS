using Library.Core.Model;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using Library.Configuration;
using Library.Core.Service.Interface;
using Library.GUI.LibrarianMemberships.Commands;

namespace Library.GUI.LibrarianMemberships
{
    public class LibrarianMembershipsViewModel : ViewModelBase
    {
        private readonly User _user;
        public ICommand OpenUserRegistration { get; }
        
        private readonly IMembersService _membersService;
        private readonly ILoaningService _loaningService;
        private readonly IBookCollectionService _bookCollectionService;
        
        public LibrarianMembershipsViewModel(User user)
        {
            var container = ContainerConfiguration.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                _membersService = scope.Resolve<IMembersService>();
                _loaningService = scope.Resolve<ILoaningService>();
                _bookCollectionService = scope.Resolve<IBookCollectionService>();
            }
            
            _user = user;
            
            OpenUserRegistration = new OpenUserRegistrationCommand(_membersService);
        }
    }
}
