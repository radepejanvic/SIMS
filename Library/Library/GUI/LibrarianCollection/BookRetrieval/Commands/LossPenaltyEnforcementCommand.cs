using Library.Commands;
using Library.Core.Enum;
using Library.Core.Model;
using Library.Core.Service;
using Library.Core.Service.Interface;
using Library.GUI.LibrarianCollection.BookRetrieval.Commands;
using Library.GUI.LibrarianCollection.BookRetrieval.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.BookRetrieval.Commands
{
    public class LossPenaltyEnforcementCommand : CommandBase
    {
        private readonly BookRetrievalViewModel _bookRetrievalViewModel;
        private readonly IPaymentService _paymentService;
        private readonly ILoaningService _loaningService;

        public LossPenaltyEnforcementCommand(BookRetrievalViewModel bookRetrievalViewModel, IPaymentService paymentService, ILoaningService loaningService)
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
                var priceForLoss = _paymentService.GetPrice(_bookRetrievalViewModel.SelectedLoan.InventoryNumber);
                var payment = new Payment(_bookRetrievalViewModel.SelectedLoan.MembershipCardId, priceForLoss, DateTime.Now, PaymentReason.LOSS);
                _paymentService.Add(payment);

                var priceForDelay = _paymentService.GetPrice(_bookRetrievalViewModel.SelectedLoan.MembershipCardId,
                   _bookRetrievalViewModel.SelectedLoan.ExpirationDate);

                if (priceForDelay > 0)
                {
                    var paymentForDelay = new Payment(_bookRetrievalViewModel.SelectedLoan.MembershipCardId, priceForDelay, DateTime.Now,
                        PaymentReason.DELAY);
                    _paymentService.Add(paymentForDelay);
                    var messageForDelay = "Uspešno ste naplatili kaznu za kasnjenje u iznosu od " + priceForDelay + " dinara.";
                    OnExecutionCompleted(true, messageForDelay);
                }

                _loaningService.RetrieveBook(_bookRetrievalViewModel.SelectedLoan.Id);
                _loaningService.RemoveBookCopy(_bookRetrievalViewModel.SelectedLoan.InventoryNumber);

                _bookRetrievalViewModel.LoadAllLoans();
                var message = "Uspešno ste naplatili kaznu za gubljenje u iznosu od " + priceForLoss + " dinara.";
                OnExecutionCompleted(true, message);
            }
            catch (Exception)
            {
                OnExecutionCompleted(false, "Greška prilikom obracuna kazne!");
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