using EvArkadasim.Entities.Adverts;
using EvArkadasim.Entities.Files;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace EvArkadasim.Entities.AdvertFiles
{
    [Table(EvArkadasimConsts.DbTablePrefix + "AdvertFiles")]
    public class AdvertFile : Entity<int>
    {
        public int AdvertId { get; set; }
        [ForeignKey("AdvertId")]
        public virtual Advert Advert { get; set; }
        public int FileId { get; set; }
        [ForeignKey("FileId")]
        public virtual File File { get; set; }
    }
}
