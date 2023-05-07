using AutoMapper;
using EvArkadasim.Dtos.Files;
using EvArkadasim.Dtos.Users.ViewModels;
using EvArkadasim.Entities.Files;
using EvArkadasim.Entities.Users;
using Volo.Abp.Identity;

namespace EvArkadasim
{
    public class EvArkadasimApplicationAutoMapperProfile : Profile
    {
        public EvArkadasimApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            #region User
            CreateMap<AppUser, AppUserViewModel>();              //UserAppService > GetUserByIdAsync
            CreateMap<IdentityUserDto, IdentityUserUpdateDto>(); //UserAppService > ManageProfileAsync

            #endregion


            #region File

            CreateMap<File, FileDto>().ReverseMap();//FileAppService > SaveFileAsync

            #endregion
        }
    }
}
