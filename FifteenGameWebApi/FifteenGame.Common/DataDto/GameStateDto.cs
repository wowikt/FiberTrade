using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Common.DataDto
{
    public class GameStateDto
    {
        public IEnumerable<int> State { get; set; }

        public int MoveCount { get; set; }

        public DateTime GameStartTime { get; set; } = DateTime.Now;
    }
}
