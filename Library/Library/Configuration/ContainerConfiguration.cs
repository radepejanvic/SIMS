using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Checkup;
using Library.Model.Refferal;
using Library.Repository;
using Library.Repository.Interface;
using Library.Serializer;
using Library.Service.AppointmentService;
using Library.Service.AppointmentService.Interface;
using Library.Service.FarmaceuticalService;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.HospitalTreatmentService;
using Library.Service.HospitalTreatmentService.Interface;
using Library.Service.MessageService;
using Library.Service.LeaveRequestService;
using Library.Service.LeaveRequestService.Interface;
using Library.Service.PersonService;
using Library.Service.PersonService.Interface;
using Library.Service.PhysicalAssetService;
using Library.Service.PhysicalAssetService.Interface;
using Library.Service.RefferalService;
using Library.Service.RefferalService.Interface;
using Library.Service.ScheduleService;
using Library.Service.ScheduleService.Interface;
using Library.Service.SurveyService;
using Library.Service.TehnicalService;
using Library.Service.TehnicalService.Interface;
using Library.Core.TehnicalService.Interface;

namespace Library.Configuration
{
    public static class ContainerConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PatientService>().As<IPatientService>();
            builder.RegisterType<CRUDRepository<Patient>>().As<ICRUDRepository<Patient>>();
            builder.RegisterType<SerializerJSON<Patient>>().As<ISerializer<Patient>>();
            builder.RegisterType<ResourceConfigurationJSON<Patient>>().As<IResourceConfiguration<Patient>>();

            builder.RegisterType<DoctorService>().As<IDoctorService>();
            builder.RegisterType<CRUDRepository<Doctor>>().As<ICRUDRepository<Doctor>>();
            builder.RegisterType<SerializerJSON<Doctor>>().As<ISerializer<Doctor>>();
            builder.RegisterType<ResourceConfigurationJSON<Doctor>>().As<IResourceConfiguration<Doctor>>();

            builder.RegisterType<AppointmentService>().As<IAppointmentService>();
            builder.RegisterType<CRUDRepository<Appointment>>().As<ICRUDRepository<Appointment>>();
            builder.RegisterType<SerializerJSON<Appointment>>().As<ISerializer<Appointment>>();
            builder.RegisterType<ResourceConfigurationJSON<Appointment>>().As<IResourceConfiguration<Appointment>>();

            builder.RegisterType<AnamnesisService>().As<IAnamnesisService>();
            builder.RegisterType<CRUDRepository<Anamnesis>>().As<ICRUDRepository<Anamnesis>>();
            builder.RegisterType<SerializerJSON<Anamnesis>>().As<ISerializer<Anamnesis>>();
            builder.RegisterType<ResourceConfigurationJSON<Anamnesis>>().As<IResourceConfiguration<Anamnesis>>();

            builder.RegisterType<AppointmentInitiationService>().As<IAppointmentInitiationService>();

            builder.RegisterType<DoctorScheduleService>().As<IDoctorScheduleService>();
            builder.RegisterType<CRUDRepository<DoctorSchedule>>().As<ICRUDRepository<DoctorSchedule>>();
            builder.RegisterType<SerializerJSON<DoctorSchedule>>().As<ISerializer<DoctorSchedule>>();
            builder.RegisterType<ResourceConfigurationJSON<DoctorSchedule>>().As<IResourceConfiguration<DoctorSchedule>>();

            builder.RegisterType<RoomScheduleService>().As<IRoomScheduleService>();
            builder.RegisterType<CRUDRepository<RoomSchedule>>().As<ICRUDRepository<RoomSchedule>>();
            builder.RegisterType<SerializerJSON<RoomSchedule>>().As<ISerializer<RoomSchedule>>();
            builder.RegisterType<ResourceConfigurationJSON<RoomSchedule>>().As<IResourceConfiguration<RoomSchedule>>();

            builder.RegisterType<SchedulingService>().As<ISchedulingService>();

            builder.RegisterType<AppointmentNotificationService>().As<IAppointmentNotificationService>();
            builder.RegisterType<CRUDRepository<AppointmentNotification>>().As<ICRUDRepository<AppointmentNotification>>();
            builder.RegisterType<SerializerJSON<AppointmentNotification>>().As<ISerializer<AppointmentNotification>>();
            builder.RegisterType<ResourceConfigurationJSON<AppointmentNotification>>().As<IResourceConfiguration<AppointmentNotification>>();

