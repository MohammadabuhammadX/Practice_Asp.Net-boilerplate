﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Events.Dto
{
    [AutoMapFrom(typeof(Event))]
    public class EventListDto: FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsCancelled { get; set; }
        public virtual int MaxRegistrationCount { get; protected set; }
        public int RegistrationsCount { get; set; }
        public ICollection<SpeakerDto> Speakers { get; set; } //add
    }
}
