using EvArkadasim.Dtos.Users.ViewModels;
using EvArkadasim.Models.Results.Abstract;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EvArkadasim.Abstract
{
    public interface IUserAppService : IApplicationService
    {
        Task<IDataResult<AppUserViewModel>> GetAppUserAsync(Guid userId);
        //Task<CustomIdentityUserDto> GetUserByIdAsync(Guid userId);
        //Task<AppUserDto> CreateCustomAsync(CreateUpdateAppUserDto input);
    }
}
