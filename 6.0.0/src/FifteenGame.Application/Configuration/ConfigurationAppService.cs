using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using FifteenGame.Configuration.Dto;

namespace FifteenGame.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FifteenGameAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
