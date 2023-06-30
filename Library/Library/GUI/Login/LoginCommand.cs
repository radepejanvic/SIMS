using System;
using System.ComponentModel;
using Library.Commands;
using Library.Core.Enum;
using Library.Core.TehnicalService.Interface;
using Library.GUI.Admin;
using Library.GUI.LibrarianCollection;
using Library.GUI.LibrarianMemberships;
using Library.GUI.Member;

namespace Library.GUI.Login;

public class LoginCommand : CommandBase
{
    private readonly LoginViewModel _loginViewModel;
        private readonly MainViewModel _mainViewModel;
        private readonly ILoginService _loginService;

        public LoginCommand(LoginViewModel loginViewModel, MainViewModel mainViewModel, ILoginService loginService)
        {
            _loginViewModel = loginViewModel;
            _mainViewModel = mainViewModel;
            _loginService = loginService;
            _loginViewModel.PropertyChanged += OnViewModelPropertyChanged;

        }

        public override bool CanExecute(object? parameter)
        {
            return !(String.IsNullOrEmpty(_loginViewModel.Username)) && !(String.IsNullOrEmpty(_loginViewModel.Password));
        }
        public override void Execute(object? parameter)
        {
            var user = _loginService.Login(_loginViewModel.Username, _loginViewModel.Password);
            if (user is null) { OnExecutionCompleted(false, "Neispravno uneti podaci."); return; }
           
            switch (user.UserType)
            {
                case UserType.ADMIN:
                    _mainViewModel.CurrentViewModel = new AdminViewModel(user);
                    break;
                case UserType.MEMBER:
                    _mainViewModel.CurrentViewModel = new MemberViewModel(user);
                    break;
                case UserType.LIBRARIAN_COLLECTION:
                    _mainViewModel.CurrentViewModel = new LibrarianCollectionViewModel(user);
                    break;
                case UserType.LIBRARIAN_MEMBERSHIPS:
                    _mainViewModel.CurrentViewModel = new LibrarianMembershipsViewModel(user);
                    break;
                default:
                    OnExecutionCompleted(false, "Greška prilikom otvaranja prozora.");
                    break;
            }
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_loginViewModel.Username)||
                e.PropertyName == nameof(_loginViewModel.Password))
            {
                OnCanExecutedChanged();
            }
        }
       
}