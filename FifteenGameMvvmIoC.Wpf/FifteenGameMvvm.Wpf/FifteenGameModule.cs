﻿using FifteenGame.Business.Services;
using FifteenGame.Common.Interfaces;
using FifteenGame.Common.Repositories;
using FifteenGameCodeFirstRepository.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameMvvm.Wpf
{
    class FifteenGameModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameService>().To<GameService>().InTransientScope();
            Bind<IUserService>().To<UserService>().InSingletonScope();
            Bind<IFinishedGameService>().To<FinishedGameService>().InSingletonScope();

            Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
            Bind<ICurrentGameRepository>().To<CurrentGameRepository>().InSingletonScope();
            Bind<IFinishedGameRepository>().To<FinishedGameRepository>().InSingletonScope();
        }
    }
}
