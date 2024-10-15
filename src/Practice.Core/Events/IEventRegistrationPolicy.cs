using Abp.Domain.Services;
using Practice.Authorization.Users;
using System.Threading.Tasks;

namespace Practice.Events
{
    public interface IEventRegistrationPolicy :IDomainService
    {
        Task CheckRegistrationAttemptAsync(Event @event, User user);
    }
}