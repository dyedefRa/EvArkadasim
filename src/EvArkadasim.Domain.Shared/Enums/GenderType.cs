using System.ComponentModel;

namespace EvArkadasim.Enums
{
    public enum GenderType
    {
        [Description("Erkek")]
        Male = 1,
        [Description("Kadın")]
        Female = 2,
        //[Description("Belirtmek İstemiyorum")]
        //DoNotWantSpecify = 3
    }
}
