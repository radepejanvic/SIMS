using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Enum;
using Library.Core.Model;
using Library.Core.Repository.Interface;
using Library.Model;

using Library.Model.Enum;
using Library.Serializer;
using Library.Service;
using Library.Repository.Interface;
using System.Diagnostics;
using Library.Core.Repository;

namespace Library
{
    public class DataGenerator : IDataGenerator
    {
        private static List<string> _names = new List<string> { "Ana", "Jovan", "Marko", "Mihajlo", "Milica", "Nikola", "Petar", "Sofija", "Stefan", "Tamara" };
        private static List<string> _surnames = new List<string> { "Arsić", "Đorđević", "Ilić", "Janković", "Jovanović", "Kovačević", "Marković", "Petrović", "Stojanović", "Vuković" };
        private static List<string> _domains = new List<string> { "gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "example.com" };
        private static List<string> _signs = new List<string> { ".", "_", "0", "-" };
        private static List<string> _phones = new List<string> { "060", "061", "062", "063", "064", "065", "066", "067", "068", "069" };

        private static Random Random = new Random();

        //private readonly ICRUDRepository<User> _userRepo;
        private readonly IUserRepository _userRepo;
        private readonly IPersonRepository _personRepo;

        public DataGenerator(IUserRepository userRepo, IPersonRepository personRepo)
        {
            _userRepo = userRepo;
            _personRepo = personRepo;
        }

        public void GenerateAll(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                //GenerateRandomUser();
            }
        }

        private Dictionary<int, T> Generate<T>(Func<int, T> generator, int length) where T : ISerializable
        {
            var data = new Dictionary<int, T>();
            int id = 1;
            while (data.Values.Count < length)
            {
                var obj = generator(id);
                data.Add(id, obj);
                id++;
            }
            return data;
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

        private string GenerateRandomStringOfNumbers(int length)
        {
            var output = "";
            for (int i = 0; i < length; i++)
            {
                output += Random.Next(10);
            }
            return output;
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }

        private List<T> GenerateRandomEnumsList<T>() where T : Enum
        {
            var enums = new List<T>();
            var length = Random.Next(1, 11);

            while (enums.Count < length)
            {
                var value = (T)Enum.ToObject(typeof(T), Random.Next(Enum.GetValues(typeof(T)).Length));
                if (!enums.Contains(value))
                {
                    enums.Add(value);
                }
            }
            return enums;
        }

        private T GenerateRandomEnum<T>() where T : Enum
        {
            return (T)Enum.ToObject(typeof(T), Random.Next(Enum.GetValues(typeof(T)).Length));
        }
        public static List<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

    }
}
