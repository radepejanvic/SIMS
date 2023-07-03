using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Repository.Interface
{
    public interface IBookTitleRepository
    {
        void Add(BookTitle bookTitle);
        BookTitle Get(int id);
        Dictionary<int, BookTitle> GetAll();
        BookTitle? GetByISBN(string ISBN);
        BookTitle? GetByUDK(string UDK);
        void Remove(int id);
        void Update(BookTitle bookTitle);
    }
}