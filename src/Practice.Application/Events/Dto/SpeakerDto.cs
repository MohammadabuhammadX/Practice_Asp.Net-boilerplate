using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace Practice.Events.Dto
{
    public class SpeakerDto :FullAuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Bio { get; set; }
    }
}
