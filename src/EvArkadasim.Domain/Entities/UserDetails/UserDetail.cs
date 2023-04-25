//using EvArkadasim.Entities.Users;
//using System.ComponentModel.DataAnnotations;
//using System;
//using System.ComponentModel.DataAnnotations.Schema;
//using Volo.Abp.Domain.Entities;
//using EvArkadasim.Entities.Cities;
//using EvArkadasim.Entities.Towns;
//using EvArkadasim.Enums;

//namespace EvArkadasim.Entities.UserDetails
//{
//    [Table(EvArkadasimConsts.DbTablePrefix + "UserDetails")]
//    public class UserDetail : Entity<int>
//    {
//        public string About { get; set; }
//        public Guid UserId { get; set; }
//        [ForeignKey("UserId")]
//        [Required]
//        public virtual AppUser User { get; set; }
//        public int? CityId { get; set; }
//        [ForeignKey("CityId")]
//        public virtual City City { get; set; }
//        public int? TownId { get; set; }
//        [ForeignKey("TownId")]
//        public virtual Town Town { get; set; }
//        public DateTime CreatedDate { get; set; }
//        public Status Status { get; set; }
//    }
//}
