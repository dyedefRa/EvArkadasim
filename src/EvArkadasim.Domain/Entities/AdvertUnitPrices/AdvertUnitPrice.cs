using EvArkadasim.Entities.Adverts;
using EvArkadasim.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace EvArkadasim.Entities.AdvertUnitPrices
{
    [Table(EvArkadasimConsts.DbTablePrefix + "AdvertUnitPrices")]
    public class AdvertUnitPrice : Entity<int>
    {
        //Aylık fiyatı bu  , Gunluk bu 
        //Saatlşk bu  (Odanın yada evin)
        public int AdvertId { get; set; }
        [ForeignKey("AdvertId")]
        [Required]
        public virtual Advert Advert { get; set; }
        public AdvertUnitType AdvertUnitType { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }

    }
}
