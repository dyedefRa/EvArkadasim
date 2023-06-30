using EvArkadasim.Entities.Adverts;
using EvArkadasim.Entities.Files;
using Volo.Abp.Domain.Entities;

namespace EvArkadasim.Entities.AdvertFiles
{
    public class AdvertFile : Entity<int>
    {
        public int AdvertId { get; set; }
        public virtual Advert Advert { get; set; }
        public int FileId { get; set; }
        public virtual File File { get; set; }
    }
}
