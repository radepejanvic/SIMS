using Library.Core.Model;
using Library.Core.Repository.Interface;
using Library.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Service
{
    public class BookCollectionService : IBookCollectionService
    {
        private readonly IBookTitleRepository _booktitleRepo;
        private readonly IBookCopyRepository _bookCopyRepo;
        private readonly IAuthorRepository _authorRepo;
        private readonly IPublisherRepository _publisherRepo;
        private readonly IBookAndAuthorRepository _bookAndAuthorRepo;
        private readonly ILibraryBranchRepository _libraryBranchRepo;

        public BookCollectionService(IBookTitleRepository booktitleRepo, IBookCopyRepository bookCopyRepo,
            IAuthorRepository authorRepo, IPublisherRepository publisherRepo, IBookAndAuthorRepository bookAndAuthorRepo,
            ILibraryBranchRepository libraryBranchRepo)
        {
            _booktitleRepo = booktitleRepo;
            _bookCopyRepo = bookCopyRepo;
            _authorRepo = authorRepo;
            _publisherRepo = publisherRepo;
            _bookAndAuthorRepo = bookAndAuthorRepo;
            _libraryBranchRepo = libraryBranchRepo;
        }

        public void RegisterBookTitle(List<int> authors, BookTitle bookTitle)
        {
            foreach (int author in authors)
            {
                _bookAndAuthorRepo.Add(new BookAndAuthor(bookTitle.Id, author));
            }

            _booktitleRepo.Add(bookTitle);
        }

        public void RegisterBookCopy(BookCopy bookCopy)
        {
            _bookCopyRepo.Add(bookCopy);
        }

        public Dictionary<int, Author> GetAllAuthors()
        {
            return _authorRepo.GetAll();
        }

        public Dictionary<int, Publisher> GetAllPublishers()
        {
            return _publisherRepo.GetAll();
        }

        public Dictionary<int, BookTitle> GetAllTitles()
        {
            return _booktitleRepo.GetAll();
        }

        public Dictionary<int, LibraryBranch> GetAllBranches()
        {
            return _libraryBranchRepo.GetAll();
        }

        public bool IsUniqueISBN(string ISBN)
        {
            return _booktitleRepo.GetByISBN(ISBN) is null;
        }

        public bool IsUniqueUDK(string UDK)
        {
            return _booktitleRepo.GetByUDK(UDK) is null;
        }

        public bool IsUniqueInventoryNumber(string inventoryNumber)
        {
            return _bookCopyRepo.Get(inventoryNumber) is null;
        }
    }
}
