using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Service
{
    public interface IMembersService
    {
        Dictionary<int, PersonMembershipCardDTO> GetAllPersonMembershipCardDTOs();
    }
}