using System;
using System.Collections.Generic;
using Library.Model;

namespace Library.Repository.Interface
{
    public interface IAppointmentRepository
    {
        void Add(Appointment appointment);
        Appointment Get(int id);
        Dictionary<int, Appointment> GetAll();
        Dictionary<int, Appointment> GetAll(int doctorId, int patientId);
        Dictionary<int, Appointment> GetAllByDoctor(int doctorId);
        Dictionary<int, Appointment> GetAllByDoctor(int doctorId, DateOnly date);
        Dictionary<int, Appointment> GetAllByPatient(int patientId);
        Dictionary<int, Appointment> GetAllByRoom(int roomId);
        Dictionary<int, Appointment> GetAllByRoom(int roomId, DateOnly date);
        List<int> GetAllPatientIds(int doctorId);
        Dictionary<int, Appointment> GetAllFinished(int patientId);
        void Remove(int id);
        void Update(Appointment appointment);
    }
}