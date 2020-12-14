using System.Threading.Tasks;
using Abp.Application.Services;
using FifteenGame.Configuration.Dto;

namespace FifteenGame.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}