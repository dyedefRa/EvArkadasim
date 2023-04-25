using EvArkadasim.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EvArkadasim.Permissions
{
    public class EvArkadasimPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(EvArkadasimPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(EvArkadasimPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<EvArkadasimResource>(name);
        }
    }
}
