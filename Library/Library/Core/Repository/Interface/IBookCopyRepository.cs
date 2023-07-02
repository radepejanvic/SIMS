﻿using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Repository.Interface
{
    public interface IBookCopyRepository
    {
        void Add(BookCopy bookCopy);
        BookCopy Get(int id);
        Dictionary<int, BookCopy> GetAll();
        Dictionary<int, BookCopy> GetAllAvaliableBooks(List<string> loanedBooks);
        void Remove(int id);
        void Update(BookCopy bookCopy);
    }
}