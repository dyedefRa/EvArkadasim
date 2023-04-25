using EvArkadasim.Dtos.Users;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EvArkadasim.Abstract
{
    public interface IUserAppService : IApplicationService
    {
        Task<CustomIdentityUserDto> GetUserByIdAsync(Guid userId);
        //Task<AppUserDto> CreateCustomAsync(CreateUpdateAppUserDto input);
    }
}
