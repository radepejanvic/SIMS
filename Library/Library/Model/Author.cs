using Library.Core.Helpers.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Author : ISerializable
    {
        public int Id { get; set; }
        public string Name;
        public string Surname;
        public List<int> Titles;

        public Author()
        {
            
        }

        public Author(string name, string surname, List<int> titles)
        {
            Name = name;
            Surname = surname;
            Titles = titles;
        }
    }
}
