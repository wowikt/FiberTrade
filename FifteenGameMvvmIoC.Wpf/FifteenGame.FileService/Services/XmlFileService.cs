using FifteenGame.FileService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FifteenGame.FileService.Services
{
    public class XmlFileService
    {
        public void SaveToFile<T>(T model, string fileName)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, model);
            }
        }

        public T ReadFromFile<T>(string fileName)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                return (T)serializer.Deserialize(fs);
            }
        }
    }
}
