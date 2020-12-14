using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FifteenGame.Roles.Dto;
using FifteenGame.Users.Dto;

namespace FifteenGame.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}