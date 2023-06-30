using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

using Library.Model.Enum;
using Library.View;
using Library.Serializer;
using Library.Service;
using Library.Service.FarmaceuticalService.Interface;
using Library.Model.Refferal;
using Library.Service.TehnicalService.Interface;
using Library.Repository.Interface;

namespace Library
{
    public class DataGenerator : IDataGenerator
    {
        private static List<string> _firstNames = new List<string> { "Ana", "Jovan", "Marko", "Mihajlo", "Milica", "Nikola", "Petar", "Sofija", "Stefan", "Tamara" };
        private static List<string> _lastNames = new List<string> { "Arsić", "Đorđević", "Ilić", "Janković", "Jovanović", "Kovačević", "Marković", "Petrović", "Stojanović", "Vuković" };
        private static List<string> _drugNames= new List<string> { "Aspirin", "Ibuprofen", "Acetaminophen", "Lisinopril", "Metformin", "Simvastatin", "Levothyroxine", "Amoxicillin", "Atorvastatin","Omeprazole"};
        private static List<string> _comments = new List<string>
                                    {
                                        "Molim Vas da se pridržavate propisane terapije prema uputstvima.",
                                        "Uzmite lek prema preporučenoj dozi i učestalosti.",
                                        "Važno je da završite celokupan tretman.",
                                        "Obavezno prisustvujte svim zakazanim terapijskim sesijama.",
                                        "Odmah me obavestite ako doživite bilo kakve neželjene reakcije.",
                                        "Nemojte zanemariti zdrav način života tokom terapije.",
                                        "Slobodno me kontaktirajte ako imate pitanja ili brige.",
                                        "Vodite evidenciju o napretku i eventualnim promenama koje primetite.",
                                        "Obavestite me o svim drugim lekovima koje trenutno uzimate.",
                                        "Obavestite me o eventualnom poboljšanju ili pogoršanju simptoma.",
                                    };


        private static Random Random = new Random();

        //private readonly ICRUDRepository<User> _userRepo;
        private readonly ICRUDRepository<Patient> _patientRepo;
        private readonly ICRUDRepository<Doctor> _doctorRepo;
        private readonly ICRUDRepository<Appointment> _appointmentRepo;
        private readonly ICRUDRepository<DoctorSchedule> _doctorScheduleRepo;
        private readonly ICRUDRepository<Room> _roomRepo;
        private readonly ICRUDRepository<RoomSchedule> _roomScheduleRepo;
        private readonly ICRUDRepository<Drug> _drugRepo;
        private readonly ICRUDRepository<DoctorRefferal> _doctorRefferalRepo;
        private readonly ICRUDRepository<CustomNotification> _notificationRepo;
        private readonly ICRUDRepository<CustomNotificationConfiguration> _notificationConfigRepo;
        private readonly IDrugPerscribingService _drugPerscribingService;
        private readonly ICustomNotificationService _customNotificationService;
        private readonly ICustomNotificationConfigurationService _customNotificationConfigurationService;
        private readonly ICRUDRepository<HospitalRefferal> _hospitalRefferalRepo;

        public DataGenerator(ICRUDRepository<Patient> patientRepo, ICRUDRepository<Doctor> doctorRepo, ICRUDRepository<Appointment> appointmentRepo, ICRUDRepository<DoctorSchedule> doctorScheduleRepo, ICRUDRepository<RoomSchedule> roomScheduleRepo, ICRUDRepository<Room> roomRepo, ICRUDRepository<Drug> drugRepo, IDrugPerscribingService drugPerscribingService, ICRUDRepository<DoctorRefferal> doctorRefferalRepo, ICustomNotificationService customNotificationService,ICustomNotificationConfigurationService customNotificationConfigurationService, ICRUDRepository<CustomNotification> notificationRepo, ICRUDRepository<CustomNotificationConfiguration> notificationConfigRepo, ICRUDRepository<HospitalRefferal> hospitalRefferalRepo)
        {
            _patientRepo = patientRepo;
            _doctorRepo = doctorRepo;
            _appointmentRepo = appointmentRepo;
            _doctorScheduleRepo = doctorScheduleRepo;
            _roomScheduleRepo = roomScheduleRepo;
            _roomRepo = roomRepo;
            _drugRepo = drugRepo;
            _drugPerscribingService = drugPerscribingService;
            _doctorRefferalRepo = doctorRefferalRepo;
            _notificationRepo = notificationRepo;
            _notificationConfigRepo = notificationConfigRepo;
            _customNotificationService = customNotificationService;
            _customNotificationConfigurationService = customNotificationConfigurationService;
            _hospitalRefferalRepo = hospitalRefferalRepo;
        }

        public void GenerateAll(int days)
        {
            //_patientRepo.Save(Generate(id => GenerateRandomPatient(id), amount));
            //_doctorRepo.Save(Generate(id => GenerateRandomDoctor(id), amount));
            // TODO: Add remaining models.
            //GerenareRooms();
            GenerateRoomSchedule(days);
            //GenerateDoctorSchedule(days);
        }

