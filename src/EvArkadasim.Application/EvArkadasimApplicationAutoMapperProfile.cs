using AutoMapper;
using EvArkadasim.Dtos.Users.ViewModels;
using EvArkadasim.Entities.Users;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;

namespace EvArkadasim
{
    public class EvArkadasimApplicationAutoMapperProfile : Profile
    {
        public EvArkadasimApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<AppUser, AppUserViewModel>();//UserAppService > GetUserByIdAsync


        }
    }
}
