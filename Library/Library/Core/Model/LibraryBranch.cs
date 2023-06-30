using Library.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class LibraryBranch : ISerializable
    {
        public int Id { get; set; }
        public string Name;
        public Address Address;
        public List<int> Librarians;

        public LibraryBranch()
        {
            
        }

        public LibraryBranch(string name, Address address, List<int> librarians)
        {
            Name = name;
            Address = address;
            Librarians = librarians;
        }
    }
}
