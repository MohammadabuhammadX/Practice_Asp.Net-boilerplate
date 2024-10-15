using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Practice.EntityFrameworkCore;
using Practice.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Practice.Web.Tests
{
    [DependsOn(
        typeof(PracticeWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class PracticeWebTestModule : AbpModule
    {
        public PracticeWebTestModule(PracticeEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PracticeWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(PracticeWebMvcModule).Assembly);
        }
    }
}