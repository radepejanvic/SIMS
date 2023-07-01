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
    public class MembershipRepository : IMembershipRepository
    {
        private readonly ICRUDRepository<Membership> _repo;

        public MembershipRepository(ICRUDRepository<Membership> repo)
        {
            _repo = repo;
        }

        public void Add(Membership membership)
        {
            _repo.Add(membership);
        }

        public void Update(Membership membership)
        {
            _repo.Update(membership);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Membership Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Membership> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
