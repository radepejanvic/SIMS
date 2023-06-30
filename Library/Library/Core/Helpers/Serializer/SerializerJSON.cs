using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Library.Configuration;

namespace Library.Serializer
{
    public class SerializerJSON<T> : ISerializer<T> where T : ISerializable, new()
    {
        private IResourceConfiguration<T> _resourceConfig;
        public SerializerJSON(IResourceConfiguration<T> resourceConfig)
        {
            _resourceConfig = resourceConfig;
        }

        public void Save(Dictionary<int, T> objects)
        {
            var filepath = _resourceConfig.GetResourcePath();

            using (StreamWriter file = File.CreateText(filepath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, objects);
            }
        }

        public Dictionary<int, T> Load()
        {
            string json;
            var filepath = _resourceConfig.GetResourcePath();

            using (StreamReader file = File.OpenText(filepath))
            {
                json = file.ReadToEnd();
            }
            Dictionary<int, T> objects = JsonConvert.DeserializeObject<Dictionary<int, T>>(json);

            return objects ?? new Dictionary<int, T>();
        }
    }
}
