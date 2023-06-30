using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private ICRUDRepository<Appointment> _repo;

        public AppointmentRepository(ICRUDRepository<Appointment> repo)
        {
            _repo = repo;
        }

        public void Add(Appointment appointment)
        {
            _repo.Add(appointment);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public void Update(Appointment appointment)
        {
            _repo.Update(appointment);
        }

        public Appointment Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Appointment> GetAll()
        {
            return _repo.GetAll();
        }

        public Dictionary<int, Appointment> GetAll(int doctorId, int patientId)
        {
            return _repo.GetAll().Values
                .Where(appointment => appointment.DoctorId == doctorId && appointment.PatientId == patientId)
                .ToDictionary(appointment => appointment.Id, appointment => appointment);
        }

        public Dictionary<int, Appointment> GetAllByPatient(int patientId)
        {
            return _repo.GetAll().Values
                .Where(appointment => appointment.PatientId == patientId)
                .ToDictionary(appointment => appointment.Id, appointment => appointment);
        }

        public Dictionary<int, Appointment> GetAllByDoctor(int doctorId)
        {
            return _repo.GetAll().Values
                .Where(appointment => appointment.DoctorId == doctorId)
                .ToDictionary(appointment => appointment.Id, appointment => appointment);
        }

        public Dictionary<int, Appointment> GetAllByRoom(int roomId)
        {
            return _repo.GetAll().Values
                .Where(appointment => appointment.RoomId == roomId)
                .ToDictionary(appointment => appointment.Id, appointment => appointment);
        }

        public Dictionary<int, Appointment> GetAllByDoctor(int doctorId, DateOnly date)
        {
            return _repo.GetAll().Values
                .Where(appointment => appointment.DoctorId == doctorId && appointment.TimeSlot.GetDate() == date)
                .ToDictionary(appointment => appointment.Id, appointment => appointment);
        }

        public Dictionary<int, Appointment> GetAllByRoom(int roomId, DateOnly date)
        {
            return _repo.GetAll().Values
                .Where(appointment => appointment.RoomId == roomId && appointment.TimeSlot.GetDate() == date)
                .ToDictionary(appointment => appointment.Id, appointment => appointment);
        }

        public List<int> GetAllPatientIds(int doctorId)
        {
            return _repo.GetAll().Values
                .Where(appointment => appointment.DoctorId == doctorId)
                .Select(appointment => appointment.PatientId)
                .ToList();
        }

        public Dictionary<int, Appointment> GetAllFinished(int patientId)
        {
            return _repo.GetAll().Values
                .Where(appointment => appointment.PatientId == patientId && appointment.IsCanceled == false && appointment.TimeSlot.IsBefore(DateTime.Now))
                .ToDictionary(appointment => appointment.Id, appointment => appointment);
        }
    }
}
