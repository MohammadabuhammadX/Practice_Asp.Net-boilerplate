using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace Practice.Events.Dto
{
    [AutoMapTo(typeof(Speaker))]
    public class UpdateSpeakerInput :EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Bio { get; set; }

    }
}