        private Dictionary<int, T> Generate<T>(Func<int, T> generator, int length) where T : ISerializable
        {
            var data = new Dictionary<int, T>();
            int id = 1;
            while (data.Values.Count < length)
            {
                var obj = generator(id);
                data.Add(id, obj);
                id++;
            }
            return data;
        }

        private Patient GenerateRandomPatient(int id)
        {
            return new Patient(id, GenerateRandomString(7), _firstNames[Random.Next(_firstNames.Count)], _lastNames[Random.Next(_lastNames.Count)], GenerateRandomString(7), GenerateRandomMedicalRecord());
        }

        private Doctor GenerateRandomDoctor(int id)
        {
            return new Doctor(id, GenerateRandomString(7), _firstNames[Random.Next(_firstNames.Count)], _lastNames[Random.Next(_lastNames.Count)], GenerateRandomString(7), GenerateRandomEnum<Specialization>());
        }

        public void GenerateDrugs()
        {
            foreach (string drugName in _drugNames)
            {
                _drugRepo.Add(new Drug(drugName, GenerateRandomEnumsList<Alergy>(), Random.Next(12, 36), 10));
            }
        }

        private Nurse GenerateRandomNurse(int id)
        {
            return new Nurse(id, GenerateRandomString(7), _firstNames[Random.Next(_firstNames.Count)], _lastNames[Random.Next(_lastNames.Count)], GenerateRandomString(7));
        }

        public void GenerateRandomPerscriptions(int amount)
        {
            for (int i = 0; i < amount; i ++)
            {
                _drugPerscribingService.PerscribeTherapy(GetRandomAppointmentId(), GetRandomPatientId(), GetRandomDrugId(), GenerateRandomInstruction());
            }   
        }

        public void GenerateRandomDoctorRefferal(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _doctorRefferalRepo.Add(new DoctorRefferal(GetRandomDoctorId(), GetRandomPatientId(), false, 15));
            }
        }

