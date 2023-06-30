using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Library.Commands;
using Library.Commands.Chat;
using Library.EventArgument;
using Library.Model;
using Library.Service.MessageService;

namespace Library.ViewModel.Table.Chat
{
    public class ChatTableViewModel : ViewModelBase
    {
		private ObservableCollection<Message> _messages;
		public ObservableCollection<Message> Messages
		{
			get
			{
				return _messages;
			}
			set
			{
				_messages = value;
				OnPropertyChanged(nameof(Messages));
			}
		}
		private string _messageToSend;
		public string MessageToSend
        {
			get
			{
				return _messageToSend;
			}
			set
			{
				_messageToSend = value;
				OnPropertyChanged(nameof(MessageToSend));
			}
		}
        public CommandBase SendMessageCommand { get; }
		public ICommand CloseCommand { get; }
		private IMessageService _messageService;
		private string _senderUsername;
		private string _recipientUsername;
        private DispatcherTimer _timer;
        public ChatTableViewModel(Window window, string senderUsername, string recipientUsername, IMessageService messageService) 
        {
			_senderUsername = senderUsername;
			_recipientUsername = recipientUsername;
			_messageService = messageService;
			SendMessageCommand = new SendMessageCommand(messageService, this, senderUsername, recipientUsername);
            SendMessageCommand.ExcecutionCompleted += SendMessageCompleted;
            _messages = new ObservableCollection<Message>();
            LoadMessages();
            CloseCommand = new CloseCommand(window);
            _timer = new DispatcherTimer();
			_timer.Interval = TimeSpan.FromSeconds(10);
            _timer.Tick += Timer_Tick;
            _timer.Start();
            window.Closing += Window_Closing;
        }


        private void LoadMessages()
		{
			_messages.Clear();
			foreach(var message in _messageService.GetByParticipants(_senderUsername, _recipientUsername).Values)
			{
				_messages.Add(message);
			}

        }
		private void SendMessageCompleted(object? sender, ExecutionCompletedEventArgs e)
		{
            if (e.IsSuccessfull)
            {
				MessageToSend = "";
				LoadMessages();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadMessages();
        }
        private void Window_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();
            _timer.Tick -= Timer_Tick;
        }
    }
}
