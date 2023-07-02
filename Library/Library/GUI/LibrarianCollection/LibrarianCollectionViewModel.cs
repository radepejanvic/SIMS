using Library.Core.Model;
using Library.GUI.LibrarianCollection.Commands;
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

        public LibrarianCollectionViewModel(User user)
        {
            _user = user;

            OpenTitleRegistration = new OpenTitleRegistrationCommand();
            OpenCopyRegistration = new OpenCopyRegistrationCommand();
            OpenBookLoaning = new OpenBookLoaningCommand();
            OpenBookRetrieval = new OpenBookRetrievalCommand();
            OpenReports = new OpenReportsCommand();
        }
    }
}
