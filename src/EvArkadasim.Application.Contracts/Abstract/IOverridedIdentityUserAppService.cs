using EvArkadasim.Dtos.Users;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace EvArkadasim.Abstract
{
    public interface IOverridedIdentityUserAppService : IApplicationService
    {
        Task<PagedResultDto<CustomIdentityUserDto>> GetUserListAsync(GetIdentityUsersInput input);
    }
}