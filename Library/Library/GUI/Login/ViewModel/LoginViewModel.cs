using System.Windows.Input;
using Library.Commands;
using Library.Service.TehnicalService.Interface;

namespace Library.ViewModel
{
    public class LoginViewModel : ViewModelBase
	{

		private string _userName;
		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = value;
				OnPropertyChanged(nameof(UserName));
			}
		}

		private string _password;
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
			}
		}

		public ICommand SubmitCommand { get; }

		private readonly MainViewModel _mainViewModel;
		public MainViewModel MainViewModel => _mainViewModel;
		public LoginViewModel(MainViewModel mainViewModel, ILoginService login)
		{
			_mainViewModel = mainViewModel;
            SubmitCommand = new LoginCommand(this,mainViewModel,login);

		}   
    }
}
