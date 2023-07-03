using System;
using Library.Core.Model;
using Library.ViewModel;

namespace Library.GUI.LibrarianCollection.BookRetrieval.ViewModel;

public class LoanViewModel : ViewModelBase
{
    private readonly Loan _loan;
    public int Id => _loan.Id;
    public string InventoryNumber => _loan.InventoryNumber;
    public int MembershipCardId => _loan.MembershipCardId;
    public DateTime ExpirationDate => _loan.ExpirationDate;

    public LoanViewModel()
    {
        
    }

    public LoanViewModel(Loan loan)
    {
        _loan = loan;
    }
}
