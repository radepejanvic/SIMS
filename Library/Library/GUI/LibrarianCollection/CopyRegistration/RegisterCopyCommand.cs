using Library.Commands;
using Library.Core.Model;
using Library.Core.Service.Interface;
using Library.GUI.Helpers.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.CopyRegistration
{
    public class RegisterCopyCommand : CommandBase
    {
        private readonly CopyRegistrationViewModel _copyRegistrationViewModel;
        private readonly IBookCollectionService _bookCollectionService;

        public RegisterCopyCommand(CopyRegistrationViewModel bookLoaningViewModel, IBookCollectionService bookCollectionService)
        {
            _copyRegistrationViewModel = bookLoaningViewModel;
            _bookCollectionService = bookCollectionService;
            _copyRegistrationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return (_copyRegistrationViewModel.SelectedBranch is not null) &&
            (_copyRegistrationViewModel.SelectedTitle is not null) &&
             !string.IsNullOrEmpty(_copyRegistrationViewModel.InventoryNumber) &&
            BookValidator.CheckInventoryNumber(_copyRegistrationViewModel.InventoryNumber) &&
            _bookCollectionService.IsUniqueInventoryNumber(_copyRegistrationViewModel.InventoryNumber) &&
            BookValidator.CheckPrice(_copyRegistrationViewModel.Price);
        }

        public override void Execute(object? parameter)
        {
            try
            {  
                _bookCollectionService.RegisterBookCopy(new BookCopy(_copyRegistrationViewModel.SelectedTitle.Id,
                    _copyRegistrationViewModel.SelectedBranch.Id,
                    _copyRegistrationViewModel.SelectedTitle.ISBN,
                    _copyRegistrationViewModel.InventoryNumber,
                    _copyRegistrationViewModel.Price, DateTime.Now));
                OnExecutionCompleted(true, "Uspešno ste registrovali primerak.");
            }
            catch (Exception)
            {
                OnExecutionCompleted(false, "Greška prilikom registrovanja primerka!");
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_copyRegistrationViewModel.InventoryNumber) ||
                e.PropertyName == nameof(_copyRegistrationViewModel.SelectedBranch) ||
                e.PropertyName == nameof(_copyRegistrationViewModel.Price) ||
                e.PropertyName == nameof(_copyRegistrationViewModel.SelectedTitle))
            {
                OnCanExecutedChanged();
            }
        }

    }
}
