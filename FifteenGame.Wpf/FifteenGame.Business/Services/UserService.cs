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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(string login, string password)
        {
            var userDto = _userRepository.Login(login, password);
            if (userDto == null)
            {
                return null;
            }

            return GameMapper.Instance.Map<User>(userDto);
        }

        public User Register(string login, string password, string userName)
        {
            var userDto = _userRepository.Register(login, password, userName);
            if (userDto == null)
            {
                return null;
            }

            return GameMapper.Instance.Map<User>(userDto);
        }
    }
}
