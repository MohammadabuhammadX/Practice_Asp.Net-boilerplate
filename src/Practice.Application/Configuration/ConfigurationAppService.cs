using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Practice.Configuration.Dto;

namespace Practice.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : PracticeAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
