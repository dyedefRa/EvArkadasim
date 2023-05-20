using AutoMapper;
using EvArkadasim.Dtos.Files;
using EvArkadasim.Dtos.MessageContents;
using EvArkadasim.Dtos.MessageContents.ViewModels;
using EvArkadasim.Dtos.Messages;
using EvArkadasim.Dtos.Messages.ViewModels;
using EvArkadasim.Dtos.Users;
using EvArkadasim.Dtos.Users.ViewModels;
using EvArkadasim.Entities.Files;
using EvArkadasim.Entities.MessageContents;
using EvArkadasim.Entities.Messages;
using EvArkadasim.Entities.Users;
using System.Collections.Generic;
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
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            #endregion


            #region Message
            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<Message, MessageViewModel>().ReverseMap();              //MessageAppService > GetUserMessageListAsync

            #endregion

            #region MessageContent 
            CreateMap<MessageContent, MessageContentDto>().ReverseMap();
            CreateMap<MessageContent, MessageContentViewModel>().ReverseMap(); //MessageAppService > GetUserMessageWithContentListAsync
            CreateMap<CreateUpdateMessageContentDto, MessageContent>();        //MessageAppService > InsertMessageContentAsync
            #endregion

            #region File

            CreateMap<File, FileDto>().ReverseMap();//FileAppService > SaveFileAsync

            #endregion
        }
    }
}
