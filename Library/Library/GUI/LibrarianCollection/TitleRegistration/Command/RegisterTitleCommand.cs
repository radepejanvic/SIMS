using Library.Commands;
using Library.Core.Model;
using Library.Core.Service.Interface;
using Library.GUI.Helpers.Validation;
using Library.GUI.LibrarianCollection.BookLoaning.ViewModel;
using Library.GUI.LibrarianCollection.TitleRegistration.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.TitleRegistration.Command
{
    public class RegisterTitleCommand : CommandBase
    {
        private readonly TitleRegistrationViewModel _titleRegistrationViewModel;
        private readonly IBookCollectionService _bookCollectionService;

        public RegisterTitleCommand(TitleRegistrationViewModel bookLoaningViewModel, IBookCollectionService bookCollectionService)
        {
            _titleRegistrationViewModel = bookLoaningViewModel;
            _bookCollectionService = bookCollectionService;
            _titleRegistrationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return (_titleRegistrationViewModel.SelectedPublisher is not null) &&
            BookValidator.CheckAuthors(_titleRegistrationViewModel.GetAllSelectedAuthors()) &&
            BookValidator.CheckISBN(_titleRegistrationViewModel.ISBN) &&
            BookValidator.CheckPublicationYear(_titleRegistrationViewModel.PublicationYear) &&
            (!string.IsNullOrEmpty(_titleRegistrationViewModel.Title)) &&
            (!string.IsNullOrEmpty(_titleRegistrationViewModel.Description));
        }

        public override void Execute(object? parameter)
        {
            try
            {
                var bookTitle = new BookTitle(_titleRegistrationViewModel.SelectedPublisher.Id,
                    _titleRegistrationViewModel.Title,
                    _titleRegistrationViewModel.GetPublicationDate(),
                    _titleRegistrationViewModel.Description,
                    _titleRegistrationViewModel.SelectedLanguage,
                    _titleRegistrationViewModel.SelectedCover,
                    _titleRegistrationViewModel.ISBN,
                    _titleRegistrationViewModel.UDK);
                _bookCollectionService.RegisterBookTitle(_titleRegistrationViewModel.GetAllSelectedAuthors(), bookTitle);
                OnExecutionCompleted(true, "Uspešno ste registrovali naslov.");
            }
            catch (Exception)
            {
                OnExecutionCompleted(false, "Greška prilikom registrovanja naslova!");
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_titleRegistrationViewModel.Title) ||
                e.PropertyName == nameof(_titleRegistrationViewModel.PublicationYear) ||
                e.PropertyName == nameof(_titleRegistrationViewModel.Description) ||
                e.PropertyName == nameof(_titleRegistrationViewModel.SelectedLanguage) ||
                e.PropertyName == nameof(_titleRegistrationViewModel.SelectedCover) ||
                e.PropertyName == nameof(_titleRegistrationViewModel.ISBN) ||
                e.PropertyName == nameof(_titleRegistrationViewModel.UDK) ||
                e.PropertyName == nameof(_titleRegistrationViewModel.SelectedPublisher))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
