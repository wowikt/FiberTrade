using AutoMapper;
using FifteenGame.Common.DataDto;
using FifteenGame.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Business.Infrastructure
{
    public static class MapperConfig
    {
        public static void Config(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserDto, User>();
        }
    }
}
