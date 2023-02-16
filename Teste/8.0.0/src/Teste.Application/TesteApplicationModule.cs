using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Teste.Authorization;

namespace Teste
{
    [DependsOn(
        typeof(TesteCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TesteApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TesteAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TesteApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
