using EvArkadasim.Dtos.Users.ViewModels;
using EvArkadasim.Models.Pages.Account;
using EvArkadasim.Models.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EvArkadasim.Abstract
{
    public interface IUserAppService : IApplicationService
    {
        Task<IDataResult<AppUserViewModel>> GetAppUserAsync(Guid userId);
        Task<IDataResult<string>> ChangeProfileImageAsync(Guid userId, IFormFile image);
        Task<IDataResult<string>> ManageProfileAsync(Guid userId, ManageProfileModel input);
        //Task<CustomIdentityUserDto> GetUserByIdAsync(Guid userId);
        //Task<AppUserDto> CreateCustomAsync(CreateUpdateAppUserDto input);
    }
}
