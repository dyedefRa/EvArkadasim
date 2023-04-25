using System.ComponentModel;

namespace EvArkadasim.Enums
{
    public enum UploadType
    {
        [Description("wwwroot/uploads/companyfiles/")]
        Company = 1,
        [Description("wwwroot/uploads/organizationfiles/")]
        Organization = 2,
    }
}
