using Library.Core.Helpers.Serializer;
using Library.Enum;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class BookTitle : ISerializable
    {
        public int Id { get; set; }
        public string Title;
        public DateTime PublicationYear;
        public string Description;
        public BookBinding Binding;
        public Language Language;
        public string ISBN;
        public string UDK;
        public int PublisherId;
        public List<int> Authors;

        public BookTitle()
        {
            
        }

        public BookTitle(string title, DateTime publicationYear, string description, BookBinding binding, Language language, string iSBN, string uDK, int publisherId, List<int> authors)
        {
            Title = title;
            PublicationYear = publicationYear;
            Description = description;
            Binding = binding;
            Language = language;
            ISBN = iSBN;
            UDK = uDK;
            PublisherId = publisherId;
            Authors = authors;
        }
    }
}
