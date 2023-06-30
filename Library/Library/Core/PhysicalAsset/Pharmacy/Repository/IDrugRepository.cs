using System.Collections.Generic;
using Library.Model;

namespace Library.Repository.Interface
{
    public interface IDrugRepository
    {
        void Add(Drug drug);
        Drug Get(int id);
        Dictionary<int, Drug> GetAll();
        Dictionary<int, Drug> GetAllUnder(int quantity);
        bool IsAvaliable(int id);
        void Remove(int id);
        void Update(Drug drug);
    }
}