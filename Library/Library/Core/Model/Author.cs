using Library.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class Author : ISerializable
    {
        public int Id { get; set; }
        public string Name;
        public string Surname;

        public Author()
        {
            
        }

        public Author(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
