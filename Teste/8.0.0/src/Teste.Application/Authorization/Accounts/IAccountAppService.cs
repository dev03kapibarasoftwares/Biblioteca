using System.Threading.Tasks;
using Abp.Application.Services;
using Teste.Authorization.Accounts.Dto;

namespace Teste.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
