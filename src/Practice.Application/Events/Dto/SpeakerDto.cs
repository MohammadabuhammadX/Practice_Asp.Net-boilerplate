using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace Practice.Events.Dto
{
    [AutoMap(typeof(Speaker))]
    public class SpeakerDto :FullAuditedEntityDto<Guid>, IHasCreationTime
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Bio { get; set; }
    }
}
