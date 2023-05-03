using EvArkadasim.Abstract;
using EvArkadasim.Dtos.Users;
using EvArkadasim.Dtos.Users.ViewModels;
using EvArkadasim.Enums;
using EvArkadasim.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Web.Pages.Identity;
using Volo.Abp.ObjectMapping;
using static EvArkadasim.Web.Pages.Account.RegisterModel;

namespace EvArkadasim.Web.Pages.Account
{
    [AutoValidateAntiforgeryToken]
    public class ManageModel : IdentityPageModel
    {
        [BindProperty]
        public UserManageModel UserManageInputModel { get; set; }

        private readonly IIdentityUserAppService _identityUserAppService;
        private readonly IUserAppService _userAppService;

        public ManageModel(
            IIdentityUserAppService identityUserAppService,
            IUserAppService userAppService)
        {
            _identityUserAppService = identityUserAppService;
            _userAppService = userAppService;
        }

        public async Task OnGetAsync()
        {
            if (!CurrentUser.IsAuthenticated)
            {
                throw new UserFriendlyException("Kullanıcı bulunamadı.");

            }
            else
            {
                //UserManageInputModel = new UserManageModel();

                var currentUser = await _userAppService.GetUserByIdAsync(CurrentUser.Id.Value);
                UserManageInputModel = ObjectMapper.Map<AppUserViewModel, UserManageModel>(currentUser);

            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();
            //var user = await UserManager.FindByIdAsync(CurrentUser.Id.Value.ToString());
            //var result = await UserManager.ChangePasswordAsync(user, FormModel.CurrentPassword, FormModel.NewPassword);
            //if (!result.Succeeded)
            //{
            //    Alerts.Warning("Şifreniz değiştirilemedi. Lütfen daha sonra tekrar deneyiniz.");
            //    return Page();
            //}
            return Redirect("/");
        }

        public class UserManageModel
        {
            public string UserName { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Surname { get; set; }
            [Required]
            [EmailAddress]
            //[RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
            public string Email { get; set; }
            [Required]
            [Phone]
            [StringLength(16, MinimumLength = 16, ErrorMessage = "Telefon alanı geçerli bir telefon numarası olmalıdır.")]
            public string PhoneNumber { get; set; }
            public GenderType Gender { get; set; }
            //[Required]
            public DateTime? BirthDate { get; set; }

            public int? ImageId { get; set; }
            public string ImageUrl { get; set; }

        }
    }
}
