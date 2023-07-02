using Library.Core.Model;
using Library.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Service
{
    public class MembersService
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

        //public Dictionary<int, PersonMembershipCardDTO> GetAllPersonMembershipCardDTOs()
        //{
            
        //}
    }
}
