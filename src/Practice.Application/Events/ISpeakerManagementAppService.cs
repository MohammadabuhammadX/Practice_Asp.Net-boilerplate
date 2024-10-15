using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Practice.Events.Dto;
using System;
using System.Threading.Tasks;

namespace Practice.Events
{
    public interface ISpeakerManagementAppService : IApplicationService
    {
        Task<SpeakerDto> CreateSpeakerAsync(CreateSpeakerInput input);
        Task<SpeakerDto> UpdateSpeakerAsync(UpdateSpeakerInput input);
        Task DeleteSpeakerAsync(EntityDto<Guid> input);
        Task<SpeakerDto> GetSpeakerAsync(EntityDto<Guid> input);
        Task<ListResultDto<SpeakerDto>> GetAllSpeakersAsync();

    }
}