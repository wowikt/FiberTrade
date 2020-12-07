using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Common.Models
{
    public class FinishedGame
    {
        public int UserId { get; set; }

        public DateTime GameFinishDate { get; set; }

        public int MoveCount { get; set; }
    }
}
