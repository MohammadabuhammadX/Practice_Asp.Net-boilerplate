using Abp.Authorization;
using Practice.Authorization.Roles;
using Practice.Authorization.Users;

namespace Practice.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
