using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace InventoryByawAstha.Web.Acl
{
    public class PermissionPolicyProvider : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

        public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            // Fallback to default provider for standard policies or [Authorize] attributes without parameters
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();

        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => FallbackPolicyProvider.GetFallbackPolicyAsync();

        // This is where the magic happens: dynamically create a policy for any string name
        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            // You can optionally check if policyName starts with a prefix like "Permission:" 
            // or just treat any policy name as a permission name.
            var policy = new AuthorizationPolicyBuilder();
            policy.AddRequirements(new PermissionRequirement(policyName));
            return Task.FromResult<AuthorizationPolicy?>(policy.Build());
        }
    }
}