            builder.RegisterType<LoginService>().As<ILoginService>();
            builder.RegisterType<CRUDRepository<Director>>().As<ICRUDRepository<Director>>();
            builder.RegisterType<SerializerJSON<Director>>().As<ISerializer<Director>>();
            builder.RegisterType<ResourceConfigurationJSON<Director>>().As<IResourceConfiguration<Director>>();

            builder.RegisterType<CRUDRepository<Nurse>>().As<ICRUDRepository<Nurse>>();
            builder.RegisterType<SerializerJSON<Nurse>>().As<ISerializer<Nurse>>();
            builder.RegisterType<ResourceConfigurationJSON<Nurse>>().As<IResourceConfiguration<Nurse>>();

            builder.RegisterType<RoomService>().As<IRoomService>();
            builder.RegisterType<CRUDRepository<Room>>().As<ICRUDRepository<Room>>();
            builder.RegisterType<SerializerJSON<Room>>().As<ISerializer<Room>>();
            builder.RegisterType<ResourceConfigurationJSON<Room>>().As<IResourceConfiguration<Room>>();

            builder.RegisterType<EquipmentService>().As<IEquipmentService>();
            builder.RegisterType<CRUDRepository<DynamicalEquipmentRequest>>().As<ICRUDRepository<DynamicalEquipmentRequest>>();
            builder.RegisterType<SerializerJSON<DynamicalEquipmentRequest>>().As<ISerializer<DynamicalEquipmentRequest>>();
            builder.RegisterType<ResourceConfigurationJSON<DynamicalEquipmentRequest>>().As<IResourceConfiguration<DynamicalEquipmentRequest>>();

            builder.RegisterType<DoctorRefferalService>().As<IDoctorRefferalService>();
            builder.RegisterType<CRUDRepository<DoctorRefferal>>().As<ICRUDRepository<DoctorRefferal>>();
            builder.RegisterType<SerializerJSON<DoctorRefferal>>().As<ISerializer<DoctorRefferal>>();
            builder.RegisterType<ResourceConfigurationJSON<DoctorRefferal>>().As<IResourceConfiguration<DoctorRefferal>>();

            builder.RegisterType<HospitalRefferalService>().As<IHospitalRefferalService>();
            builder.RegisterType<CRUDRepository<HospitalRefferal>>().As<ICRUDRepository<HospitalRefferal>>();
            builder.RegisterType<SerializerJSON<HospitalRefferal>>().As<ISerializer<HospitalRefferal>>();
            builder.RegisterType<ResourceConfigurationJSON<HospitalRefferal>>().As<IResourceConfiguration<HospitalRefferal>>();

            builder.RegisterType<DrugService>().As<IDrugService>();
            builder.RegisterType<CRUDRepository<Drug>>().As<ICRUDRepository<Drug>>();
            builder.RegisterType<SerializerJSON<Drug>>().As<ISerializer<Drug>>();
            builder.RegisterType<ResourceConfigurationJSON<Drug>>().As<IResourceConfiguration<Drug>>();

            builder.RegisterType<PerscriptionService>().As<IPerscriptionService>();
            builder.RegisterType<CRUDRepository<Perscription>>().As<ICRUDRepository<Perscription>>();
            builder.RegisterType<SerializerJSON<Perscription>>().As<ISerializer<Perscription>>();
            builder.RegisterType<ResourceConfigurationJSON<Perscription>>().As<IResourceConfiguration<Perscription>>();

            builder.RegisterType<DrugPerscribingService>().As<IDrugPerscribingService>();
            builder.RegisterType<DrugWarehouseService>().As<IDrugWarehouseService>();

            builder.RegisterType<DrugOrderService>().As<IDrugOrderService>();
            builder.RegisterType<CRUDRepository<DrugOrder>>().As<ICRUDRepository<DrugOrder>>();
            builder.RegisterType<SerializerJSON<DrugOrder>>().As<ISerializer<DrugOrder>>();
            builder.RegisterType<ResourceConfigurationJSON<DrugOrder>>().As<IResourceConfiguration<DrugOrder>>();

