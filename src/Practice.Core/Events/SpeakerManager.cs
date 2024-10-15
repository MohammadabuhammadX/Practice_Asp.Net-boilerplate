using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practice.Events
{
    public class SpeakerManager : ISpeakerManager
    {
        private readonly IRepository<Speaker, Guid> _speakerRepository;

        public SpeakerManager(IRepository<Speaker, Guid> speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }

        public async Task<bool> CheckIfSpeakerExistsAsync(Guid id)
        {
            return await _speakerRepository.GetAll().AnyAsync(x=>x.Id == id);
        }

        public async Task<Speaker> CreateSpeakerAsync(string name, string bio)
        {
            var speaker =Speaker.Create(name,bio);
            await _speakerRepository.InsertAsync(speaker);
            return speaker;
        }

        public async Task DeleteSpeakerAsync(Guid id)
        {
            var speaker = await _speakerRepository.GetAsync(id);
            await _speakerRepository.DeleteAsync(speaker);
        }

        public async Task<List<Speaker>> GetAllSpeakersAsync()
        {
            return await _speakerRepository.GetAllListAsync();
        }

        public async Task<Speaker> GetSpeakerAsync(Guid id)
        {
            return await _speakerRepository.GetAsync(id);
        }

        public Task<List<Speaker>> GetSpeakersByEventIdAsync(Guid eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<Speaker> UpdateSpeakerAsync(Guid id, string name, string bio)
        {
            var speaker = await _speakerRepository.GetAsync(id);

            if(speaker == null) { throw new UserFriendlyException("Speaker not found"); }

            speaker.Update(name, bio);
            await _speakerRepository.UpdateAsync(speaker);
            return speaker;
        }
    }
}
