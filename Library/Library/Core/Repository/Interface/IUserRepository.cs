using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Repository.Interface
{
    public interface IUserRepository
    {
        void Add(User user);
        User Get(int id);
        Dictionary<int, User> GetAll();
        void Remove(int id);
    }
}