using System.Threading.Tasks;
using Abp.Application.Services;
using Teste.Sessions.Dto;

namespace Teste.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
