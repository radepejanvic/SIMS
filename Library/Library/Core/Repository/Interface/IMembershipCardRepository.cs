using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Repository.Interface
{
    public interface IMembershipCardRepository
    {
        void Add(MembershipCard membershipCard);
        MembershipCard Get(int id);
        Dictionary<int, MembershipCard> GetAll();
        void Remove(int id);
        void Update(MembershipCard membershipCard);
    }
}