using Microsoft.AspNetCore.Authorization;

namespace InventoryByawAstha.Web.Acl
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string PermissionName { get; }
        public PermissionRequirement(string permissionName) => PermissionName = permissionName;
    }
}
