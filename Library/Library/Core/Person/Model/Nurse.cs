using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Serializer;

namespace Library.Model
{
    public class Nurse : Person, ISerializable
    {
        public Nurse()
        {

        }

        public Nurse(int id, string username, string firstName, string lastName, string password) : base(id, username, firstName, lastName, password)
        {
        }
    }
}
