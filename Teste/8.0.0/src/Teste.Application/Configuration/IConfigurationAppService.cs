using System.Threading.Tasks;
using Teste.Configuration.Dto;

namespace Teste.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
