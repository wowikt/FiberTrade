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
        public void SaveToFile(SaveGameStateModel model, string fileName)
        {
            var serializer = new XmlSerializer(typeof(SaveGameStateModel));
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, model);
            }
        }

        public SaveGameStateModel ReadFromFile(string fileName)
        {
            var serializer = new XmlSerializer(typeof(SaveGameStateModel));
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                return (SaveGameStateModel)serializer.Deserialize(fs);
            }
        }
    }
}
