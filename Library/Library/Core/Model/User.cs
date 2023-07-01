using Library.Core.Enum;
using Library.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class User : ISerializable
    {
        public int Id { get; set; }
        public int? PersonId;
        public string Username;
        public string Password;
        public UserType UserType;

        public User()
        {
            
        }

        public User(int? personId, string username, string password, UserType userType)
        {
            PersonId = personId;
            Username = username;
            Password = password;
            UserType = userType;
        }

        public bool CheckPassword(string password)
        {
            return Password == password;
        } 
    }
}
