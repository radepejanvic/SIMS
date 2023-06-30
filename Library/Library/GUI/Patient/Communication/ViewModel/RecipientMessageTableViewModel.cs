using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.Service.MessageService;
using Library.Service.PersonService.Interface;
using Library.View.Table.Chat;
using Library.ViewModel.Structure;

namespace Library.ViewModel.Table.Chat
{
    public class RecipientMessageTableViewModel : ViewModelBase
    {
		private ObservableCollection<ColleguesViewModel> _collegues;
		public ObservableCollection<ColleguesViewModel> Collegues
		{
			get
			{
				return _collegues;
			}
			set
			{
				_collegues = value;
				OnPropertyChanged(nameof(Collegues));
			}
		}
		private ColleguesViewModel _selectedCollegue;
		public ColleguesViewModel SelectedCollegue
		{
			get
			{
				return _selectedCollegue;
			}
			set
			{
				_selectedCollegue = value;
				OnPropertyChanged(nameof(SelectedCollegue));
			}
		}
		public ICommand OpenMessagesCommand { get; }
        public ICommand CloseCommand { get; }
		private Patient _patient;
		private IMessageService _messageService;
		private INurseService _nurseService;
		private IDoctorService _doctorService;
        public RecipientMessageTableViewModel(Window window, Patient patient, IMessageService messageService, INurseService nurseService, IDoctorService doctorService)
        {
			_patient = patient;
			_messageService = messageService;
			_nurseService = nurseService;
			_doctorService = doctorService;
			_collegues = new ObservableCollection<ColleguesViewModel>();
			LoadCollegues();
			OpenMessagesCommand = new RelayCommand(OpenMessages, CanOpen);
			CloseCommand = new CloseCommand(window);
        }

		private bool CanOpen()
		{
			return SelectedCollegue != null;
		}

		private void OpenMessages()
		{
            var chatView = new ChatTableView();
            chatView.DataContext = new ChatTableViewModel(chatView, _patient.Username, SelectedCollegue.Username, _messageService);
            chatView.ShowDialog();
        }

		private void LoadCollegues()
		{
            foreach(var person in _nurseService.GetAll().Values)
			{
				_collegues.Add(new ColleguesViewModel(person.FirstName, person.LastName,person.Username, "Medicinska sestra"));
			}
			foreach(var person in _doctorService.GetAll().Values)
			{
				_collegues.Add(new ColleguesViewModel(person.FirstName, person.LastName, person.Username, "Doktor"));
			}

        }
    }
}
