using Library.Core.Enum;
using Library.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class BookTitle : ISerializable
    {
        public int Id { get; set; }
        public int PublisherId;
        public string Title;
        public DateTime PublicationYear;
        public string Description;
        public Language Language;
        public CoverType Cover;
        public string ISBN;
        public string UDK;

        public BookTitle()
        {
            
        }

        public BookTitle(int publisherId, string title, DateTime publicationYear, string description, Language language, CoverType cover, string iSBN, string uDK)
        {
            PublisherId = publisherId;
            Title = title;
            PublicationYear = publicationYear;
            Description = description;
            Language = language;
            Cover = cover;
            ISBN = iSBN;
            UDK = uDK;
        }
    }
}
