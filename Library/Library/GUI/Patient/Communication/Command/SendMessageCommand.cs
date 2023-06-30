using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.MessageService;
using Library.ViewModel.Form.Survey;
using Library.ViewModel.Table.Chat;

namespace Library.Commands.Chat
{
    public class SendMessageCommand : CommandBase
    {
        private ChatTableViewModel _chatTableViewModel;
        private IMessageService _messageService;
        private string _senderUsername;
        private string _recipientUsername;
        public SendMessageCommand(IMessageService messageService, ChatTableViewModel chatTableViewModel, string senderUsername, string recipientUsername) 
        {
            _chatTableViewModel = chatTableViewModel;
            _messageService = messageService;
            _senderUsername = senderUsername;
            _recipientUsername = recipientUsername;
            _chatTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_chatTableViewModel.MessageToSend);
        }

        public override void Execute(object? parameter)
        {
            _messageService.Add(_chatTableViewModel.MessageToSend, _senderUsername, _recipientUsername);
            OnExecutionCompleted(true, "Anketa je uspesno sacuvana.");
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_chatTableViewModel.MessageToSend))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
