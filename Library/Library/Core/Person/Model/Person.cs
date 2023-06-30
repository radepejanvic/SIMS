using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Serializer;

namespace Library.Model
{
    public abstract class Person : ISerializable
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public Person()
        {

        }
        public Person(int id, string username, string firstName, string lastName, string password)
        {
            Id = id;
            Username = username;
            LastName = lastName;
            FirstName = firstName;
            Password = password;
        }
    }
}
