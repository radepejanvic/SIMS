using Autofac;
using Library.Configuration;
using Library.Core.Model;
using Library.Core.Service.Interface;
using Library.Core.TehnicalService.Interface;
using Library.GUI.LibrarianCollection.Commands;
using Library.Service.TehnicalService;
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
        public ICommand OpenTitleRegistration { get; }
        public ICommand OpenCopyRegistration { get; }
        public ICommand OpenBookLoaning { get; }
        public ICommand OpenBookRetrieval { get; }
        public ICommand OpenReports { get; }

        private readonly IMembersService _membersService;
        private readonly ILoaningService _loaningService;
        private readonly IBookCollectionService _bookCollectionService;
        private readonly IPaymentService _paymentService;

        public LibrarianCollectionViewModel(User user)
        {
            var container = ContainerConfiguration.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                _membersService = scope.Resolve<IMembersService>();
                _loaningService = scope.Resolve<ILoaningService>();
                _bookCollectionService = scope.Resolve<IBookCollectionService>();
                _paymentService = scope.Resolve<IPaymentService>();
            }
                _user = user;

            OpenTitleRegistration = new OpenTitleRegistrationCommand(_bookCollectionService);
            OpenCopyRegistration = new OpenCopyRegistrationCommand(_bookCollectionService);
            OpenBookLoaning = new OpenBookLoaningCommand(_membersService, _loaningService);
            OpenBookRetrieval = new OpenBookRetrievalCommand(_loaningService, _paymentService);
            OpenReports = new OpenReportsCommand();
        }
    }
}
