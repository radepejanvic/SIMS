using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Serializers
{
    public interface ISerializer<T> where T : ISerializable, new()
    {
        Dictionary<int, T> Load();
        void Save(Dictionary<int, T> objects);
    }
}
