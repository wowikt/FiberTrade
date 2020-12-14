using System.Collections.Generic;
using FifteenGame.Roles.Dto;
using FifteenGame.Users.Dto;

namespace FifteenGame.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}