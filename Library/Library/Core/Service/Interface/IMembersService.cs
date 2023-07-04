using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Service.Interface
{
    public interface IMembersService
    {
        Dictionary<int, PersonMembershipCardDTO> GetAllPersonMembershipCardDTOs();

        List<Membership> GetAllMemberships();
        void AddUser(string name, string surname, string email, string phone, string jmbg, Membership selectedMembershipMembership);
    }
}