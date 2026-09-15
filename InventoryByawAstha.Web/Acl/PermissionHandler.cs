using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace InventoryByawAstha.Web.Acl
{

    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public PermissionHandler(IServiceScopeFactory scopeFactory) => _scopeFactory = scopeFactory;

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var userId = long.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            if (userId == 0) return;

            using var scope = _scopeFactory.CreateScope();
            var permissionService = scope.ServiceProvider.GetRequiredService<IPermissionService>();

            // 1. Check SuperAdmin override
            if (await permissionService.IsSuperAdminAsync(userId))
            {
                context.Succeed(requirement);
                return;
            }

            // 2. Check specific table permission
            if (await permissionService.HasPermissionAsync(userId, requirement.PermissionName))
            {
                context.Succeed(requirement);
            }
        }
    }
}
