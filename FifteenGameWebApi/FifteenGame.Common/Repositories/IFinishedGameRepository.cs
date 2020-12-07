using FifteenGame.Common.DataDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Common.Repositories
{
    public interface IFinishedGameRepository
    {
        IEnumerable<FinishedGameDto> GetAll();

        void Save(FinishedGameDto finishedGame);
    }
}
