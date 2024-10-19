using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Events
{
    [Table("AppEventSpeakers")]
    public class EventSpeaker : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        [ForeignKey("Event")]
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }


        [ForeignKey("Speaker")]
        public Guid SpeakerId { get; set; }
        public virtual Speaker Speaker { get; set; }

    }
}