            builder.RegisterType<CustomNotificationService>().As<ICustomNotificationService>();
            builder.RegisterType<CRUDRepository<CustomNotification>>().As<ICRUDRepository<CustomNotification>>();
            builder.RegisterType<SerializerJSON<CustomNotification>>().As<ISerializer<CustomNotification>>();
            builder.RegisterType<ResourceConfigurationJSON<CustomNotification>>().As<IResourceConfiguration<CustomNotification>>();

            builder.RegisterType<CustomNotificationConfigurationService>().As<ICustomNotificationConfigurationService>();
            builder.RegisterType<CRUDRepository<CustomNotificationConfiguration>>().As<ICRUDRepository<CustomNotificationConfiguration>>();
            builder.RegisterType<SerializerJSON<CustomNotificationConfiguration>>().As<ISerializer<CustomNotificationConfiguration>>();
            builder.RegisterType<ResourceConfigurationJSON<CustomNotificationConfiguration>>().As<IResourceConfiguration<CustomNotificationConfiguration>>();

            builder.RegisterType<RoomRenovationService>().As<IRoomRenovationService>();
            builder.RegisterType<CRUDRepository<RoomRenovation>>().As<ICRUDRepository<RoomRenovation>>();
            builder.RegisterType<SerializerJSON<RoomRenovation>>().As<ISerializer<RoomRenovation>>();
            builder.RegisterType<ResourceConfigurationJSON<RoomRenovation>>().As<IResourceConfiguration<RoomRenovation>>();

            builder.RegisterType<RoomDefusingRenovationService>().As<IRoomDefusingRenovationService>();
            builder.RegisterType<CRUDRepository<RoomDefusingRenovation>>().As<ICRUDRepository<RoomDefusingRenovation>>();
            builder.RegisterType<SerializerJSON<RoomDefusingRenovation>>().As<ISerializer<RoomDefusingRenovation>>();
            builder.RegisterType<ResourceConfigurationJSON<RoomDefusingRenovation>>().As<IResourceConfiguration<RoomDefusingRenovation>>();

            builder.RegisterType<RoomFusingRenovationService>().As<IRoomFusingRenovationService>();
            builder.RegisterType<CRUDRepository<RoomFusingRenovation>>().As<ICRUDRepository<RoomFusingRenovation>>();
            builder.RegisterType<SerializerJSON<RoomFusingRenovation>>().As<ISerializer<RoomFusingRenovation>>();
            builder.RegisterType<ResourceConfigurationJSON<RoomFusingRenovation>>().As<IResourceConfiguration<RoomFusingRenovation>>();

            builder.RegisterType<PatientPlacementService>().As<IPatientPlacementService>();
            builder.RegisterType<CRUDRepository<PatientPlacement>>().As<ICRUDRepository<PatientPlacement>>();
            builder.RegisterType<SerializerJSON<PatientPlacement>>().As<ISerializer<PatientPlacement>>();
            builder.RegisterType<ResourceConfigurationJSON<PatientPlacement>>().As<IResourceConfiguration<PatientPlacement>>();

            builder.RegisterType<PatientCheckupService>().As<IPatientCheckupService>();
            builder.RegisterType<CRUDRepository<PatientCheckup>>().As<ICRUDRepository<PatientCheckup>>();
            builder.RegisterType<SerializerJSON<PatientCheckup>>().As<ISerializer<PatientCheckup>>();
            builder.RegisterType<ResourceConfigurationJSON<PatientCheckup>>().As<IResourceConfiguration<PatientCheckup>>();


            builder.RegisterType<LeaveRequestService>().As<ILeaveRequestService>();
            builder.RegisterType<CRUDRepository<LeaveRequest>>().As<ICRUDRepository<LeaveRequest>>();
            builder.RegisterType<SerializerJSON<LeaveRequest>>().As<ISerializer<LeaveRequest>>();
            builder.RegisterType<ResourceConfigurationJSON<LeaveRequest>>().As<IResourceConfiguration<LeaveRequest>>();

            builder.RegisterType<RenovationService>().As<IRenovationService>();
            
            builder.RegisterType<HospitalTreatmentService>().As<IHospitalTreatmentService>();

