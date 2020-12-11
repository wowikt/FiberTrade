using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Common.DataDto
{
    public class FinishedGameDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime GameFinishDate { get; set; }

        public int MoveCount { get; set; }

        public TimeSpan? GameTime { get; set; }
    }
}
