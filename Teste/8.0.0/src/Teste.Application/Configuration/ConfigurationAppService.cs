using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Teste.Configuration.Dto;

namespace Teste.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TesteAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
