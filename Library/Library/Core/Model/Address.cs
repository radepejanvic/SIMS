using Library.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class Address
    {
        public string Street;
        public int Number;
        public string City;
        public string PostalCode;
        public string Country;

        public Address()
        {
            
        }

        public Address(string street, int number, string city, string postalCode, string country)
        {
            Street = street;
            Number = number;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
    }
}
