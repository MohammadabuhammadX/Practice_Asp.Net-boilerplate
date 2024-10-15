using System.Threading.Tasks;
using Abp.Application.Services;
using Practice.Sessions.Dto;

namespace Practice.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
