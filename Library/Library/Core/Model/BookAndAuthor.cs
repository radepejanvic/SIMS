using Library.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class BookAndAuthor : ISerializable
    {
        public int Id { get; set; }
        public int BookId;
        public int AuthorId;

        public BookAndAuthor()
        {
            
        }

        public BookAndAuthor(int bookId, int authorId)
        {
            BookId = bookId;
            AuthorId = authorId;
        }
    }
}
