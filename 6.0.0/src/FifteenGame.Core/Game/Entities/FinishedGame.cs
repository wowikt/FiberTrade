using Abp.Domain.Entities;
using FifteenGame.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Game.Entities
{
    public class FinishedGame : Entity
    {
        public DateTime GameFinishDate { get; set; }

        public int MoveCount { get; set; }

        public TimeSpan? GameTime { get; set; }

        public virtual User User { get; set; }
    }
}
