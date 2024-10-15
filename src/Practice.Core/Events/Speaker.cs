using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Events
{
    [Table("AppSpeakers")]
    public class Speaker :Entity<Guid>
    {
        public virtual string Name { get;protected set; }

        public virtual string Bio { get;protected set; }

        protected Speaker()
        {

        }

        public static Speaker Create(string name, string bio)
        {
            return new Speaker
            {
                Id = Guid.NewGuid(),
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
