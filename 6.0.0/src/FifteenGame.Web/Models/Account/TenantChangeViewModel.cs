using Abp.AutoMapper;
using FifteenGame.Sessions.Dto;

namespace FifteenGame.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}