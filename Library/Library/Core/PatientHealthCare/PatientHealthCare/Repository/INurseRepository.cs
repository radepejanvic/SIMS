using System.Collections.Generic;
using Library.Model;

namespace Library.Repository.Interface
{
    public interface INurseRepository
    {
        void Add(Nurse nurse);
        Nurse Get(int id);
        Dictionary<int, Nurse> GetAll();
        Dictionary<int, Nurse> GetAll(List<int> ids);
        void Remove(int id);
        void Update(Nurse nurse);
    }
}