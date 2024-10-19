using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Events
{
    [Table("AppSpeakers")]
    public class Speaker :Entity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        public virtual string Name { get;protected set; }

        public virtual string Bio { get;protected set; }

        public virtual ICollection<Event>  Events{ get; set; }

        protected Speaker()
        {

        }

        public static Speaker Create(int tenantId, string name, string bio)
        {
            return new Speaker
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Name = name,
                Bio = bio
            };
        }
        public void Update(string name , string bio)
        {
            Name = name;
            Bio = bio;
        }
    }
}
