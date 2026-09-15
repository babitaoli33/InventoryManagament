namespace InventoryByawAstha.Web.Acl
{
    public interface IPermissionService
    {
        Task<bool> IsSuperAdminAsync(long userId);
        Task<bool> HasPermissionAsync(long userId, string permissionName);
    }
}
