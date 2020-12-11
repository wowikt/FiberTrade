using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameCodeFirstRepository.DataModels
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual ICollection<CurrentGame> CurrentGames { get; set; }
        public virtual ICollection<FinishedGame> FinishedGames { get; set; }
    }
}
