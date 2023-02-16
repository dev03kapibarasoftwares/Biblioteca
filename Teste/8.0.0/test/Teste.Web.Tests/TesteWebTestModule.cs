using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Teste.EntityFrameworkCore;
using Teste.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Teste.Web.Tests
{
    [DependsOn(
        typeof(TesteWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class TesteWebTestModule : AbpModule
    {
        public TesteWebTestModule(TesteEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TesteWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(TesteWebMvcModule).Assembly);
        }
    }
}