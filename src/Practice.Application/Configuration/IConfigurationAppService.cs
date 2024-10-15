using System.Threading.Tasks;
using Practice.Configuration.Dto;

namespace Practice.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
