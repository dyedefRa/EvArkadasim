using System.ComponentModel;

namespace EvArkadasim.Enums
{
    public enum UserRoleType
    {
        [Description("Belirtilmedi")]
        Unstated = 0,
        [Description("ADMIN")]
        Admin = 1,
        [Description("COMPANY")]
        Company = 2,
        [Description("CUSTOMER")]
        Customer = 2,
    }
}
