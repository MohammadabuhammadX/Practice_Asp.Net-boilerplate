using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Practice.Events;

namespace Practice.Events
{
    public interface ISpeakerManager : IDomainService
    {
        Task<Speaker> CreateSpeakerAsync(string name, string bio);
        Task<Speaker> UpdateSpeakerAsync(Guid id, string name, string bio);
        Task DeleteSpeakerAsync(Guid id);
        Task<Speaker> GetSpeakerAsync(Guid id);
        Task<List<Speaker>> GetAllSpeakersAsync();
        Task<List<Speaker>> GetSpeakersByEventIdAsync(Guid eventId);
        Task<bool> CheckIfSpeakerExistsAsync(Guid id);
    }
}
