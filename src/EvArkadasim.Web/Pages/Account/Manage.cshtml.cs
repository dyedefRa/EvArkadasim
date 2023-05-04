using EvArkadasim.Abstract;
using EvArkadasim.Dtos.Users.ViewModels;
using EvArkadasim.Enums;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Web.Pages.Identity;

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
            IUserAppService userAppService
            )
        {
            _identityUserAppService = identityUserAppService;
            _userAppService = userAppService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                if (!CurrentUser.IsAuthenticated)
                    return Redirect("~/Error?httpStatusCode=401");

                var currentUser = await _userAppService.GetAppUserAsync(CurrentUser.Id.Value);
                UserManageInputModel = ObjectMapper.Map<AppUserViewModel, UserManageModel>(currentUser.Data);
                return Page();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Account > Manage > OnGetAsync  has error!");
                Alerts.Danger(L["GeneralIdentityError"].Value);

                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var currentUser = await _identityUserAppService.GetAsync(CurrentUser.Id.Value);
                    var updateDto = ObjectMapper.Map<IdentityUserDto, IdentityUserUpdateDto>(currentUser);
                    updateDto.Name = UserManageInputModel.Name;
                    updateDto.Surname = UserManageInputModel.Surname;
                    updateDto.Email = UserManageInputModel.Email;
                    updateDto.PhoneNumber = UserManageInputModel.PhoneNumber;
                    updateDto.ExtraProperties.Remove("BirthDate");
                    updateDto.ExtraProperties.Add("BirthDate", UserManageInputModel.BirthDate);

                    await _identityUserAppService.UpdateAsync(UserManageInputModel.Id, updateDto);

                    return RedirectToAction("Manage", "Account");
                }

                Alerts.Danger(L["GeneralIdentityError"].Value);

                return Page();

            }
            catch (AbpIdentityResultException ex)
            {
                var identityError = ex.IdentityResult;
                if (!identityError.Succeeded && identityError.Errors.Any())
                {
                    var totalErrorCount = identityError.Errors.Count();
                    if (identityError.Errors.Any(x => x.Code == "DuplicateUserName"))
                    {
                        Alerts.Danger($"'{UserManageInputModel.UserName}' kullanıcı adına sahip bir kullanıcı zaten var.");
                        totalErrorCount--;
                    }

                    if (identityError.Errors.Any(x => x.Code == "DuplicateEmail"))
                    {
                        Alerts.Danger($"'{UserManageInputModel.Email}' mailine sahip bir kullanıcı zaten var.");
                        totalErrorCount--;
                    }

                    if (totalErrorCount > 0)
                    {
                        Alerts.Danger(L["GeneralIdentityError"].Value);
                    }
                }

                return Page();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "CompanyRegisterModel > OnPostAsync has error! ");
                Alerts.Danger(L["GeneralIdentityError"].Value);

                return Page();
            }
        }

        public class UserManageModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
            [DisabledInput]
            public string UserName { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Surname { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [Phone]
            [StringLength(16, MinimumLength = 16, ErrorMessage = "Telefon alanı geçerli bir telefon numarası olmalıdır.")]
            public string PhoneNumber { get; set; }
            public DateTime CreationTime { get; set; }
            [DisabledInput]
            public GenderType Gender { get; set; }
            //[Required]
            public DateTime? BirthDate { get; set; }

            public int? ImageId { get; set; }
            public string ImageUrl { get; set; }

        }
    }
}
