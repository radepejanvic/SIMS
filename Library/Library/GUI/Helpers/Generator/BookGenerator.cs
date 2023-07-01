using Library.Core.Enum;
using Library.Core.Model;
using Library.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.Helpers.Generator
{
    public class BookGenerator : DataGenerator, IBookGenerator
    {
        private readonly List<string> _titles = new()
        {
            "1984",
            "Gospodar prstenova",
            "Ubiti pticu rugalicu",
            "Građanin Kejn",
            "Harry Potter i Kamen mudraca",
            "Ponos i predrasude",
            "Vojna akademija",
            "Catcher in the Rye",
            "Alhemičar"
        };

        private readonly List<string> _descriptions = new()
        {
            "Distopijski roman koji prikazuje totalitarno društvo.", // 1984
            "Epohalna fantastična trilogija o potrazi za uništenjem moćnog prstena.", // Gospodar prstenova
            "Priča o odrastanju koja se bavi temama predrasuda i nepravde.", // Ubiti pticu rugalicu
            "Složena pripovest koja istražuje život bogatog novinskog izdavača.", // Građanin Kejn
            "Prva knjiga popularne fantastične serije o avanturama mladog čarobnjaka.", // Harry Potter i Kamen mudraca
            "Klasični ljubavni roman koji istražuje društvene norme i složenosti ljubavi.", // Ponos i predrasude
            "Roman smešten u vojnu akademiju, fokusiran na iskustva kadeta.", // Vojna akademija
            "Kontroverzni roman ispričan iz perspektive razočaranog tinejdžera.", // Catcher in the Rye
            "Filozofska priča o putovanju mladog pastira u potrazi za smislom života." // Alhemičar
        };


        private readonly List<string> _authors = new()
        {
            "George Orwell",
            "J.R.R. Tolkien",
            "Harper Lee",
            "Orson Welles",
            "J.K. Rowling",
            "Jane Austen",
            "Danilo Kiš",
            "J.D. Salinger",
            "Paulo Coelho"
        };

        private readonly IPublisherRepository _publisherRepo;
        private readonly IAuthorRepository _authorRepo;
        private readonly IBookAndAuthorRepository _bookAndAuthorRepo;
        private readonly IBookTitleRepository _bookTitleRepo;
        private readonly IBookCopyRepository _bookCopyRepo;

        public BookGenerator(IPublisherRepository publisherRepo, IAuthorRepository authorRepo, IBookAndAuthorRepository bookAndAuthorRepo, IBookTitleRepository bookTitleRepo, IBookCopyRepository bookCopyRepo)
        {
            _publisherRepo = publisherRepo;
            _authorRepo = authorRepo;
            _bookAndAuthorRepo = bookAndAuthorRepo;
            _bookTitleRepo = bookTitleRepo;
            _bookCopyRepo = bookCopyRepo;
        }

        public void GenerateLibraryCollection()
        {
            GeneratePublishers();
            GenerateAuthors();
            GenerateBookAndAuthor();
            GenerateBookTitles();
            GenerateBookCopies();
        }

        private void GeneratePublishers()
        {
            var lagunaAddress = new Address("Bulevar despota Stefana", 107, "Beograd", "11000", "Srbija");
            var deretaAddress = new Address("Gospodar Jevremova", 21, "Beograd", "11000", "Srbija");
            _publisherRepo.Add(new Publisher("Laguna", lagunaAddress));
            _publisherRepo.Add(new Publisher("Dereta", deretaAddress));
        }

        private void GenerateAuthors()
        {
            foreach (string author in _authors)
            {
                string[] nameSurname = author.Split(' ');
                _authorRepo.Add(new Author(nameSurname[0], nameSurname[1]));
            }
        }

        private void GenerateBookAndAuthor()
        {
            for (int i = 1; i < _titles.Count + 1; i++)
            {
                _bookAndAuthorRepo.Add(new BookAndAuthor(i, i));
            }
        }

        private void GenerateBookTitles()
        {
            for (int i = 0; i < _titles.Count; i++)
            {
                var publisher = Random.Next(1, 3);
                _bookTitleRepo.Add(new BookTitle(publisher, _titles[i], DateTime.Today, _descriptions[i], GenerateRandomEnum<Language>(), GenerateRandomEnum<CoverType>(), GenerateRandomString(13), GenerateRandomString(8)));
            }
        }

        private void GenerateBookCopies()
        {
            for (int i = 1; i < _titles.Count + 1; i++)
            {
                var price = Random.Next(400, 2001);
                var ISBN = _bookTitleRepo.Get(i).ISBN;
                _bookCopyRepo.Add(new BookCopy(i, 1, ISBN, GenerateRandomString(6), price, DateTime.Today));
            }
        }
    }
}
