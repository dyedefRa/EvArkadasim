using System.ComponentModel;

namespace EvArkadasim.Enums
{
    //    Kalacak Yer Arıyorum
    //Ev Arkadaşı Arıyorum
    public enum AdvertType
    {
        //Unstated = 0,
        [Description("Evimi Kiralamak İstiyorum")]
        RentMyHome = 1,
        [Description("Odamı Kiralamak İstiyorum")]
        RentMyRoom = 2,
        [Description("Ev Arıyorum")]
        FindHome = 3,
        [Description("Oda Arıyorum")]
        FindRoom = 4,
    }
}
