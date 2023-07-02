using Library.Commands;
using Library.Core.Model;
using Library.Core.Service;
using Library.GUI.LibrarianCollection.BookLoaning.Command;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.BookLoaning.ViewModel
{
    public class BookLoaningViewModel : ViewModelBase
    {
        private ObservableCollection<PersonMembershipCardViewModel> _members;
        public ObservableCollection<PersonMembershipCardViewModel> Members
        {
            get
            {
                return _members;
            }
            set
            {
                _members = value;
                OnPropertyChanged(nameof(Members));
            }
        }

        private PersonMembershipCardViewModel _selectedMember;
        public PersonMembershipCardViewModel SelectedMember
        {
            get
            {
                return _selectedMember;
            }
            set
            {
                _selectedMember = value;
                OnPropertyChanged(nameof(SelectedMember));
            }
        }

        private ObservableCollection<BookCopyViewModel> _bookCopies;
        public ObservableCollection<BookCopyViewModel> BookCopies
        {
            get
            {
                return _bookCopies;
            }
            set
            {
                _bookCopies = value;
                OnPropertyChanged(nameof(BookCopies));
            }
        }

        private BookCopyViewModel _selectedBookCopy;
        public BookCopyViewModel SelectedBookCopy
        {
            get
            {
                return _selectedBookCopy;
            }
            set
            {
                _selectedBookCopy = value;
                OnPropertyChanged(nameof(SelectedBookCopy));
            }
        }

        private string _searchMembers;
        public string SearchMembers
        {
            get
            {
                return _searchMembers;
            }
            set
            {
                _searchMembers = value;
                OnPropertyChanged(nameof(SearchMembers));
            }
        }

        private string _searchBookCopies;
        public string SearchBookCopies
        {
            get
            {
                return _searchBookCopies;
            }
            set
            {
                _searchBookCopies = value;
                OnPropertyChanged(nameof(SearchBookCopies));
            }
        }

        public CommandBase CreateLoan { get; }

        private readonly IMembersService _membersService;
        private readonly ILoaningService _loaningService;

        public BookLoaningViewModel(IMembersService membersService, ILoaningService loaningService)
        {
            _membersService = membersService;
            _loaningService = loaningService;
            _members = new ObservableCollection<PersonMembershipCardViewModel>();
            _bookCopies = new ObservableCollection<BookCopyViewModel>();
            CreateLoan = new CreateLoanCommand(this, loaningService);
            LoadAllMembers();
            LoadAllBookCopies();
            PropertyChanged += OnPropertyChanged;
            CreateLoan.ExcecutionCompleted += ExecutionCompleted;
        }

        private void LoadAllMembers()
        {
            _members.Clear();
            foreach (PersonMembershipCardDTO member in _membersService.GetAllPersonMembershipCardDTOs().Values)
            {
                _members.Add(new PersonMembershipCardViewModel(member));
            }
        }

        public void LoadAllBookCopies()
        {
            _bookCopies.Clear();
            foreach (BookCopy bookCopy in _loaningService.GetAllAvaliableBooks().Values)
            {
                _bookCopies.Add(new BookCopyViewModel(bookCopy));
            }
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SearchMembers) && !string.IsNullOrEmpty(SearchMembers))
            {
                var filtered = _members.Where(member => member.Contains(SearchMembers)).ToList();
                CopyFilteredMembers(filtered);
            }
            else if (e.PropertyName == nameof(SearchMembers))
            {
                LoadAllMembers();
            }
            else if (e.PropertyName == nameof(SearchBookCopies) && !string.IsNullOrEmpty(SearchBookCopies))
            {
                var filtered = _bookCopies.Where(bookCopy => bookCopy.Contains(SearchBookCopies)).ToList();
                CopyFilteredBookCopies(filtered);
            }
            else if (e.PropertyName == nameof(SearchBookCopies))
            {
                LoadAllBookCopies();
            }
        }

        private void CopyFilteredMembers(List<PersonMembershipCardViewModel> filtered)
        {
            _members.Clear();
            foreach (PersonMembershipCardViewModel member in filtered)
            {
                _members.Add(member);
            }
        }

        private void CopyFilteredBookCopies(List<BookCopyViewModel> filtered)
        {
            _bookCopies.Clear();
            foreach (BookCopyViewModel bookCopy in filtered)
            {
                _bookCopies.Add(bookCopy);
            }
        }


    }
}
