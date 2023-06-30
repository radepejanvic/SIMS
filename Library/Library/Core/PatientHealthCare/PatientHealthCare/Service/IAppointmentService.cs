using System;
using System.Collections.Generic;
using Library.Model;

namespace Library.Service.AppointmentService.Interface
{
    public interface IAppointmentService
    {
        void Add(Appointment appointment);
        Appointment Get(int id);
        Dictionary<int, Appointment> GetAll();
        void Remove(int id);
        public Dictionary<int, Appointment> GetAll(int doctorId, int patientId);
        public Dictionary<int, Appointment> GetAllByPatient(int patientId);
        public Dictionary<int, Appointment> GetAllByDoctor(int doctorId);
        public List<int> GetAllPatientIds(int doctorId);
        void Update(Appointment appointment);
        Dictionary<int, Appointment> GetAllByDoctor(int doctorId, DateOnly date);
        List<Appointment> GetAllFinished(int patientId);
    }
}