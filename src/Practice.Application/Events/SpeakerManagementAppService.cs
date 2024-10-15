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

namespace Practice.Events
{
    public class SpeakerManagementAppService : PracticeAppServiceBase, ISpeakerManagementAppService
    {
        private readonly ISpeakerManager _speakerManager;

        public SpeakerManagementAppService(ISpeakerManager speakerManager)
        {
            _speakerManager = speakerManager;
        }

        public async Task<SpeakerDto> CreateSpeakerAsync(CreateSpeakerInput input)
        {
            var speaker = await _speakerManager.CreateSpeakerAsync(input.Name, input.Bio);
            return ObjectMapper.Map<SpeakerDto>(speaker);
        }

        public async Task<SpeakerDto> UpdateSpeakerAsync(UpdateSpeakerInput input)
        {
            var speakerExists = await _speakerManager.CheckIfSpeakerExistsAsync(input.Id);
            if (!speakerExists)
            {
                throw new UserFriendlyException("Speaker not found");
            }

            var speaker = await _speakerManager.UpdateSpeakerAsync(input.Id, input.Name, input.Bio);
            return ObjectMapper.Map<SpeakerDto>(speaker);
        }

        public async Task DeleteSpeakerAsync(EntityDto<Guid> input)
        {
            await _speakerManager.DeleteSpeakerAsync(input.Id);
        }

        public async Task<SpeakerDto> GetSpeakerAsync(EntityDto<Guid> input)
        {
            var speaker = await _speakerManager.GetSpeakerAsync(input.Id);
            return ObjectMapper.Map<SpeakerDto>(speaker);
        }

        public async Task<ListResultDto<SpeakerDto>> GetAllSpeakersAsync()
        {
            var speakers = await _speakerManager.GetAllSpeakersAsync();
            return new ListResultDto<SpeakerDto>(ObjectMapper.Map<List<SpeakerDto>>(speakers));
        }
    }
}
