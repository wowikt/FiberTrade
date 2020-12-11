using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameCodeFirstRepository.DataModels
{
    public class FinishedGame
    {
        public int Id { get; set; }
        public DateTime GameFinishDate { get; set; }
        public int MoveCount { get; set; }
        public TimeSpan? GameTime { get; set; }

        public virtual User User { get; set; }
    }
}
