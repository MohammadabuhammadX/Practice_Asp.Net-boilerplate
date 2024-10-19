using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Practice.Authorization.Users;
using Practice.Events.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Linq.Extensions;
using System.Threading.Tasks;
using Abp.Authorization;
using Practice.Authorization;

namespace Practice.Events
{
    [AbpAuthorize(PermissionNames.Pages_Events)]
    public class EventAppService : PracticeAppServiceBase, IEventAppService
    {
        private readonly IEventManager _eventManager;
        private readonly IRepository<Event, Guid> _eventRepository;
        private readonly ISpeakerManager _speakerManager;
        //private readonly IRepository<Speaker, Guid> _speakerRepository;
        public EventAppService(IEventManager eventManager, IRepository<Event, Guid> eventRepository, ISpeakerManager speakerManager)
        {
            _eventManager = eventManager;
            _eventRepository = eventRepository;
            _speakerManager = speakerManager;
        }

        public async Task CancelAsync(EntityDto<Guid> input)
        {
            var @event = await _eventManager.GetAsync(input.Id);
            _eventManager.Cancel(@event);
        }

        public async Task CancelRegistrationAsync(EntityDto<Guid> input)
        {
            await _eventManager.CancelRegistrationAsync(
                await _eventManager.GetAsync(input.Id),
                await GetCurrentUserAsync());
        }

        public async Task CreateEventAsync(CreateEventInput input)
        {
            var tenatId = AbpSession.TenantId.Value;
            var @event = Event.
                Create(tenatId, input.Title, input.Date, input.Description, input.MaxRegistrationCount);
            if (input.SpeakerIds != null)
            {
                foreach (var speakerId in input.SpeakerIds)
                {
                    var speaker = await _speakerManager.GetSpeakerAsync(speakerId);
                    @event.AddSpeaker(speaker);
                }
            }
            await _eventManager.CreateAsync(@event);
        }

        public async Task<EventDetailOutput> GetDetailAsync(EntityDto<Guid> input)
        {
            var @event = await _eventRepository.GetAll()
                .Include(e => e.Registrations)
                .ThenInclude(r => r.User)
                .Include(e => e.Speakers)
                .Where(e => e.Id == input.Id)
                .FirstOrDefaultAsync();

            if (@event == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted");
            }
            return @event.MapTo<EventDetailOutput>();
        }

        public async Task<ListResultDto<EventListDto>> GetListAsync(GetEventListInput input)
        {
            var tenatId = AbpSession.TenantId.Value;
            var events = await _eventRepository
            .GetAll()
            .Where(e => e.TenantId == tenatId)
            .Include(e => e.Registrations)
            .Include(e => e.Speakers)
            .WhereIf(!input.IncludeCanceledEvents, e => !e.IsCancelled)
            .OrderByDescending(e => e.CreationTime)
            .Take(64)
            .ToListAsync();
            return new ListResultDto<EventListDto>(events.MapTo<List<EventListDto>>());
        }

        private async Task<EventRegistration> RegisterAndSaveAsync(Event @event, User user)
        {
            var registration = await _eventManager.RegisterAsync(@event, user);
            await CurrentUnitOfWork.SaveChangesAsync();
            return registration;
        }
        public async Task<EventRegisterOutput> RegisterAsync(EntityDto<Guid> input)
        {
            var registration = await RegisterAndSaveAsync(
                await _eventManager.GetAsync(input.Id),
                await GetCurrentUserAsync()
                );

            return new EventRegisterOutput
            {
                RegistrationId = registration.Id
            };
        }



        //public async Task<List<SpeakerDto>> GetSpeakersByEventIdAsync(Guid eventId)
        //{
        //    var speakers = await _speakerManager.GetSpeakersByEventIdAsync(eventId);
        //    return ObjectMapper.Map<List<SpeakerDto>>(speakers);
        //}

        //public async Task AddSpeakerToEventAsync(Guid eventId, Guid speakerId)
        //{

        //    if (!await _speakerManager.CheckIfSpeakerExistsAsync(speakerId))
        //    {
        //        throw new UserFriendlyException("Speaker not found");
        //    }

        //    var @event = await _eventManager.GetAsync(eventId);
        //    @event.AddSpeaker(speakerId);
        //    await _eventRepository.UpdateAsync(@event);
        //}

        //public async Task RemoveSpeakerFromEventAsync(Guid eventId, Guid speakerId)
        //{
        //    var @event = await _eventManager.GetAsync(eventId);
        //    if (!await _speakerManager.CheckIfSpeakerExistsAsync(speakerId))
        //    {
        //        throw new UserFriendlyException("Speaker not found");
        //    }
        //    @event.RemoveSpeaker(speakerId);
        //    await _eventRepository.UpdateAsync(@event);
        //}

        public async Task CreateSpeakerAsync(CreateSpeakerInput input)
        {
            var tenatId = AbpSession.TenantId.Value;

            await _speakerManager.CreateAsync(tenatId, input.Name, input.Bio);
        }

        public Task UpdateSpeakerAsync(UpdateSpeakerInput input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSpeakerAsync(EntityDto<Guid> input)
        {
            throw new NotImplementedException();
        }

        public Task<SpeakerDto> GetSpeakerAsync(EntityDto<Guid> input)
        {
            throw new NotImplementedException();
        }

        public async Task<ListResultDto<SpeakerDto>> GetAllSpeakersAsync()
        {
            var tenatId = AbpSession.TenantId.Value;

            //var speakers = await _speakerManager.GetAllSpeakersAsync();
            //return new ListResultDto<SpeakerDto>(speakers.MapTo<List<SpeakerDto>>());
            var speakers = await _speakerManager.GetAllSpeakersAsync(tenatId);
            return new ListResultDto<SpeakerDto>(ObjectMapper.Map<List<SpeakerDto>>(speakers));
        }
    }
}
