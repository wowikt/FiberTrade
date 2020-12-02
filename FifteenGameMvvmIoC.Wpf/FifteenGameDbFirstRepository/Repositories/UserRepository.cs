using FifteenGame.Common.DataDto;
using FifteenGame.Common.Infrastructure;
using FifteenGame.Common.Repositories;
using FifteenGameDbFirstRepository.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGameDbFirstRepository.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserDto Login(string login, string password)
        {
            using (var db = new FifteenGameDbFirstEntities())
            {
                var user = db.Users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
                if (user == null)
                {
                    return null;
                }

                return GameMapper.Instance.Map<UserDto>(user);
            }
        }

        public UserDto Register(string login, string password, string userName)
        {
            using (var db = new FifteenGameDbFirstEntities())
            {
                if (db.Users.Any(u => u.Login == login))
                {
                    return null;
                }

                var newUser = new User
                {
                    UserName = userName,
                    Login = login,
                    Password = password,
                };

                db.Users.Add(newUser);
                db.SaveChanges();
                return GameMapper.Instance.Map<UserDto>(newUser);
            }
        }
    }
}