        public void GenerateRandomSpecializationRefferal(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var doctor = _doctorRepo.Get(GetRandomDoctorId());
                _doctorRefferalRepo.Add(new DoctorRefferal(doctor.Specialization, GetRandomPatientId(), false, 15));
            }
        }

        public void GenerateRandomHospitalRefferal(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _hospitalRefferalRepo.Add(new HospitalRefferal(GetRandomPatientId(), Random.Next(1, 15), 1, Random.Next(2) == 0));
            }
        }

        private int GetRandomPatientId()
        {
            return Random.Next(1, _patientRepo.GetAll().Count);
        }

        private int GetRandomDoctorId()
        {
            return Random.Next(1, _doctorRepo.GetAll().Count);
        }

        private int GetRandomDrugId()
        {
            return Random.Next(1, _drugRepo.GetAll().Count);
        }

        private int GetRandomAppointmentId()
        {
            return Random.Next(1, _appointmentRepo.GetAll().Count);
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }
        private MedicalRecord GenerateRandomMedicalRecord()
        {
            return new MedicalRecord(Random.Next(150, 200), Random.Next(50, 150), GenerateRandomEnumsList<Disease>(), GenerateRandomEnumsList<Alergy>());
        }

        private Instruction GenerateRandomInstruction()
        {
            return new Instruction(Random.Next(1, 3), Random.Next(1, 3), _comments[Random.Next(_comments.Count)], GenerateRandomEnum<MedicationIntakeTime>());
        }

        private List<T> GenerateRandomEnumsList<T>() where T : Enum
        {
            var enums = new List<T>();
            var length = Random.Next(1, 11);

            while (enums.Count < length)
            {
                var value = (T)Enum.ToObject(typeof(T), Random.Next(Enum.GetValues(typeof(T)).Length));
                if (!enums.Contains(value))
                {
                    enums.Add(value);
                }
            }
            return enums;
        }

        private T GenerateRandomEnum<T>() where T : Enum
        {
            return (T)Enum.ToObject(typeof(T), Random.Next(Enum.GetValues(typeof(T)).Length));
        }
        public static List<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        private List<StaticEquipment> GenerateAllEquipment()
        {
            List<StaticEquipment> allEquipment = new List<StaticEquipment>();
            Random random = new Random();

            foreach (StaticEquipmentType type in Enum.GetValues(typeof(StaticEquipmentType)))
            {
                int purposeCount = Enum.GetNames(typeof(EquipmentPurpose)).Length;
                EquipmentPurpose purpose = (EquipmentPurpose)random.Next(purposeCount);
                int quantity = new Random().Next(1, 11);

                StaticEquipment equipment = new StaticEquipment(type, purpose, quantity);

                allEquipment.Add(equipment);

            }

            return allEquipment;
        }
        private List<DynamicalEquipment> GenerateEquipment()
        {
            List<DynamicalEquipment> allEquipment = new List<DynamicalEquipment>();
            Random random = new Random();

            foreach (DynamicalEquipmentType type in Enum.GetValues(typeof(DynamicalEquipmentType)))
            {
                int quantity = new Random().Next(1, 11);

                DynamicalEquipment equipment = new DynamicalEquipment(type, quantity);

                allEquipment.Add(equipment);

            }

            return allEquipment;
        }

        public void GerenareRooms()
        {
            _roomRepo.Add(new Room(000, RoomType.WAREHOUSE, GenerateAllEquipment(), GenerateEquipment()));
            _roomRepo.Add(new Room(001, RoomType.OPERATION_ROOM, GenerateAllEquipment(), GenerateEquipment()));
            _roomRepo.Add(new Room(002, RoomType.OPERATION_ROOM, GenerateAllEquipment(), GenerateEquipment()));
            _roomRepo.Add(new Room(003, RoomType.EXAMINATION_ROOM, GenerateAllEquipment(), GenerateEquipment()));
            _roomRepo.Add(new Room(004, RoomType.EXAMINATION_ROOM, GenerateAllEquipment(), GenerateEquipment()));
            _roomRepo.Add(new Room(005, RoomType.EXAMINATION_ROOM, GenerateAllEquipment(), GenerateEquipment()));
            _roomRepo.Add(new Room(006, RoomType.EXAMINATION_ROOM, GenerateAllEquipment(), GenerateEquipment()));
            _roomRepo.Add(new Room(007, RoomType.ROOM_FOR_THE_PATIENT, GenerateAllEquipment(), GenerateEquipment()));
            _roomRepo.Add(new Room(008, RoomType.ROOM_FOR_THE_PATIENT, GenerateAllEquipment(), GenerateEquipment()));
            _roomRepo.Add(new Room(009, RoomType.ROOM_FOR_THE_PATIENT, GenerateAllEquipment(), GenerateEquipment()));
            _roomRepo.Add(new Room(010, RoomType.ROOM_FOR_THE_PATIENT, GenerateAllEquipment(), GenerateEquipment()));
            _roomRepo.Add(new Room(011, RoomType.WAITING_ROOM, GenerateAllEquipment(), GenerateEquipment()));
        }

        public void GenerateDoctorSchedule(int days)
        {
            foreach (int id in _doctorRepo.GetAll().Keys)
            {
                var doctorSchedule = new DoctorSchedule(id, GenerateFreeTimeSlots(days), GenerateAppointments(days));
                _doctorScheduleRepo.Add(doctorSchedule);
            }
        }
        public void GenerateRoomSchedule(int days)
        {
            Dictionary<int, RoomSchedule> rooms = new Dictionary<int, RoomSchedule>();
            foreach (int id in _roomRepo.GetAll().Keys)
            {
                if (_roomRepo.Get(id).RoomType==RoomType.OPERATION_ROOM || _roomRepo.Get(id).RoomType == RoomType.EXAMINATION_ROOM)
                {
                    var roomSchedule = new RoomSchedule(id, GenerateFreeTimeSlots(days), GenerateAppointments(days));
                    rooms[id]=roomSchedule;
                }
            }
            _roomScheduleRepo.Save(rooms);
        }

        private Dictionary<DateOnly, List<TimeSlot>> GenerateFreeTimeSlots(int days)
        {
            var today = DateTime.Today;
            var freeTimeSlots = new Dictionary<DateOnly, List<TimeSlot>>();
            for (int i = 0; i < days; i++)
            {
                var day = today.AddDays(i);
                var freeTimeSlotsList = new List<TimeSlot>();
                freeTimeSlotsList.Add(new TimeSlot(day.AddHours(8), day.AddHours(20)));

                freeTimeSlots.Add(DateOnly.FromDateTime(day), freeTimeSlotsList);
            }
            return freeTimeSlots;
        }

        private Dictionary<DateOnly, List<int>> GenerateAppointments(int days)
        {
            var today = DateTime.Today;
            var freeTimeSlots = new Dictionary<DateOnly, List<int>>();
            for (int i = 0; i < days; i++)
            {
                var day = today.AddDays(i);
                var freeTimeSlotsList = new List<int>();

                freeTimeSlots.Add(DateOnly.FromDateTime(day), freeTimeSlotsList);
            }
            return freeTimeSlots;
        }

        public void GenerateCustomNotificationConfiguration()
        {
            var patients = _patientRepo.GetAll().Values;
            foreach(var patient in patients){
                var configuration = new CustomNotificationConfiguration(patient.Id, 15);
                _customNotificationConfigurationService.Add(configuration);
            }
        }

        public void GenerateRandomCustomNotification(int count)
        {
            for(int i = 0; i < count; i++)
            {
                _customNotificationService.Add(GetRandomPatientId(), new DateOnly(2023, 5, 27), new DateOnly(2023, 5, 29), 3, "Amoksicilin 200mg pre obroka");
            }
        }

    }
}
