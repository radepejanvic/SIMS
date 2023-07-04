using Library.Core.Enum;
using Library.Core.Model;
using Library.ViewModel;

namespace Library.GUI.LibrarianMemberships.UserRegistration.ViewModel;

public class MembershipTypeViewModel : ViewModelBase
{
    public readonly Membership Membership;

    public int Id => Membership.Id;
    public string MembershipType => Membership.MembershipType.ToString();
    public float Price => Membership.Price;
    public int LoanCount =>  Membership.LoanCount;
    public int LoanDuration =>  Membership.LoanDuration;
    public float FinePerDay =>  Membership.FinePerDay;
        
    private bool _isSelected;
    public bool IsSelected
    {
        get
        {
            return _isSelected;
        }
        set
        {
            _isSelected = value;
            OnPropertyChanged(nameof(IsSelected));
        }
    }

    public MembershipTypeViewModel(Membership membership)
    {
        Membership = membership;
    }
}