using System;
using System.Collections.ObjectModel;
using System.Linq;
using Library.Commands;
using Library.Core.Model;
using Library.Core.Service.Interface;
using Library.GUI.LibrarianMemberships.UserRegistration.Command;
using Library.ViewModel;

namespace Library.GUI.LibrarianMemberships.UserRegistration.ViewModel;

public class UserRegistrationViewModel : ViewModelBase
{
    private ObservableCollection<MembershipTypeViewModel> _memberships;
    private readonly IMembersService _membershipCollectionService;
    private MembershipTypeViewModel? _selectedMembership;
    
    public MembershipTypeViewModel? SelectedMembership
    {
        get => _selectedMembership;
        set
        {
            _selectedMembership = value;
            OnPropertyChanged(nameof(SelectedMembership));
        }
    }

    public ObservableCollection<MembershipTypeViewModel> Memberships
    {
        get { return _memberships; }
        set
        {
            _memberships = value;
            OnPropertyChanged(nameof(Membership));
        }
    }

    private string _email = "";
    private string _jmbg = "";
    private string _name = "";
    private string _surname = "";
    private string _phone = "";

    public string Error { get; set; } = "";

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }
    public string JMBG
    {
        get => _jmbg;
        set
        {
            _jmbg = value;
            OnPropertyChanged(nameof(JMBG));
        }
    }
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    public string Surname
    {
        get => _surname;
        set
        {
            _surname = value;
            OnPropertyChanged(nameof(Surname));
        }
    }
    public string Phone
    {
        get => _phone;
        set
        {
            _phone = value;
            OnPropertyChanged(nameof(Phone));
        }
    }

    public CommandBase RegisterUser { get; }

    public UserRegistrationViewModel(IMembersService membershipCollectionService)
    {
        _membershipCollectionService = membershipCollectionService;
        _memberships = new();
        RegisterUser = new RegisterUserCommand(this, membershipCollectionService);

        LoadMemberships();
        RegisterUser.ExcecutionCompleted += ExecutionCompleted;
    }

    public void LoadMemberships()
    {
        _memberships.Clear();
        foreach (Membership m in _membershipCollectionService.GetAllMemberships())
        {
            _memberships.Add(new MembershipTypeViewModel(m));
        }
    }
}