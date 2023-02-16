using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;

namespace Teste.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";
        public string Cpf { get; set; }
        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string cpf)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Cpf = cpf,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }

        public static User CriaLeitor(int tenantId, string Nome, string email, string cpf)
        {
            string[] _email = email.Split('@');
            string[] _nome = Nome.Split(' ');
            var user = new User
            {
                TenantId = tenantId,
                UserName = _email[0],
                Name = _nome[0],
                Surname = _nome[1],
                EmailAddress = email,
                Cpf = cpf,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
