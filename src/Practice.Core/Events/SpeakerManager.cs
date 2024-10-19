using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Events
{
    public class SpeakerManager : ISpeakerManager
    {
        private readonly IRepository<Speaker, Guid> _speakerRepository;
        private readonly IRepository<Event, Guid> _eventRepository;

        public SpeakerManager(IRepository<Speaker, Guid> speakerRepository, IRepository<Event, Guid> eventRepository)
        {
            _speakerRepository = speakerRepository;
            _eventRepository = eventRepository;
        }

        public async Task<bool> CheckIfSpeakerExistsAsync(Guid id)
        {
            return await _speakerRepository.GetAll().AnyAsync(x => x.Id == id);
        }

        public async Task<Speaker> CreateAsync(int tenatId, string name, string bio)
        {
            var speaker = Speaker.Create(tenatId, name, bio);
            await _speakerRepository.InsertAsync(speaker);
            return speaker;
        }

        public async Task DeleteSpeakerAsync(Guid id)
        {
            var speaker = await _speakerRepository.GetAsync(id);
            await _speakerRepository.DeleteAsync(speaker);
        }

        public async Task<List<Speaker>> GetAllSpeakersAsync(int tenatId)
        {
            return await _speakerRepository
                .GetAll()
                .Where(e => e.TenantId == tenatId)
                .ToListAsync();
        }

        public async Task<Speaker> GetSpeakerAsync(Guid id)
        {
            return await _speakerRepository.GetAsync(id);
        }

        public async Task<List<Speaker>> GetSpeakersByEventIdAsync(Guid eventId)
        {
            var eventEntity = await _eventRepository.GetAllIncluding(e => e.Speakers)
                .FirstOrDefaultAsync(e => e.Id == eventId);

            if (eventEntity == null)
            {
                throw new UserFriendlyException("Event not found.");
            }

            return eventEntity.Speakers.ToList();
        }

        public async Task<Speaker> UpdateSpeakerAsync(Guid id, string name, string bio)
        {
            var speaker = await _speakerRepository.GetAsync(id);

            if (speaker == null) { throw new UserFriendlyException("Speaker not found"); }

            speaker.Update(name, bio);
            await _speakerRepository.UpdateAsync(speaker);
            return speaker;
        }
    }
}
