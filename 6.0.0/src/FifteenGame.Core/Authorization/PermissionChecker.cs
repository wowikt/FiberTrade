using Abp.Authorization;
using FifteenGame.Authorization.Roles;
using FifteenGame.Authorization.Users;

namespace FifteenGame.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
