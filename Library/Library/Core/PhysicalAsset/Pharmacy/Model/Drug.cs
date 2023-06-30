using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;
using Library.Serializer;

namespace Library.Model
{
    public class Drug : ISerializable
    {
        public int Id { get; set; }
        public string Name;
        public List<Alergy> Alergens;
        public int NumberOfTablets;
        public int Quantity;

        public Drug()
        {
            
        }

        public Drug(string name, List<Alergy> alergens, int numberOfTablets, int quantity)
        {
            Name = name;
            Alergens = alergens;
            NumberOfTablets = numberOfTablets;
            Quantity = quantity;
        }

        public void Perscribe()
        {
            Quantity--;
        }

        public void Restock(int quantity)
        {
            Quantity += quantity;
        }
    }
}
