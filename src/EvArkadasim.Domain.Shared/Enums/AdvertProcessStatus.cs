using System.ComponentModel;

namespace EvArkadasim.Enums
{
    public enum AdvertProcessStatus
    {
        [Description("Pasif")]
        Passive = -1,
        [Description("Belirtilmemiş")]
        Unstated = 0,
        [Description("Aktif")]
        Active = 1,
        [Description("Beklemede")]
        Waiting = 2,
        [Description("Silinmiş")]
        Deleted = -255
    }
}
