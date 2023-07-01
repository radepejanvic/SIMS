using Library.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.Helpers.Generator
{
    public class BookGenerator
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

        private readonly List<string> _publishers= new() { "Laguna", "Dereta" };


        public BookGenerator(IPublisherRepository publisherRepo, IAuthorRepository authorRepo, IBookAndAuthorRepository bookAndAuthorRepo, IBookTitleRepository bookTitleRepo, IBookCopyRepository bookCopyRepo)

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
            for (int i = 0; i < _titles.Count; i++)
            {
                _bookAndAuthor.Add(new BookAndAuthor(i, i));
            }
        }
    }
}
