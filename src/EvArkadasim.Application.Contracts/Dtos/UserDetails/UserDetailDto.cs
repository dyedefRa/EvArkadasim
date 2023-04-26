using EvArkadasim.Dtos.Cities;
using EvArkadasim.Dtos.Towns;
using EvArkadasim.Dtos.Users;
using EvArkadasim.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;

namespace EvArkadasim.Dtos.UserDetails
{
    public class UserDetailDto : EntityDto<int>
    {
        public Guid UserId { get; set; }
        public AppUserDto User { get; set; }
        public string About { get; set; }
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public CityDto City { get; set; }
        public int? TownId { get; set; }
        [ForeignKey("DisrictId")]
        public TownDto Town { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }
    }
}
