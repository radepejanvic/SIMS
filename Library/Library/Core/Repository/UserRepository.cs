using Library.Core.Model;
using Library.Core.Repository.Interface;
using Library.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ICRUDRepository<User> _repo;

        public UserRepository(ICRUDRepository<User> repo)
        {
            _repo = repo;
        }

        public void Add(User user)
        {
            _repo.Add(user);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public User Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, User> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
