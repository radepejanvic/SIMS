namespace Library
{
    public interface IDataGenerator
    {
        void GenerateAll(int days);
        void GenerateDoctorSchedule(int days);
        void GenerateDrugs();
        void GenerateRandomDoctorRefferal(int amount);
        void GenerateRandomPerscriptions(int amount);
        void GenerateRandomSpecializationRefferal(int amount);
        void GenerateCustomNotificationConfiguration();
        void GenerateRandomCustomNotification(int count);
        void GenerateRoomSchedule(int days);
        void GenerateRandomHospitalRefferal(int amount);
    }
}