using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameCodeFirstRepository.DataModels
{
    public class CurrentGame
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public DateTime GameStartTime { get; set; }

        public TimeSpan GameTime { get; set; }
        public int MoveCount { get; set; }

        public string Comment { get; set; }

        public virtual ICollection<CurrentGameCell> CurrentGameCells { get; set; }
    }
}
