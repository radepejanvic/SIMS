using Library.Core.Helpers.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class InventoryBook : ISerializable
    {
        public int Id { get; set; }
        public string Label;
        public string Description;
        public List<int> BookCopies;

        public InventoryBook()
        {
            
        }

        public InventoryBook(string label, string description, List<int> bookCopies)
        {
            Label = label;
            Description = description;
            BookCopies = bookCopies;
        }
    }
}
