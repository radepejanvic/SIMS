using Library.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class InventoryBook : ISerializable
    {
        public int Id { get; set; }
        public string Name;
        public string Description;
        public List<int> BookCopies;

        public InventoryBook()
        {
            
        }

        public InventoryBook(string name, string description, List<int> bookCopies)
        {
            Name = name;
            Description = description;
            BookCopies = bookCopies;
        }
    }
}
