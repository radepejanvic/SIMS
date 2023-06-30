using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private ICRUDRepository<Message> _repo;
        public MessageRepository(ICRUDRepository<Message> repo)
        {
            _repo = repo;
        }

        public void Add(Message message)
        {
            _repo.Add(message);
        }

        public void Update(Message message)
        {
            _repo.Update(message);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Message Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Message> GetAll()
        {
            return _repo.GetAll();
        }

        public Dictionary<int, Message> GetByParticipants(string username1, string username2)
        {
            return _repo.GetAll().Values
                .Where(message => (message.SenderUsername == username1 || message.SenderUsername == username2) 
                && (message.RecipientUsername == username2 || message.RecipientUsername == username1))
                .ToDictionary(message => message.Id, message => message);
        }
    }
}
