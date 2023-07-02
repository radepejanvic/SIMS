using Library.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.TitleRegistration.ViewModel
{
    public class PublisherViewModel
    {
        private readonly Publisher _publisher;
        public int Id => _publisher.Id;
        public string Name => _publisher.Name;
        public Address Address => _publisher.Address;

        public PublisherViewModel(Publisher publisher)
        {
            _publisher = publisher;
        }

        public bool Contains(string keyword)
        {
            return $"{Id}--{Name}--{Address}".ToLower().Contains(keyword.ToLower());
        }
    }
}
