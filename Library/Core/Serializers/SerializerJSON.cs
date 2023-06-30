using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Serializers
{
    public class SerializerJSON<T> : ISerializer<T> where T : ISerializable, new()
    {

    }
}
