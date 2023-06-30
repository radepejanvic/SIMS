using Library.Core.Helpers.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Library.Model
{
    public class LibraryBranch : ISerializable
    {
        public int Id { get; set; }
        public string Name;

        public LibraryBranch()
        {
            
        }

        public LibraryBranch(string name)
        {
            Name = name;
        }
    }
}
