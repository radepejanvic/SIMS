using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Serializer;

namespace Library.Model
{
    public abstract class Survey : ISerializable
    {
        public int Id { get; set; }
        public string Comment;
        public Survey(){}

        public Survey(string comment)
        {
            Comment = comment;
        }
       
    }
}
