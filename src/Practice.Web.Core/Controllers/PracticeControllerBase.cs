using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Practice.Controllers
{
    public abstract class PracticeControllerBase: AbpController
    {
        protected PracticeControllerBase()
        {
            LocalizationSourceName = PracticeConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
