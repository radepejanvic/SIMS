using System.Collections.Generic;
using Library.Serializer;

namespace Library.Repository.Interface
{
    public interface ICRUDRepository<T> where T : ISerializable, new()
    {
        void Add(T obj);
        Dictionary<int, T> GetAll();
        T Get(int id);
        void Remove(int id);
        void Update(T obj);
        void Save(Dictionary<int, T> objects);
    }
}