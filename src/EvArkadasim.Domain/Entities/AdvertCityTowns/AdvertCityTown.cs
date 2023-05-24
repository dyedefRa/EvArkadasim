using EvArkadasim.Entities.Adverts;
using EvArkadasim.Entities.Cities;
using EvArkadasim.Entities.Towns;
using EvArkadasim.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace EvArkadasim.Entities.AdvertCityTowns
{
    [Table(EvArkadasimConsts.DbTablePrefix + "AdvertCityTowns")]
    public class AdvertCityTown : Entity<int>
    {
        public int AdvertId { get; set; }
        [ForeignKey("AdvertId")]
        [Required]
        public virtual Advert Advert { get; set; }
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        public int? TownId { get; set; }
        [ForeignKey("TownId")]
        public virtual Town Town { get; set; }
        public bool IsRemovedFromUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }
    }
}
