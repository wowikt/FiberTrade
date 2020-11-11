using FifteenGame.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Common.Dto
{
    public class MoveInputDto
    {
        public IEnumerable<int> State { get; set; }

        public MoveDirection Direction { get; set; }
    }
}
