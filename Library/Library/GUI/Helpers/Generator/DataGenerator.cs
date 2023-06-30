using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

using Library.Model.Enum;
using Library.Serializer;
using Library.Service;
using Library.Repository.Interface;

namespace Library
{
    public class DataGenerator : IDataGenerator
    {
        private static List<string> _names = new List<string> { "Ana", "Jovan", "Marko", "Mihajlo", "Milica", "Nikola", "Petar", "Sofija", "Stefan", "Tamara" };
        private static List<string> _surnames = new List<string> { "Arsić", "Đorđević", "Ilić", "Janković", "Jovanović", "Kovačević", "Marković", "Petrović", "Stojanović", "Vuković" };



        private static Random Random = new Random();

        //private readonly ICRUDRepository<User> _userRepo;


        public DataGenerator()
        {

        }

        public void GenerateAll(int days)
        {
            //_patientRepo.Save(Generate(id => GenerateRandomPatient(id), amount));
            //_doctorRepo.Save(Generate(id => GenerateRandomDoctor(id), amount));
            // TODO: Add remaining models.
            //GerenareRooms();
            //GenerateRoomSchedule(days);
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




        //private int GetRandomPatientId()
        //{
        //    return Random.Next(1, _patientRepo.GetAll().Count);
        //}


        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
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

    }
}
