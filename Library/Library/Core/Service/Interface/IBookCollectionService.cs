using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Service.Interface
{
    public interface IBookCollectionService
    {
        Dictionary<int, Author> GetAllAuthors();
        Dictionary<int, LibraryBranch> GetAllBranches();
        Dictionary<int, Publisher> GetAllPublishers();
        Dictionary<int, BookTitle> GetAllTitles();
        bool IsUniqueInventoryNumber(string inventoryNumber);
        bool IsUniqueISBN(string ISBN);
        bool IsUniqueUDK(string UDK);
        void RegisterBookCopy(BookCopy bookCopy);
        void RegisterBookTitle(List<int> authors, BookTitle bookTitle);
    }
}