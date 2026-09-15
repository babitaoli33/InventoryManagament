using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryByawAstha.Domain.Entities
{
    public class UserPermission
    {
        public int UserPermissionId { get; set; }
        public int UserId { get; set; }
        public string PermissionName { get; set; } = string.Empty;
    }
}
