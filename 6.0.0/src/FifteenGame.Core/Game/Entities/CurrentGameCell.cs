using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Game.Entities
{
    public class CurrentGameCell : Entity<long>
    {
        public int CellIndex { get; set; }

        public int CellValue { get; set; }

        public virtual CurrentGame CurrentGame { get; set; }

        public int CurrentGameId { get; set; }
    }
}
