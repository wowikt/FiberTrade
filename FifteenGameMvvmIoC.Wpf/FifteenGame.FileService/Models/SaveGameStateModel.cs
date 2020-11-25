using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FifteenGame.FileService.Models
{
    [Serializable]
    [XmlRoot("GameState")]
    public class SaveGameStateModel
    {
        [XmlArray("Cells")]
        [XmlArrayItem("Cell")]
        public List<int> State { get; set; }

        [XmlElement("GameTime")]
        [JsonProperty("GameTime")]
        public string GameTimeText
        {
            get => GameTime.ToString();
            set => GameTime = TimeSpan.Parse(value);
        }

        [XmlIgnore]
        [JsonIgnore]
        public TimeSpan GameTime { get; set; }

        public int MoveCount { get; set; }
    }
}
