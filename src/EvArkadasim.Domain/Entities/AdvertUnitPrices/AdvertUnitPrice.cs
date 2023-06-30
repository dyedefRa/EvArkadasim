using EvArkadasim.Entities.Adverts;
using EvArkadasim.Enums;
using System;
using Volo.Abp.Domain.Entities;

namespace EvArkadasim.Entities.AdvertUnitPrices
{
    public class AdvertUnitPrice : Entity<int>
    {
        //Aylık fiyatı bu  , Gunluk bu 
        //Saatlşk bu  (Odanın yada evin)
        public int AdvertId { get; set; }
        public virtual Advert Advert { get; set; }
        public AdvertUnitType AdvertUnitType { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }

    }
}
