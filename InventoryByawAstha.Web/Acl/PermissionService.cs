using InventoryByawAstha.DAL.Data;

namespace InventoryByawAstha.Web.Acl
{
    public class PermissionService : IPermissionService
    {
        private InventoryByawAsthaDbContext _dbContext;
        public PermissionService(InventoryByawAsthaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<bool> HasPermissionAsync(long userId, string permissionName)
        {
            var permission = _dbContext.UserPermissions.FirstOrDefault(p => p.UserId == userId && p.PermissionName == permissionName);
            if(permission != null)
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> IsSuperAdminAsync(long userId)
        {
           var user = _dbContext.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                return Task.FromResult(user.UserRole== "Admin");
            }
            return Task.FromResult(false);
        }
    }
}
