using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Service.Interface
{
    public interface IBookCollectionService
    {
        Dictionary<int, Author> GetAllAuthors();
        Dictionary<int, Publisher> GetAllPublishers();
        void RegisterBookCopy(BookCopy bookCopy);
        void RegisterBookTitle(List<int> authors, BookTitle bookTitle);
    }
}