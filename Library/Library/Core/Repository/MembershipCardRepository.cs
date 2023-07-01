using Library.Core.Model;
using Library.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repository
{
    public class MembershipCardRepository : IMembershipCardRepository
    {
        private readonly ICRUDRepository<MembershipCard> _repo;

        public MembershipCardRepository(ICRUDRepository<MembershipCard> repo)
        {
            _repo = repo;
        }

        public void Add(MembershipCard membershipCard)
        {
            _repo.Add(membershipCard);
        }

        public void Update(MembershipCard membershipCard)
        {
            _repo.Update(membershipCard);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public MembershipCard Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, MembershipCard> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
