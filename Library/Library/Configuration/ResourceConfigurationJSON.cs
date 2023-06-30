using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Checkup;
using Library.Model.Refferal;

namespace Library.Configuration
{
    public class ResourceConfigurationJSON<T> : IResourceConfiguration<T>
    {
        private string PatientJSON = @"..\..\..\Data\patient.json";
        private string DoctorJSON = @"..\..\..\Data\doctor.json";
        private string DoctorScheduleJSON = @"..\..\..\Data\doctorSchedule.json";
        private string DirectorJSON = @"..\..\..\Data\director.json";
        private string NurseJSON = @"..\..\..\Data\nurse.json";
        private string DynamicalEquipmentRequestJSON = @"..\..\..\Data\dynamicalEquipmentRequest.json";
        private string AppointmentNotificationJSON = @"..\..\..\Data\appointmentNotification.json";
        private string RoomJSON = @"..\..\..\Data\room.json";
        private string AppointmentJSON = @"..\..\..\Data\appointment.json";
        private string AnamnesisJSON = @"..\..\..\Data\anamnesis.json";
        private string DoctorRefferalJSON = @"..\..\..\Data\doctorRefferal.json";
        private string HospitalRefferalJSON = @"..\..\..\Data\hospitalRefferal.json";
        private string PerscriptionJSON = @"..\..\..\Data\perscription.json";
        private string DrugJSON = @"..\..\..\Data\drug.json";
        private string RoomScheduleJSON = @"..\..\..\Data\roomSchedule.json";
        private string DrugOrderJSON = @"..\..\..\Data\drugOrder.json";
        private string RoomRenovationJSON = @"..\..\..\Data\roomRenovation.json";
        private string RoomDefusingRenovationJSON = @"..\..\..\Data\roomDefusingRenovation.json";
        private string RoomFusingRenovationJSON = @"..\..\..\Data\roomFusingRenovation.json";
        private string LeaveRequestJSON = @"..\..\..\Data\leaveRequest.json";
        private string PatientPlacementJSON = @"..\..\..\Data\patientPlacement.json";
        private string PatientCheckupJSON = @"..\..\..\Data\patientCheckup.json";

        private readonly string CustomNotificationJSON = @"..\..\..\Data\customNotification.json";
        private readonly string CustomNotificationConfigurationJSON = @"..\..\..\Data\customNotificationConfiguration.json";
        private readonly string HospitalSurveyJSON = @"..\..\..\Data\hospitalSurvey.json";
        private readonly string DoctorSurveyJSON = @"..\..\..\Data\doctorSurvey.json";
        private readonly string MessagesJSON = @"..\..\..\Data\messages.json";

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
                nameof(LeaveRequest) => LeaveRequestJSON,
                nameof(HospitalSurvey) => HospitalSurveyJSON,
                nameof(DoctorSurvey) => DoctorSurveyJSON,
                nameof(PatientPlacement) => PatientPlacementJSON,
                nameof(PatientCheckup) => PatientCheckupJSON,
                nameof(Message) => MessagesJSON,
                _ => string.Empty,
            };
        }
    }
}
