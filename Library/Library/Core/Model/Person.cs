using Library.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class Person : ISerializable
    {
        public int Id { get; set; }
        public int UserId;
        public string Name;
        public string Surname;
        public string Phone;
        public string Email;
        public Address Address;

        public Person()
        {
            
        }

        public Person(int userId, string name, string surname, string phone, string email, Address address)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Phone = phone;
            Email = email;
            Address = address;
        }
    }
}
