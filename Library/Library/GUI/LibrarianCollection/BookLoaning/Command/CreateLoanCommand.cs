using Library.Commands;
using Library.Core.Service.Interface;
using Library.GUI.LibrarianCollection.BookLoaning.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.BookLoaning.Command
{
    public class CreateLoanCommand : CommandBase
    {
        private readonly BookLoaningViewModel _bookLoaningViewModel;
        private readonly ILoaningService _loaningService;

        public CreateLoanCommand(BookLoaningViewModel bookLoaningViewModel, ILoaningService loaningService)
        {
            _bookLoaningViewModel = bookLoaningViewModel;
            _loaningService = loaningService;
            _bookLoaningViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        

        public override bool CanExecute(object? parameter)
        {
            return (_bookLoaningViewModel.SelectedBookCopy is not null) &&
                (_bookLoaningViewModel.SelectedMember is not null) &&
                !_loaningService.HasReachedTheLimit(_bookLoaningViewModel.SelectedMember.MembershipCardId);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _loaningService.LoanBook(_bookLoaningViewModel.SelectedMember.MembershipCardId, _bookLoaningViewModel.SelectedBookCopy.Id);
                _bookLoaningViewModel.LoadAllBookCopies();
                OnExecutionCompleted(true, "Uspešno ste kreirali pozajmicu.");
            }
            catch (Exception)
            {
                OnExecutionCompleted(false, "Greška prilikom kreiranja pozajmice!");
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_bookLoaningViewModel.SelectedMember) ||
                e.PropertyName == nameof(_bookLoaningViewModel.SelectedBookCopy))
            {
                OnCanExecutedChanged();
            }
        }

    }
}
