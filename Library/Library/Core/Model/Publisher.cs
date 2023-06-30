using Library.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class Publisher : ISerializable
    {
        public int Id { get; set; }
        public string Name;
        public Address Address;

        public Publisher()
        {
            
        }

        public Publisher(string name, Address address)
        {
            Name = name;
            Address = address;
        }
    }
}
