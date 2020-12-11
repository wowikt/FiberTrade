using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameCodeFirstRepository.DataModels
{
    public class CurrentGameCell
    {
        public long Id { get; set; }
        public int CellIndex { get; set; }
        public int CellValue { get; set; }

        public virtual CurrentGame CurrentGame { get; set; }
    }
}
