using System.Windows.Input;
using Library.Commands;
using Library.Core.TehnicalService.Interface;

namespace Library.ViewModel
{
    public class LoginViewModel : ViewModelBase
	{

		private string _username;
		public string Username
		{
			get
			{
				return _username;
			}
			set
			{
				_username = value;
				OnPropertyChanged(nameof(Username));
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

		public CommandBase SubmitCommand { get; }

		private readonly MainViewModel _mainViewModel;
		public MainViewModel MainViewModel => _mainViewModel;
		public LoginViewModel(MainViewModel mainViewModel, ILoginService login)
		{
			_mainViewModel = mainViewModel;
            SubmitCommand = new LoginCommand(this,mainViewModel,login);
            SubmitCommand.ExcecutionCompleted += ExecutionCompleted;
        }   
    }
}
