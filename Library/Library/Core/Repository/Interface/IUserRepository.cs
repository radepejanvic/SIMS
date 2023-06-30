using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Repository.Interface
{
    public interface IUserRepository
    {
        void Add(User user);
        User Get(int id);
        User? Get(string username);
        Dictionary<int, User> GetAll();
        void Remove(int id);
    }
}