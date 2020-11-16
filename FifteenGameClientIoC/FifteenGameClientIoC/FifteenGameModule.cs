﻿using FifteenGame.Common.Interfaces;
using FifteenGame.ServerProxy.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameClientIoC
{
    class FifteenGameModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameService>().To<GameServerProxy>().InTransientScope();
        }
    }
}
