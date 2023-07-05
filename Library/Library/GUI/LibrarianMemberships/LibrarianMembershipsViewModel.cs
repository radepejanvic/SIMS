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
using Library.GUI.LibrarianCollection.Commands;

namespace Library.GUI.LibrarianMemberships
{
    public class LibrarianMembershipsViewModel : ViewModelBase
    {
        private readonly User _user;
        public ICommand OpenUserRegistration { get; }
        
        private readonly IMembersService _membersService;
        private readonly ILoaningService _loaningService;
        private readonly IPaymentService _paymentService;

        public ICommand OpenBookLoaning { get; }
        public ICommand OpenBookRetrieval { get; }
        public ICommand OpenReports { get; }

        public LibrarianMembershipsViewModel(User user)
        {
            var container = ContainerConfiguration.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                _membersService = scope.Resolve<IMembersService>();
                _loaningService = scope.Resolve<ILoaningService>();
                _paymentService = scope.Resolve<IPaymentService>();
            }
            
            _user = user;
            
            OpenUserRegistration = new OpenUserRegistrationCommand(_membersService);
            OpenBookLoaning = new OpenBookLoaningCommand(_membersService, _loaningService);
            OpenBookRetrieval = new OpenBookRetrievalCommand(_loaningService, _paymentService);
            OpenReports = new OpenReportsCommand(_paymentService);
        }
    }
}
