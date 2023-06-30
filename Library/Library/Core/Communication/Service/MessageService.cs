using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository;
using Library.Repository.Interface;

namespace Library.Service.MessageService
{
    public class MessageService : IMessageService
    {
        private IMessageRepository _repo;

        public MessageService(IMessageRepository repo)
        {
            _repo = repo;
        }

        private void Add(Message message)
        {
            _repo.Add(message);
        }
        public void Add(string messageText, string senderUsername, string recipientUsername)
        {
            Add(new Message(senderUsername,recipientUsername, messageText, DateTime.Now));
        }

        public void Update(Message message)
        {
            _repo.Update(message);
        }

        public Dictionary<int, Message> GetAll()
        {
            return _repo.GetAll();
        }

        public Dictionary<int, Message> GetByParticipants(string username1, string username2)
        {
            return _repo.GetByParticipants(username1, username2);
        }
    }
}
