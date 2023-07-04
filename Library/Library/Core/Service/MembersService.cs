using Library.Core.Model;
using Library.Core.Repository.Interface;
using Library.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Enum;

namespace Library.Core.Service
{
    public class MembersService : IMembersService
    {
        public readonly IMembershipCardRepository _membershipCardRepo;
        public readonly IMembershipRepository _membershipRepo;
        public readonly IPersonRepository _personRepo;
        public readonly IUserRepository _userRepo;
        public readonly IMembershipCardRepository _cardRepo;

        public MembersService(IMembershipCardRepository membershipCardRepo, IMembershipRepository membershipRepo,
            IPersonRepository personRepo, IUserRepository userRepo, IMembershipCardRepository cardRepo)
        {
            _membershipCardRepo = membershipCardRepo;
            _membershipRepo = membershipRepo;
            _personRepo = personRepo;
            _userRepo = userRepo;
            _cardRepo = cardRepo;
        }

        public Dictionary<int, PersonMembershipCardDTO> GetAllPersonMembershipCardDTOs()
        {
            return _membershipCardRepo.GetAll().Values
                .ToDictionary(member => member.Id, member => new PersonMembershipCardDTO(member, _personRepo.Get(member.PersonId)));
        }

        public List<Membership> GetAllMemberships()
        {
            return _membershipRepo.GetAll().Values.ToList();
        }
        
        private static Random _random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890123456789_______-------";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public void AddUser(string name, string surname, string email, string phone, string jmbg,
            Membership selectedMembership)
        {
            // So the process is to Add User -> Get User by Username -> Set Persons UserId -> Add Person -> GetPerson by JMBG -> Set MembershipCards PersonId -> Add MembershipCard
            
            _userRepo.Add(new User(int.Parse(jmbg), email, RandomString(8), UserType.MEMBER));
            int userId = _userRepo.Get(email).Id;
            
            _personRepo.Add(new Person(userId, jmbg, name, surname, phone, email, null));
            int personId = _personRepo.Get(jmbg).Id;

            DateTime dt = DateTime.Now.Add(TimeSpan.FromDays(selectedMembership.LoanDuration));
            _cardRepo.Add(new MembershipCard(personId, selectedMembership.Id, dt, dt));
        }
    }
}
