using Volo.Abp.Identity.Settings;
using Volo.Abp.Settings;

namespace EvArkadasim.Settings
{
    public class EvArkadasimSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(EvArkadasimSettings.MySetting1));

            //IDENTITY OPTIONS OVERRIDE 2-2
            context.Add(new SettingDefinition(IdentitySettingNames.Password.RequiredLength, EvArkadasimSettings.IdentityOptions.RequiredLength.ToString()));
            context.Add(new SettingDefinition(IdentitySettingNames.Password.RequireNonAlphanumeric, EvArkadasimSettings.IdentityOptions.RequireNonAlphanumeric.ToString()));
            context.Add(new SettingDefinition(IdentitySettingNames.Password.RequireLowercase, EvArkadasimSettings.IdentityOptions.RequireLowercase.ToString()));
            context.Add(new SettingDefinition(IdentitySettingNames.Password.RequireUppercase, EvArkadasimSettings.IdentityOptions.RequireUppercase.ToString()));
            context.Add(new SettingDefinition(IdentitySettingNames.Password.RequireDigit, EvArkadasimSettings.IdentityOptions.RequireDigit.ToString()));
            context.Add(new SettingDefinition(IdentitySettingNames.Password.RequiredUniqueChars, EvArkadasimSettings.IdentityOptions.RequiredUniqueChars.ToString()));

        }
    }
}
