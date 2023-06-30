using EvArkadasim.Entities.AdvertCityTowns;
using EvArkadasim.Entities.Towns;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace EvArkadasim.Entities.Cities
{
    public class City : Entity<int>
    {
        public string Title { get; set; }
        public int CityNo { get; set; }
        public string AreaNumber { get; set; }
        public virtual ICollection<Town> Towns { get; set; }
        public virtual ICollection<AdvertCityTown> AdvertCityTowns { get; set; }

    }
}
