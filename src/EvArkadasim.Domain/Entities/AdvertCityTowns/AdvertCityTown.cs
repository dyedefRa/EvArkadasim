using EvArkadasim.Entities.Adverts;
using EvArkadasim.Entities.Cities;
using EvArkadasim.Entities.Towns;
using EvArkadasim.Enums;
using System;
using Volo.Abp.Domain.Entities;

namespace EvArkadasim.Entities.AdvertCityTowns
{
    public class AdvertCityTown : Entity<int>
    {
        public int AdvertId { get; set; }
        public virtual Advert Advert { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int TownId { get; set; }
        public virtual Town Town { get; set; }
        public bool IsRemovedFromUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }
    }
}
