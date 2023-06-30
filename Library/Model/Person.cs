using Library.Core.Helpers.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Person : ISerializable
    {
        public int Id { get; set; }
        public int UserId;
        public string Name;
        public string Surname;
        public string JMBG;
        public string PhoneNumber;
        public string Email;
        public Address Address;

        public Person()
        {
            
        }

        public Person(int userId, string name, string surname, string jMBG, string phoneNumber, string email, Adress adress)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            JMBG = jMBG;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = adress;
        }
    }
}
