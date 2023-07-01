using Library.Core.Enum;
using Library.Core.Model;
using Library.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace Library.GUI.Helpers.Generator
{
    public class UserGenerator : DataGenerator, IUserGenerator
    {
        private readonly List<string> _names = new() { "Ana", "Jovan", "Marko", "Mihajlo", "Milica", "Nikola", "Petar", "Sofija", "Stefan", "Tamara" };
        private readonly List<string> _surnames = new() { "Arsić", "Đorđević", "Ilić", "Janković", "Jovanović", "Kovačević", "Marković", "Petrović", "Stojanović", "Vuković" };
        private readonly List<string> _domains = new() { "gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "example.com" };
        private readonly List<string> _signs = new() { ".", "_", "0", "-" };
        private readonly List<string> _phones = new() { "060", "061", "062", "063", "064", "065", "066", "067", "068", "069" };

        private readonly IUserRepository _userRepo;
        private readonly IPersonRepository _personRepo;
        private readonly IMembershipRepository _membershipRepo;
        private readonly IMembershipCardRepository _membershipCardRepo;

        public UserGenerator(IUserRepository userRepo, IPersonRepository personRepo, IMembershipRepository membershipRepo, IMembershipCardRepository membershipCardRepo)
        {
            _userRepo = userRepo;
            _personRepo = personRepo;
            _membershipRepo = membershipRepo;
            _membershipCardRepo = membershipCardRepo;
        }

        public void GenerateUsers(int librarians, int members)
        {
            GenerateAdmin();
            Generate(GenerateLibrarian, librarians);
            Generate(GenerateMember, members);
        }

        private void GenerateAdmin()
        {
            _userRepo.Add(new User(null, GenerateRandomString(8), GenerateRandomString(8), UserType.ADMIN));
        }

        private void GenerateLibrarian()
        {
            var librarianType = Random.Next(2) == 0 ? UserType.LIBRARIAN_MEMBERSHIPS : UserType.LIBRARIAN_COLLECTION;
            _userRepo.Add(new User(null, GenerateRandomString(8), GenerateRandomString(8), librarianType));
        }

        private void GenerateMember()
        {
            var username = GenerateRandomString(8);
            _userRepo.Add(new User(null, username, GenerateRandomString(8), UserType.MEMBER));
            GeneratePerson(_userRepo.Get(username).Id);
        }

        private void GeneratePerson(int userId)
        {
            var user = _userRepo.Get(userId);
            var name = _names[Random.Next(_names.Count)];
            var surname = _surnames[Random.Next(_surnames.Count)];
            var JMBG = GenerateRandomStringOfNumbers(13);
            var person = new Person(userId, JMBG, name, surname, GenerateRandomPhone(), GenerateRandomEmail(name, surname), null);
            _personRepo.Add(person);
            user.PersonId = _personRepo.Get(JMBG).Id;
            _userRepo.Update(user);
        }

        private string GenerateRandomEmail(string name, string surname)
        {
            var sign = _signs[Random.Next(_signs.Count)];
            var domain = _domains[Random.Next(_domains.Count)];
            return $"{name}{sign}{surname}@{domain}";
        }

        private string GenerateRandomPhone()
        {
            var phone = _phones[Random.Next(_phones.Count)];
            return phone += GenerateRandomStringOfNumbers(7);
        }

        public void GenerateMemberships()
        {
            _membershipRepo.Add(new Membership(MembershipType.CHILD, 300, 2, 30, 2));
            _membershipRepo.Add(new Membership(MembershipType.STUDENT, 500, 4, 60, 4));
            _membershipRepo.Add(new Membership(MembershipType.ADULT, 700, 3, 30, 6));
            _membershipRepo.Add(new Membership(MembershipType.CHILD, 500, 3, 30, 5));
        }

        public void GenerateMembershipCards(int start, int length)
        {
            for (int i = start; i < start + length; i++)
            {
                var membership = Random.Next(1, 5);
                _membershipCardRepo.Add(new MembershipCard(i, membership, DateTime.Today, DateTime.Today.AddYears(1)));
            }
        }
    }
}
