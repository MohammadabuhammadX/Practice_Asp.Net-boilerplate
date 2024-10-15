using System.Threading.Tasks;
using Abp.Application.Services;
using Practice.Authorization.Accounts.Dto;

namespace Practice.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
