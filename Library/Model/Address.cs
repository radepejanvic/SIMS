using Library.Core.Helpers.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Address : ISerializable
    {
        public int Id { get; set; }
        public string Street;
        public int StreetNumber;
        public string City;
        public string PostalCode;

        public Address()
        {
            
        }

        public Address(int id, string street, int streetNumber, string city, string postalCode)
        {
            Id = id;
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            PostalCode = postalCode;
        }
    }
}
