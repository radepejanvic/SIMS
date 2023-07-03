using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Service.Interface
{
    public interface IMembersService
    {
        Dictionary<int, PersonMembershipCardDTO> GetAllPersonMembershipCardDTOs();
    }
}