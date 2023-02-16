using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Teste.Controllers
{
    public abstract class TesteControllerBase: AbpController
    {
        protected TesteControllerBase()
        {
            LocalizationSourceName = TesteConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
