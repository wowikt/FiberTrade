﻿using AutoMapper;
using FifteenGame.Common.DataDto;
using FifteenGameDbFirstRepository.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameDbFirstRepository.Infrastructure
{
    public static class MapperConfig
    {
        public static void Config(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, UserDto>()
                .ForMember("Login", opt => opt.Ignore())
                .ForMember("Password", opt => opt.Ignore());
            cfg.CreateMap<UserDto, User>();
            cfg.CreateMap<FinishedGameDto, FinishedGame>();
            cfg.CreateMap<FinishedGame, FinishedGameDto>();
        }
    }
}
