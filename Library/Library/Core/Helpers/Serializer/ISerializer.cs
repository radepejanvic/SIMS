using System.Collections.Generic;

namespace Library.Serializer
{
    public interface ISerializer<T> where T : ISerializable, new()
    {
        Dictionary<int, T> Load();
        void Save(Dictionary<int, T> objects);
    }
}