using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Service.Interface
{
    public interface IBookCollectionService
    {
        void RegisterBookCopy(BookCopy bookCopy);
        void RegisterBookTitle(List<int> authors, BookTitle bookTitle);
    }
}