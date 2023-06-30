using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Refferal;
using Library.Model;

namespace Library.Configuration
{
    public class TestResourceConfiguration<T> : IResourceConfiguration<T>
    {
        private string PatientJSON = @"..\..\..\Test\patient.json";
        private string DoctorJSON = @"..\..\..\Test\doctor.json";
        private string DoctorScheduleJSON = @"..\..\..\Test\doctorSchedule.json";
        private string DirectorJSON = @"..\..\..\Test\director.json";
        private string NurseJSON = @"..\..\..\Test\nurse.json";
        private string DynamicalEquipmentRequestJSON = @"..\..\..\Test\dynamicalEquipmentRequest.json";
        private string AppointmentNotificationJSON = @"..\..\..\Test\appointmentNotification.json";
        private string RoomJSON = @"..\..\..\Test\room.json";
        private string AppointmentJSON = @"..\..\..\Test\appointment.json";
        private string AnamnesisJSON = @"..\..\..\Test\anamnesis.json";
        private string DoctorRefferalJSON = @"..\..\..\Test\doctorRefferal.json";
        private string HospitalRefferalJSON = @"..\..\..\Test\hospitalRefferal.json";
        private string PerscriptionJSON = @"..\..\..\Test\perscription.json";
        private string DrugJSON = @"..\..\..\Test\drug.json";
        private string RoomScheduleJSON = @"..\..\..\Test\roomSchedule.json";
        private string DrugOrderJSON = @"..\..\..\Test\drugOrder.json";
        private string RoomRenovationJSON = @"..\..\..\Test\roomRenovation.json";
        private string RoomDefusingRenovationJSON = @"..\..\..\Test\roomDefusingRenovation.json";
        private string RoomFusingRenovationJSON = @"..\..\..\Test\roomFusingRenovation.json";

        private readonly string CustomNotificationJSON = @"..\..\..\Test\customNotification.json";
        private readonly string CustomNotificationConfigurationJSON = @"..\..\..\Test\customNotificationConfiguration.json";

        public string GetResourcePath()
        {
            return typeof(T).Name switch
            {
                nameof(Patient) => PatientJSON,
                nameof(Doctor) => DoctorJSON,
                nameof(DoctorSchedule) => DoctorScheduleJSON,
                nameof(RoomSchedule) => RoomScheduleJSON,
                nameof(Director) => DirectorJSON,
                nameof(Nurse) => NurseJSON,
                nameof(DynamicalEquipmentRequest) => DynamicalEquipmentRequestJSON,
                nameof(AppointmentNotification) => AppointmentNotificationJSON,
                nameof(Room) => RoomJSON,
                nameof(Appointment) => AppointmentJSON,
                nameof(Anamnesis) => AnamnesisJSON,
                nameof(DoctorRefferal) => DoctorRefferalJSON,
                nameof(HospitalRefferal) => HospitalRefferalJSON,
                nameof(Perscription) => PerscriptionJSON,
                nameof(Drug) => DrugJSON,
                nameof(DrugOrder) => DrugOrderJSON,
                nameof(CustomNotification) => CustomNotificationJSON,
                nameof(CustomNotificationConfiguration) => CustomNotificationConfigurationJSON,
                nameof(RoomRenovation) => RoomRenovationJSON,
                nameof(RoomDefusingRenovation) => RoomDefusingRenovationJSON,
                nameof(RoomFusingRenovation) => RoomFusingRenovationJSON,
                _ => string.Empty,
            };
        }
    }
}
