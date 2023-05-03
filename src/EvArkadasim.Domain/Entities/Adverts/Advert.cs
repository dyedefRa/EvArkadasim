using EvArkadasim.Entities.AdvertFiles;
using EvArkadasim.Entities.Cities;
using EvArkadasim.Entities.Towns;
using EvArkadasim.Entities.Users;
using EvArkadasim.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace EvArkadasim.Entities.Adverts
{
    //ILAN
    //TODO Depozito tutarı ekle.
    [Table(EvArkadasimConsts.DbTablePrefix + "Adverts")]
    public class Advert : Entity<int>
    {
        public AdvertType AdvertType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        [Required]
        public virtual AppUser User { get; set; }
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        public int? TownId { get; set; }
        [ForeignKey("TownId")]
        public virtual Town Town { get; set; }
        public AllowGenderType AllowGenderType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime AdvertValidDate { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<AdvertFile> AdvertFiles { get; set; }

    }
}
