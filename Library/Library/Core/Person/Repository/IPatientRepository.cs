using System.Collections.Generic;
using Library.Model;

namespace Library.Repository.Interface
{
    public interface IPatientRepository
    {
        void Add(Patient patient);
        Patient Get(int id);
        Dictionary<int, Patient> GetAll();
        Dictionary<int, Patient> GetAll(List<int> ids);
        void Remove(int id);
        void Update(Patient patient);
    }
}