using EvArkadasim.Abstract;
using EvArkadasim.Dtos.Users;
using EvArkadasim.Dtos.Users.ViewModels;
using EvArkadasim.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace EvArkadasim.Services
{
    public class UserAppService : CrudAppService<AppUser, AppUserDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateAppUserDto>, IUserAppService
    {
        protected IIdentityUserAppService _identityUserAppService { get; }
        private IdentityUserManager _identityUserManager { get; set; }
        private readonly IRepository<AppUser> _appUserRepository;

        public UserAppService(
            IRepository<AppUser, Guid> repository,
            IIdentityUserAppService identityUserAppService,
            IdentityUserManager identityUserManager,
             IRepository<AppUser> appUserRepository
            ) : base(repository)
        {
            _identityUserManager = identityUserManager;
            _identityUserAppService = identityUserAppService;
            _appUserRepository = appUserRepository;
        }


        //TODOO 
        //public async Task<bool> IsSafe(Guid userId)
        //{
        //    if (!CurrentUser.IsAuthenticated)
        //    {
        //        return false;
        //    }

        //    if (CurrentUser.Roles.Any(x => x == EnumExtensions.GetEnumDescription(UserType.Admin)))
        //    {
        //        return true;
        //    }
        //    if (true)
        //    {

        //    }
        //    CurrentUser.Id.Value
        //}

        [AllowAnonymous]
        public async Task<AppUserViewModel> GetUserByIdAsync(Guid userId)
        {
            var appUser = await _appUserRepository.Include(x => x.Image).FirstOrDefaultAsync(x => x.Id == userId);
            var result = ObjectMapper.Map<AppUser, AppUserViewModel>(appUser);

            result.ImageUrl = appUser?.Image?.FilePath;
            return result;
        }

        //public async Task<AppUserDto> CreateCustomAsync(CreateUpdateAppUserDto input)
        //{
        //    var identityUser = new IdentityUser(GuidGenerator.Create(), input.UserName, input.Email);
        //    identityUser.SetUserType(input.UserType.Value);
        //    identityUser.SetStatus(input.Status.Value);

        //    var identityResult = await _identityUserManager.CreateAsync(identityUser, input.Password);
        //    if (identityResult.Succeeded)
        //    {
        //        await _identityUserManager.SetPhoneNumberAsync(identityUser, input.PhoneNumber);
        //        await _identityUserManager.UpdateAsync(identityUser);

        //        var updateResult = await UpdateAsync(identityUser.Id, input);
        //        return updateResult;
        //    }

        //    return null;
        //}

        //public async Task<CustomIdentityUserDto> CreateUserAsync(Guid userId)
        //{
        //    var identityUser = await _identityUserAppService.CreateAsync(new );
        //    var appUser = await _appUserRepository.Include(x => x.Image).FirstOrDefaultAsync(x => x.Id == userId);
        //    var result = ObjectMapper.Map<Volo.Abp.Identity.IdentityUserDto, CustomIdentityUserDto>(identityUser);
        //    result.ImageUrl = appUser?.Image?.FilePath;
        //    result.ImageId = appUser?.ImageId;
        //    result.UserType = appUser.UserType;
        //    result.Status = appUser.Status;
        //    return result;
        //}


        //public async Task<PagedResultDto<UserListViewModel>> GetUserListByUserName(GetUserListByUserNameViewModel model)
        //{

        //    var searchWord = model.UserName?.ToLowerInvariant();
        //    var roleUsers = (await _userManager.GetUsersInRoleAsync("gamer")).Where(x => x.UserName.ToLowerInvariant().Contains(searchWord)).Select(x => x.Id).ToList();

        //    Guid[] teamUserIds = null;
        //    if (model.TeamUserExcluded ?? false)
        //    {
        //        if (ApiCurrentTeamUser != null)
        //        {
        //            teamUserIds = await _teamUserRepository.Where(x => x.TeamUserStatus == Enums.TeamUser.TeamUserStatus.Active).Select(x => x.UserId).ToArrayAsync();
        //        }
        //    }
        //    var result = new PagedResultDto<UserListViewModel>();
        //    var query = _appUserRepository.Where(x => roleUsers.Contains(x.Id) && !x.IsDeleted).AsQueryable();

        //    query = query
        //        .WhereIf(!string.IsNullOrEmpty(searchWord), x => roleUsers.Contains(x.Id))
        //        .WhereIf(model.TeamUserExcluded ?? false && teamUserIds != null, x => !teamUserIds.Contains(x.Id));

        //    var totalCount = await query.CountAsync();

        //    query = query.Skip(model.SkipCount).Take(model.MaxResultCount);
        //    query = query.OrderBy(x => x.UserName);
        //    var queryResult = await AsyncExecuter.ToListAsync(query);

        //    var dtos = queryResult
        //      .Select(x => new UserListViewModel
        //      {
        //          Id = x.Id,
        //          ImageId = x.ImageId,
        //          UserName = x.UserName
        //      })
        //      .ToList();

        //    result.Items = dtos;
        //    result.TotalCount = totalCount;


        //    return result;
        //}


        //[AllowAnonymous]
        //public async Task<List<Claim>> SetTokenValue(string userName, string password)
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var request = new HttpRequestMessage(new HttpMethod("POST"), ApiUrl + "/api/Users/LoginOnlyToken"))
        //        {
        //            request.Headers.TryAddWithoutValidation("Accept-Language", "tr");
        //            var userLoginModel = new UserLoginModel { Name = userName, Password = password };
        //            var content = Newtonsoft.Json.JsonConvert.SerializeObject(userLoginModel);

        //            request.Content = new StringContent(content);
        //            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

        //            var response = await httpClient.SendAsync(request);
        //            var responseString = await response.Content.ReadAsStringAsync();
        //            if (!string.IsNullOrEmpty(responseString) && response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                return new List<Claim>() { new Claim(LFGNerfitConsts.DEFAULT.ChatTokenClaimName, responseString) };
        //            }
        //            else
        //            {
        //                return new List<Claim>();
        //            }

        //        }
        //    }
        //}




        //public async Task<List<UserSelectViewModelWithLeader>> GetUserSelectListByTeamIdAsync(Guid Id)
        //{
        //    try
        //    {
        //        var query = _appUserRepository.AsQueryable();

        //        query = query.Include(x => x.TeamUsers);
        //        var queryResult = await AsyncExecuter.ToListAsync(query);

        //        var dtos = queryResult.Select(x =>
        //        {
        //            UserSelectViewModelWithLeader userSelect = new UserSelectViewModelWithLeader();
        //            userSelect.Id = x.Id;
        //            userSelect.Name = StringHelper.GetUserDisplayFullName(x.Name, x.Surname, x.UserName);
        //            userSelect.IsSelected = x.TeamUsers.Any(y => y.TeamId == Id && y.TeamUserStatus == Enums.TeamUser.TeamUserStatus.Active);
        //            var isLeader = x.TeamUsers.Any(y => y.TeamId == Id && y.TeamUserStatus == Enums.TeamUser.TeamUserStatus.Active && y.IsLeader == true);
        //            if (isLeader)
        //                userSelect.IsLeader = true;
        //            else
        //                userSelect.IsLeader = false;
        //            return userSelect;
        //        })
        //        .OrderByDescending(x => x.IsSelected).ToList();

        //        return dtos;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "UserAppService > GetUserSelectListByTeamIdAsync has error!");
        //        return null;
        //    }
        //}


        //public async Task<List<UserSelectViewModelWithApprove>> GetUserSelectListByTournamentIdAsync(Guid Id)
        //{
        //    try
        //    {
        //        var query = _appUserRepository.AsQueryable();

        //        query = query.Include(x => x.TournamentUsers);
        //        var queryResult = await AsyncExecuter.ToListAsync(query);

        //        var dtos = queryResult.Select(x =>
        //        {
        //            UserSelectViewModelWithApprove userSelect = new UserSelectViewModelWithApprove();
        //            userSelect.Id = x.Id;
        //            userSelect.Name = StringHelper.GetUserDisplayFullName(x.Name, x.Surname, x.UserName);
        //            userSelect.IsSelected = x.TournamentUsers.Any(y => y.TournamentId == Id && y.Status == Status.Active);
        //            var related = x.TournamentUsers.FirstOrDefault(y => y.TournamentId == Id);
        //            if (related != null)
        //                userSelect.IsApproved = related.IsApproved;
        //            else
        //                userSelect.IsApproved = false;
        //            return userSelect;
        //        })
        //        .OrderByDescending(x => x.IsSelected).ToList();

        //        return dtos;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "UserAppService > GetUserSelectListByTournamnentIdAsync has error!");
        //        return null;
        //    }
        //}


        //public async Task<List<UserSelectViewModel>> GetRefereeSelectListByTournamentIdAsync(Guid Id)
        //{
        //    try
        //    {
        //        var query = _appUserRepository.AsQueryable();

        //        query = query.Include(x => x.TournamentReferees);
        //        var queryResult = await AsyncExecuter.ToListAsync(query);

        //        var dtos = queryResult.Select(x =>
        //        {
        //            UserSelectViewModel userSelect = new UserSelectViewModel();
        //            userSelect.Id = x.Id;
        //            userSelect.Name = StringHelper.GetUserDisplayFullName(x.Name, x.Surname, x.UserName);
        //            userSelect.IsSelected = x.TournamentReferees.Any(y => y.TournamentId == Id && y.Status == Status.Active);
        //            return userSelect;
        //        })
        //        .OrderByDescending(x => x.IsSelected).ToList();

        //        return dtos;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "UserAppService > GetRefereeSelectListByTournamentIdAsync has error!");
        //        return null;
        //    }
        //}





    }
}
