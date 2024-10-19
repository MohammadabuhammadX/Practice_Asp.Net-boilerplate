using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Practice.Authorization.Roles;
using Practice.Authorization.Users;
using Practice.MultiTenancy;
using Practice.Events;

namespace Practice.EntityFrameworkCore
{
    public class PracticeDbContext : AbpZeroDbContext<Tenant, Role, User, PracticeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<EventRegistration> EventRegistrations { get; set; }
        public virtual DbSet<Speaker> Speakers { get; set; } 

        public PracticeDbContext(DbContextOptions<PracticeDbContext> options)
            : base(options)
        {
        }
    }
}
