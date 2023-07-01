using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Repository.Interface
{
    public interface IMembershipRepository
    {
        void Add(Membership membership);
        Membership Get(int id);
        Dictionary<int, Membership> GetAll();
        void Remove(int id);
        void Update(Membership membership);
    }
}