using EvArkadasim.Dtos.Users;
using EvArkadasim.Dtos.Users.ViewModels;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EvArkadasim.Abstract
{
    public interface IUserAppService : IApplicationService
    {
        Task<AppUserViewModel> GetUserByIdAsync(Guid userId);
        //Task<CustomIdentityUserDto> GetUserByIdAsync(Guid userId);
        //Task<AppUserDto> CreateCustomAsync(CreateUpdateAppUserDto input);
    }
}
