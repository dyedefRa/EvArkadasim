using AutoMapper;
using EvArkadasim.Dtos.Users.ViewModels;
using Volo.Abp.Identity;
using static EvArkadasim.Web.Pages.Account.ManageModel;
using static EvArkadasim.Web.Pages.Account.RegisterModel;

namespace EvArkadasim.Web
{
    public class EvArkadasimWebAutoMapperProfile : Profile
    {
        public EvArkadasimWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.

            #region User
            CreateMap<UserRegisterModel, IdentityUserCreateDto>();//Account/Register

            CreateMap<AppUserViewModel, UserManageModel>(); //Account/Manage/OnGetAsync

            #endregion
        }
    }
}
