using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.FileService.Services
{
    public class JsonFileService
    {
        public void SaveToFile<T>(T model, string fileName)
        {
            var serializer = new JsonSerializer();
            using (var fs = new StreamWriter(fileName))
            {
                using (var js = new JsonTextWriter(fs))
                {
                    serializer.Serialize(js, model);
                }
            }
        }

        public T ReadFromFile<T>(string fileName)
        {
            using (var fs = new StreamReader(fileName))
            {
                var serializer = new JsonSerializer();
                return (T)serializer.Deserialize(fs, typeof(T));
            }
        }
    }
}
