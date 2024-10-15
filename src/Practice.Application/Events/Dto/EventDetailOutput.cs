using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;

namespace Practice.Events.Dto
{
    [AutoMapFrom(typeof(Event))]
    public class EventDetailOutput : FullAuditedEntityDto<Guid>
    {
        public string Tilte { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsCancelled { get; set; }
        public virtual int MaxRegistrationCount { get; protected set; }
        public int RegistrationCount { get; set; }
        public ICollection<EventRegistrationDto> Registrations { get; set; }
        public ICollection<SpeakerDto> Speakers { get; set; } //add
    }
}
