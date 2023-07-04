using Library.Commands;
using Library.Core.Enum;
using Library.Core.Model;
using Library.Core.Service.Interface;
using Library.GUI.LibrarianCollection.BookRetrieval.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.BookRetrieval.Commands
{
    public class ReturnCommand : CommandBase
    {
        private readonly BookRetrievalViewModel _bookRetrievalViewModel;
        private readonly IPaymentService _paymentService;
        private readonly ILoaningService _loaningService;

        public ReturnCommand(BookRetrievalViewModel bookRetrievalViewModel, IPaymentService paymentService, ILoaningService loaningService)
        {
            _bookRetrievalViewModel = bookRetrievalViewModel;
            _paymentService = paymentService;
            _loaningService = loaningService;
            _bookRetrievalViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }



        public override bool CanExecute(object? parameter)
        {
            return (_bookRetrievalViewModel.SelectedLoan is not null);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                var price = _paymentService.GetPrice(_bookRetrievalViewModel.SelectedLoan.MembershipCardId, 
                    _bookRetrievalViewModel.SelectedLoan.ExpirationDate);

                if (price > 0)
                {
                    var payment = new Payment(_bookRetrievalViewModel.SelectedLoan.MembershipCardId, price, DateTime.Now, PaymentReason.DELAY);
                    _paymentService.Add(payment);
                    var message = "Uspešno ste naplatili kaznu za kasnjenje u iznosu od " + price + " dinara.";
                    OnExecutionCompleted(true, message);
                }

                _loaningService.RetrieveBook(_bookRetrievalViewModel.SelectedLoan.Id);
                _bookRetrievalViewModel.LoadAllLoans();
                OnExecutionCompleted(true, "Uspešno ste vratili knjigu!");
            }
            catch (Exception)
            {
                OnExecutionCompleted(false, "Greška prilikom vracanja knjige!");
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_bookRetrievalViewModel.SelectedLoan))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