            builder.RegisterType<DataGenerator>().As<IDataGenerator>();
            builder.RegisterType<RefferalSchedulingService>().As<IRefferalSchedulingService>();
            builder.RegisterType<PerscriptionSchedulingService>().As<IPerscriptionSchedulingService>();

            builder.RegisterType<AnamnesisRepository>().As<IAnamnesisRepository>();
            builder.RegisterType<AppointmentRepository>().As<IAppointmentRepository>();
            builder.RegisterType<PatientRepository>().As<IPatientRepository>();
            builder.RegisterType<DoctorRepository>().As<IDoctorRepository>();
            builder.RegisterType<DoctorScheduleRepository>().As<IDoctorScheduleRepository>();
            builder.RegisterType<AppointmentNotificationRepository>().As<IAppointmentNotificationRepository>();
            builder.RegisterType<CustomNotificationConfigurationRepository>().As<ICustomNotificationConfigurationRepository>();
            builder.RegisterType<CustomNotificationRepository>().As<ICustomNotificationRepository>();
            builder.RegisterType<DoctorRefferalRepository>().As<IDoctorRefferalRepository>();
            builder.RegisterType<HospitalRefferalRepository>().As<IHospitalRefferalRepository>();
            builder.RegisterType<DrugOrderRepository>().As<IDrugOrderRepository>();
            builder.RegisterType<DrugRepository>().As<IDrugRepository>();
            builder.RegisterType<PrescriptionRepository>().As<IPrescriptionRepository>();
            builder.RegisterType<RoomDefusingRenovationRepository>().As<IRoomDefusingRenovationRepository>();
            builder.RegisterType<RoomFusingRenovationRepository>().As<IRoomFusingRenovationRepository>();
            builder.RegisterType<RoomRenovationRepository>().As<IRoomRenovationRepository>();
            builder.RegisterType<RoomScheduleRepository>().As<IRoomScheduleRepository>();
            builder.RegisterType<DynamicalEquipmentRequestRepository>().As<IDynamicalEquipmentRequestRepository>();
            builder.RegisterType<RoomRepository>().As<IRoomRepository>();
            builder.RegisterType<LeaveRequestRepository>().As<ILeaveRequestRepository>();
            builder.RegisterType<PatientPlacementRepository>().As<IPatientPlacementRepository>();
            builder.RegisterType<PatientCheckupRepository>().As<IPatientCheckupRepository>();



            builder.RegisterType<HospitalSurveyService>().As<IHospitalSurveyService>();
            builder.RegisterType<HospitalSurveyRepository>().As<IHospitalSurveyRepository>();
            builder.RegisterType<CRUDRepository<HospitalSurvey>>().As<ICRUDRepository<HospitalSurvey>>();
            builder.RegisterType<SerializerJSON<HospitalSurvey>>().As<ISerializer<HospitalSurvey>>();
            builder.RegisterType<ResourceConfigurationJSON<HospitalSurvey>>().As<IResourceConfiguration<HospitalSurvey>>();


            builder.RegisterType<DoctorSurveyService>().As<IDoctorSurveyService>();
            builder.RegisterType<DoctorSurveyRepository>().As<IDoctorSurveyRepository>();
            builder.RegisterType<CRUDRepository<DoctorSurvey>>().As<ICRUDRepository<DoctorSurvey>>();
            builder.RegisterType<SerializerJSON<DoctorSurvey>>().As<ISerializer<DoctorSurvey>>();
            builder.RegisterType<ResourceConfigurationJSON<DoctorSurvey>>().As<IResourceConfiguration<DoctorSurvey>>();

            builder.RegisterType<MessageService>().As<IMessageService>();
            builder.RegisterType<MessageRepository>().As<IMessageRepository>();
            builder.RegisterType<CRUDRepository<Message>>().As<ICRUDRepository<Message>>();
            builder.RegisterType<SerializerJSON<Message>>().As<ISerializer<Message>>();
            builder.RegisterType<ResourceConfigurationJSON<Message>>().As<IResourceConfiguration<Message>>();

            builder.RegisterType<NurseService>().As<INurseService>();
            builder.RegisterType<NurseRepository>().As<INurseRepository>();

            return builder.Build();
        }
    }
}
