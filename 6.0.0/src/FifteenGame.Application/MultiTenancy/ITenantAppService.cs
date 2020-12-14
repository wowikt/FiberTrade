using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FifteenGame.MultiTenancy.Dto;

namespace FifteenGame.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
