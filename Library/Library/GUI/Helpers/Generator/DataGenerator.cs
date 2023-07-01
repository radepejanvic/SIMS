using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Enum;
using Library.Core.Model;
using Library.Core.Repository.Interface;
using Library.Model;

using Library.Model.Enum;
using Library.Serializer;
using Library.Service;
using Library.Repository.Interface;
using System.Diagnostics;
using Library.Core.Repository;

namespace Library
{
    public class DataGenerator
    {
        protected Random Random = new();
        
        public DataGenerator()
        {
           
        }

        public void Generate(Action action, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                action();
            }
        }

        protected string GenerateRandomStringOfNumbers(int length)
        {
            var output = "";
            for (int i = 0; i < length; i++)
            {
                output += Random.Next(10);
            }
            return output;
        }

        protected string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }

        protected List<T> GenerateRandomEnumsList<T>() where T : Enum
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

        protected T GenerateRandomEnum<T>() where T : Enum
        {
            return (T)Enum.ToObject(typeof(T), Random.Next(Enum.GetValues(typeof(T)).Length));
        }
        public static List<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

    }
}
