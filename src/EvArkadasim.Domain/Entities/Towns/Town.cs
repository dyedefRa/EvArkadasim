using EvArkadasim.Entities.AdvertCityTowns;
using EvArkadasim.Entities.Cities;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace EvArkadasim.Entities.Towns
{
    public class Town : Entity<int>
    {
        public string Title { get; set; }
        public int TownNo { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<AdvertCityTown> AdvertCityTowns { get; set; }

    }
}
