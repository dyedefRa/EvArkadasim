using System.ComponentModel;

namespace EvArkadasim.Enums
{
    public enum AllowGenderType
    {
        //Unstated = 0,
        [Description("Erkek")]
        Male = 1,
        [Description("Kadın")]
        Female = 2,
        [Description("Herkes")]
        All = 3
    }
}
