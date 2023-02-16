using Abp.Authorization;
using Teste.Authorization.Roles;
using Teste.Authorization.Users;

namespace Teste.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
