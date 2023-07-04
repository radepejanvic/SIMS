using Library.Commands;
using Library.GUI.LibrarianCollection.BookRetrieval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Service.Interface;
using Library.GUI.LibrarianCollection.BookRetrieval.ViewModel;

namespace Library.GUI.LibrarianCollection.Commands
{
    public class OpenBookRetrievalCommand : CommandBase
    {
        private readonly ILoaningService _loaningService;
        private readonly IPaymentService _paymentService;
        public OpenBookRetrievalCommand(ILoaningService loaningService, IPaymentService paymentService)
        {
            _loaningService = loaningService;
            _paymentService = paymentService;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var popup = new BookRetrievalView();
            popup.DataContext = new BookRetrievalViewModel(_loaningService, _paymentService);
            popup.ShowDialog();
        }
    }
}
