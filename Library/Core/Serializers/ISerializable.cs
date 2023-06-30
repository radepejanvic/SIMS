using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Serializers
{
    public interface ISerializable
    {
        int Id { get; set; }
    }
}
