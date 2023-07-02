using Library.Core.Model;
using Library.Core.Repository.Interface;
using Library.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Service
{
    public class MembersService : IMembersService
    {
        public readonly IMembershipCardRepository _membershipCardRepo;
        public readonly IMembershipCardRepository _membershipRepo;
        public readonly IPersonRepository _personRepo;

        public MembersService(IMembershipCardRepository membershipCardRepo, IMembershipCardRepository membershipRepo, IPersonRepository personRepo)
        {
            _membershipCardRepo = membershipCardRepo;
            _membershipRepo = membershipRepo;
            _personRepo = personRepo;
        }

        public Dictionary<int, PersonMembershipCardDTO> GetAllPersonMembershipCardDTOs()
        {
            return _membershipCardRepo.GetAll().Values
                .ToDictionary(member => member.Id, member => new PersonMembershipCardDTO(member, _personRepo.Get(member.PersonId)));
        }
    }
}
