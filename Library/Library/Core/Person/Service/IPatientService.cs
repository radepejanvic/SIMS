using System.Collections.Generic;
using Library.Model;

namespace Library.Service.PersonService.Interface
{
    public interface IPatientService
    {
        void Add(Patient patient);
        Patient Get(int id);
        Dictionary<int, Patient> GetAll();
        void Update(Patient patient);
        void Remove(int id);
        bool IsUnique(string username);
        bool IsMatch(string name);
        bool IsUnique(int id, string username);
    }
}