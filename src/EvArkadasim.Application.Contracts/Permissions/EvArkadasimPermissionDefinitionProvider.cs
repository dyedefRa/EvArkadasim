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

            var messagePermission = myGroup.AddPermission(EvArkadasimPermissions.Message.Default, L("MesageManagement"));
            messagePermission.AddChild(EvArkadasimPermissions.Message.See, L("MesageManagementSee"));
            //messagePermission.AddChild(EvArkadasimPermissions.Message.Create, L("Permission:Documents.Create"));
            //messagePermission.AddChild(EvArkadasimPermissions.Message.Edit, L("Permission:Documents.Edit"));
            //messagePermission.AddChild(EvArkadasimPermissions.Message.Delete, L("Permission:Documents.Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<EvArkadasimResource>(name);
        }
    }
}
