using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Enum;
using Library.Repository;
using Library.Repository.Interface;
using Library.Service.AppointmentService.Interface;

namespace Library.Service.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepository _crud;

        public AppointmentService(IAppointmentRepository crud)
        {
            _crud = crud;
        }

        public void Add(Appointment appointment)
        {
            _crud.Add(appointment);
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public void Update(Appointment appointment)
        {
            _crud.Update(appointment);
        }

        public Appointment Get(int id)
        {
            return _crud.Get(id);
        }

        public Dictionary<int, Appointment> GetAll()
        {
            return _crud.GetAll();
        }

        public Dictionary<int, Appointment> GetAll(int doctorId, int patientId)
        {
            return _crud.GetAll(doctorId, patientId);
        }

        public Dictionary<int, Appointment> GetAllByPatient(int patientId)
        {
            return _crud.GetAllByPatient(patientId);
        }

        public Dictionary<int, Appointment> GetAllByDoctor(int doctorId)
        {
            return _crud.GetAllByDoctor(doctorId);
        }

        public Dictionary<int, Appointment> GetAllByRoom(int roomId)
        {
            return _crud.GetAllByRoom(roomId);
        }

        public Dictionary<int, Appointment> GetAllByDoctor(int doctorId, DateOnly date)
        {
            return _crud.GetAllByDoctor(doctorId, date);
        }

        public Dictionary<int, Appointment> GetAllByRoom(int roomId, DateOnly date)
        {
            return _crud.GetAllByRoom(roomId, date);
        }

        public List<int> GetAllPatientIds(int doctorId)
        {
            return _crud.GetAllPatientIds(doctorId);
        }

        public List<Appointment> GetAllFinished(int patientId)
        {
            var appointments = _crud.GetAllFinished(patientId);
            return appointments.Any() ? appointments.Values.ToList() : new List<Appointment>();
        }

    }
}
