using Abp.Application.Services;
using Teste.MultiTenancy.Dto;

namespace Teste.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

