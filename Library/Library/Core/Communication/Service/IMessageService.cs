using System.Collections.Generic;
using Library.Model;

namespace Library.Service.MessageService
{
    public interface IMessageService
    {
        void Add(string messageText, string senderUsername, string recipientUsername);
        Dictionary<int, Message> GetAll();
        Dictionary<int, Message> GetByParticipants(string username1, string username2);
        void Update(Message message);
    }
}