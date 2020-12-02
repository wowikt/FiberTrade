using FifteenGame.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Common.Interfaces
{
    public interface IUserService
    {
        User Login(string login, string password);

        User Register(string login, string password, string userName);
    }
}
