using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Commands;
using Library.Core.Model;
using Library.Core.Service.Interface;
using Library.GUI.LibrarianCollection.BookRetrieval.ViewModel;

namespace Library.GUI.LibrarianCollection.BookRetrieval
{
    public class BookRetrievalViewModel : ViewModelBase
    {
        private ObservableCollection<LoanViewModel> _loans;
        public ObservableCollection<LoanViewModel> Loans
        {
            get
            {
                return _loans;
            }
            set
            {
                _loans = value;
                OnPropertyChanged(nameof(Loans));
            }
        }

        private LoanViewModel _selectedLoan;
        public LoanViewModel SelectedLoan
        {
            get
            {
                return _selectedLoan;
            }
            set
            {
                _selectedLoan = value;
                OnPropertyChanged(nameof(SelectedLoan));
            }
        }
        
        private string _searchLoans;
        public string SearchLoans
        {
            get
            {
                return _searchLoans;
            }
            set
            {
                _searchLoans = value;
                OnPropertyChanged(nameof(SearchLoans));
            }
        }

        public CommandBase CreateLoan { get; }
        public CommandBase LossPenaltyEnforcement { get; }
        public CommandBase DamagePenaltyEnforcement { get; }
        
        private readonly ILoaningService _loaningService;

        public BookLoaningViewModel(ILoaningService loaningService)
        {
            _loaningService = loaningService;
            // CreateLoan = new CreateLoanCommand(this, loaningService);
            LoadAllLoans();
            PropertyChanged += OnPropertyChanged;
            // CreateLoan.ExcecutionCompleted += ExecutionCompleted;
        }

        public void LoadAllLoans()
        {
            _loans.Clear();
            foreach (Loan loan in _loaningService.GetAll().Values) 
            {
                _loans.Add(new LoanViewModel(loan));
            }
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SearchLoans) && !string.IsNullOrEmpty(SearchLoans))
            {
                var filtered = _loans.Where(loan => loan.Contains(SearchLoans)).ToList();
                CopyFilteredLoans(filtered);
            }
            else if (e.PropertyName == nameof(SearchLoans))
            {
                LoadAllLoans();
            }
        }

        private void CopyFilteredLoans(List<LoanViewModel> filtered)
        {
            _loans.Clear();
            foreach (LoanViewModel loan in filtered)
            {
                _loans.Add(loan);
            }
        }
        
    }
}
