using System.Threading.Tasks;
using Abp.Application.Services;
using FifteenGame.Sessions.Dto;

namespace FifteenGame.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
