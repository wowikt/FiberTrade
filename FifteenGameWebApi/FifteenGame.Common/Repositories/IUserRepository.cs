using FifteenGame.Common.DataDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Common.Repositories
{
    public interface IUserRepository
    {
        UserDto Login(string login, string password);

        UserDto Register(string login, string password, string userName);
    }
}
