using FifteenGame.Common.DataDto;
using FifteenGame.Common.Infrastructure;
using FifteenGame.Common.Interfaces;
using FifteenGame.Common.Models;
using FifteenGame.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Business.Services
{
    public class FinishedGameService : IFinishedGameService
    {
        private readonly IFinishedGameRepository _finishedGameRepository;

        public FinishedGameService(IFinishedGameRepository finishedGameRepository)
        {
            _finishedGameRepository = finishedGameRepository;
        }

        public void Create(FinishedGame finishedGame)
        {
            _finishedGameRepository.Save(GameMapper.Instance.Map<FinishedGameDto>(finishedGame));
        }

        public IEnumerable<FinishedGame> GetAll()
        {
            return GameMapper.Instance.Map<IEnumerable<FinishedGame>>(_finishedGameRepository.GetAll());
        }
    }
}
