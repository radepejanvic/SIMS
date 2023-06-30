using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository;
using Library.Repository.Interface;
using Library.Service.PersonService.Interface;

namespace Library.Service.PersonService
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _crud;

        public PatientService(IPatientRepository crud)
        {
            _crud = crud;
        }

        public void Add(Patient patient)
        {
            _crud.Add(patient);
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public void Update(Patient patient)
        {
            _crud.Update(patient);
        }

        public Patient Get(int id)
        {
            return _crud.Get(id);
        }

        public Dictionary<int, Patient> GetAll()
        {
            return _crud.GetAll();
        }

        public bool IsUnique(string username)
        {
            foreach (Patient patient in GetAll().Values)
            {
                if (patient.Username == username)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsUnique(int id, string username)
        {
            foreach (Patient patient in GetAll().Values)
            {
                if (patient.Username != username && patient.Id != id) { return true; }
                if (patient.Username == username && patient.Id == id) { return true; }
            }
            return false;
        }

        public bool IsMatch(string name)
        {
            var pattern = @"^[A-ZČĆŠĐŽ][a-zčćšđž]+(\s[A-ZČĆŠĐŽ][a-zčćšđž]+)*$";
            return Regex.IsMatch(name, pattern);
        }

        public Dictionary<int, Patient> GetAll(List<int> ids)
        {
            return _crud.GetAll(ids);
        }
    }
}
