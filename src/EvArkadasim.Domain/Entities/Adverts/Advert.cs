using EvArkadasim.Entities.AdvertCityTowns;
using EvArkadasim.Entities.AdvertFiles;
using EvArkadasim.Entities.AdvertUnitPrices;
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
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExtraDescription { get; set; }
        public string Address { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        [Required]
        public virtual AppUser User { get; set; }
        public AdvertType AdvertType { get; set; }
        public AdvertRankType AdvertRankType { get; set; } /*= AdvertRankType.Default;*/
        public AdvertProcessStatus AdvertProcessStatus { get; set; }
        public AllowGenderType AllowGenderType { get; set; }
        public bool IsPersonNeedHome { get; set; } /*= true;*/
        //Ev eşyalı mı
        public bool IsHomeHaveFurniture { get; set; } /*= true;*/
        //Gösterim sayısı; 
        //localStoragede deger tut 10 dk dursun bu deger varsa tekrardan ekleme.
        public int ImpressionsNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime AdvertValidDate { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<AdvertCityTown> AdvertCityTowns { get; set; }
        public virtual ICollection<AdvertUnitPrice> AdvertUnitPrices { get; set; }
        public virtual ICollection<AdvertFile> AdvertFiles { get; set; }

    }
}
