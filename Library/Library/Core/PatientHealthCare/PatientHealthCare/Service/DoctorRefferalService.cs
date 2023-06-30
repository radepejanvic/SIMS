using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Refferal;
using Library.Repository.Interface;
using Library.Service.RefferalService.Interface;

namespace Library.Service.RefferalService
{
    public class DoctorRefferalService : IDoctorRefferalService
    {
        private IDoctorRefferalRepository _crud;

        public DoctorRefferalService(IDoctorRefferalRepository crud)
        {
            _crud = crud;
        }

        public void Add(DoctorRefferal doctorRefferal)
        {
            _crud.Add(doctorRefferal);
        }

        public void Update(DoctorRefferal doctorRefferal)
        {
            _crud.Update(doctorRefferal);
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public DoctorRefferal Get(int id)
        {
            return _crud.Get(id);
        }

        public Dictionary<int, DoctorRefferal> GetAll()
        {
            return _crud.GetAll();
        }

        public Dictionary<int, DoctorRefferal> GetAll(int patientId)
        {
            return _crud.GetAll(patientId);
        }
    }
}
