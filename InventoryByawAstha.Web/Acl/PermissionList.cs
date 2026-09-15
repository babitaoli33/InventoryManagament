namespace InventoryByawAstha.Web.Acl
{
    public static class PermissionList
    {
        public const string DashboardView = "Dashboard.View";
        public const string CustomerView = "Customer.View";
        public const string CustomerCreate = "Customer.Create";
        public const string CustomerUpdate = "Customer.Update";

        public  const string ProductView = "Product.View";
        public const string ProductCreate = "Product.Create";
        public const string ProductUpdate = "Product.Update";

        public const string ProductGroupView = "ProductGroup.View";
        public const string ProductGroupCreate = "ProductGroup.Create";
        public const string ProductGroupUpdate = "ProductGroup.Update";

        public const string UnitOfMeasureView = "UnitOfMeasure.View";
        public const string UnitOfMeasureCreate = "UnitOfMeasure.Create";
        public const string UnitOfMeasureUpdate = "UnitOfMeasure.Update";

        public const string VendorView = "Vendor.View";
        public const string VendorCreate = "Vendor.Create";
        public const string VendorUpdate = "Vendor.Update";

        public const string PurchaseView = "Purchase.View";
        public const string PurchaseCreate = "Purchase.Create";

        public const string SaleView = "Sale.View";
        public const string SaleCreate = "Sale.Create";

        public const string UserView = "User.View";
        public const string UserCreate = "User.Create";
        public const string UserUpdate = "User.Update";
        public const string UserActivate = "User.Activate";
        public const string UserDeactivate = "User.Deactivate";


        public static readonly string[] AllPermissions = new string[]
        {
                DashboardView,
                CustomerView,
                CustomerCreate,
                CustomerUpdate,
                ProductView,
                ProductCreate,
                ProductUpdate,
                ProductGroupView,
                ProductGroupCreate,
                ProductGroupUpdate,
                UnitOfMeasureView,
                UnitOfMeasureCreate,
                UnitOfMeasureUpdate,
                VendorView,
                VendorCreate,
                VendorUpdate,
                PurchaseView,
                PurchaseCreate,
                SaleView,
                SaleCreate,
                UserView,
                UserCreate,
                UserUpdate,
                UserActivate,
                UserDeactivate
        };



    }
}
