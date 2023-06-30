using System.Collections.Generic;
using Library.Model;

namespace Library.Repository.Interface
{
    public interface IMessageRepository
    {
        void Add(Message message);
        Message Get(int id);
        Dictionary<int, Message> GetAll();
        Dictionary<int, Message> GetByParticipants(string username1, string username2);
        void Remove(int id);
        void Update(Message message);
    }
}