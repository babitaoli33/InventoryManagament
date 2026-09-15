using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryByawAstha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixedEntitiesConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroups_Users_UserId",
                table: "ProductGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitsofMeasure_UnitOfMeasureId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Products_ProductId",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_Purchases_PurchaseId",
                table: "PurchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Users_UserId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Vendors_VendorId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetails_Products_ProductId",
                table: "SaleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetails_Sales_SaleId",
                table: "SaleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitsofMeasure_Users_UserId",
                table: "UnitsofMeasure");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Users_UserId",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitsofMeasure",
                table: "UnitsofMeasure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleDetails",
                table: "SaleDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseDetails",
                table: "PurchaseDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductGroups",
                table: "ProductGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Vendors",
                newName: "vendor");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "UnitsofMeasure",
                newName: "unit_of_measure");

            migrationBuilder.RenameTable(
                name: "Sales",
                newName: "sale");

            migrationBuilder.RenameTable(
                name: "SaleDetails",
                newName: "sale_detail");

            migrationBuilder.RenameTable(
                name: "Purchases",
                newName: "purchase");

            migrationBuilder.RenameTable(
                name: "PurchaseDetails",
                newName: "purchase_detail");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "ProductGroups",
                newName: "product_group");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "customer");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "vendor",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "vendor",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "vendor",
                newName: "createdby_user_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "vendor",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "vendor",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Vendors_UserId",
                table: "vendor",
                newName: "IX_vendor_createdby_user_id");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "user",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "user",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "UserPhoneNumber",
                table: "user",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "user",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "HashPassword",
                table: "user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserEmail",
                table: "user",
                newName: "IX_user_email");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "unit_of_measure",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "unit_of_measure",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "unit_of_measure",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "unit_of_measure",
                newName: "createdby_user_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "unit_of_measure",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "UnitofMeasureId",
                table: "unit_of_measure",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_UnitsofMeasure_UserId",
                table: "unit_of_measure",
                newName: "IX_unit_of_measure_createdby_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_UnitsofMeasure_Code",
                table: "unit_of_measure",
                newName: "IX_unit_of_measure_code");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "sale",
                newName: "createdby_user_id");

            migrationBuilder.RenameColumn(
                name: "SaleDate",
                table: "sale",
                newName: "sale_date");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "sale",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "sale",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_UserId",
                table: "sale",
                newName: "IX_sale_createdby_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_CustomerId",
                table: "sale",
                newName: "IX_sale_customer_id");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "sale_detail",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "SalesPrice",
                table: "sale_detail",
                newName: "sales_price");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "sale_detail",
                newName: "sale_id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "sale_detail",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "SaleDetailId",
                table: "sale_detail",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_SaleDetails_SaleId",
                table: "sale_detail",
                newName: "IX_sale_detail_sale_id");

            migrationBuilder.RenameIndex(
                name: "IX_SaleDetails_ProductId",
                table: "sale_detail",
                newName: "IX_sale_detail_product_id");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "purchase",
                newName: "vendor_id");

            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "purchase",
                newName: "purchase_date");

            migrationBuilder.RenameColumn(
                name: "PurchaseId",
                table: "purchase",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "purchase",
                newName: "customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_VendorId",
                table: "purchase",
                newName: "IX_purchase_vendor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_UserId",
                table: "purchase",
                newName: "IX_purchase_customer_id");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "purchase_detail",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "SalesPrice",
                table: "purchase_detail",
                newName: "sales_price");

            migrationBuilder.RenameColumn(
                name: "PurchasePrice",
                table: "purchase_detail",
                newName: "purchase_price");

            migrationBuilder.RenameColumn(
                name: "PurchaseId",
                table: "purchase_detail",
                newName: "purchase_id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "purchase_detail",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "PurchaseDetailId",
                table: "purchase_detail",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDetails_PurchaseId",
                table: "purchase_detail",
                newName: "IX_purchase_detail_purchase_id");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDetails_ProductId",
                table: "purchase_detail",
                newName: "IX_purchase_detail_product_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "product",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "product",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "product",
                newName: "createdby_user_id");

            migrationBuilder.RenameColumn(
                name: "UnitOfMeasureId",
                table: "product",
                newName: "unit_of_measure_id");

            migrationBuilder.RenameColumn(
                name: "ProductGroupId",
                table: "product",
                newName: "product_group_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "product",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "product",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "product",
                newName: "IX_product_createdby_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UnitOfMeasureId",
                table: "product",
                newName: "IX_product_unit_of_measure_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductGroupId",
                table: "product",
                newName: "IX_product_product_group_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "product_group",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "product_group",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "product_group",
                newName: "createdby_user_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "product_group",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "ProductGroupId",
                table: "product_group",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGroups_UserId",
                table: "product_group",
                newName: "IX_product_group_createdby_user_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "customer",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "customer",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "customer",
                newName: "createdby_user_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "customer",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "customer",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_UserId",
                table: "customer",
                newName: "IX_customer_createdby_user_id");

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "user",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "User",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "phonenumber",
                table: "user",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vendor",
                table: "vendor",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_unit_of_measure",
                table: "unit_of_measure",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sale",
                table: "sale",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sale_detail",
                table: "sale_detail",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchase",
                table: "purchase",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchase_detail",
                table: "purchase_detail",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_group",
                table: "product_group",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer",
                table: "customer",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_customer_user_createdby_user_id",
                table: "customer",
                column: "createdby_user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_group_product_group_id",
                table: "product",
                column: "product_group_id",
                principalTable: "product_group",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_unit_of_measure_unit_of_measure_id",
                table: "product",
                column: "unit_of_measure_id",
                principalTable: "unit_of_measure",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_user_createdby_user_id",
                table: "product",
                column: "createdby_user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_group_user_createdby_user_id",
                table: "product_group",
                column: "createdby_user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_customer_customer_id",
                table: "purchase",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_vendor_vendor_id",
                table: "purchase",
                column: "vendor_id",
                principalTable: "vendor",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_detail_product_product_id",
                table: "purchase_detail",
                column: "product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_detail_purchase_purchase_id",
                table: "purchase_detail",
                column: "purchase_id",
                principalTable: "purchase",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sale_customer_customer_id",
                table: "sale",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sale_user_createdby_user_id",
                table: "sale",
                column: "createdby_user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sale_detail_product_product_id",
                table: "sale_detail",
                column: "product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sale_detail_sale_sale_id",
                table: "sale_detail",
                column: "sale_id",
                principalTable: "sale",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_unit_of_measure_user_createdby_user_id",
                table: "unit_of_measure",
                column: "createdby_user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vendor_user_createdby_user_id",
                table: "vendor",
                column: "createdby_user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_user_createdby_user_id",
                table: "customer");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_group_product_group_id",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_unit_of_measure_unit_of_measure_id",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_user_createdby_user_id",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_group_user_createdby_user_id",
                table: "product_group");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_customer_customer_id",
                table: "purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_vendor_vendor_id",
                table: "purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_detail_product_product_id",
                table: "purchase_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_detail_purchase_purchase_id",
                table: "purchase_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_sale_customer_customer_id",
                table: "sale");

            migrationBuilder.DropForeignKey(
                name: "FK_sale_user_createdby_user_id",
                table: "sale");

            migrationBuilder.DropForeignKey(
                name: "FK_sale_detail_product_product_id",
                table: "sale_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_sale_detail_sale_sale_id",
                table: "sale_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_unit_of_measure_user_createdby_user_id",
                table: "unit_of_measure");

            migrationBuilder.DropForeignKey(
                name: "FK_vendor_user_createdby_user_id",
                table: "vendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vendor",
                table: "vendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_unit_of_measure",
                table: "unit_of_measure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sale_detail",
                table: "sale_detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sale",
                table: "sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchase_detail",
                table: "purchase_detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchase",
                table: "purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_group",
                table: "product_group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customer",
                table: "customer");

            migrationBuilder.RenameTable(
                name: "vendor",
                newName: "Vendors");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "unit_of_measure",
                newName: "UnitsofMeasure");

            migrationBuilder.RenameTable(
                name: "sale_detail",
                newName: "SaleDetails");

            migrationBuilder.RenameTable(
                name: "sale",
                newName: "Sales");

            migrationBuilder.RenameTable(
                name: "purchase_detail",
                newName: "PurchaseDetails");

            migrationBuilder.RenameTable(
                name: "purchase",
                newName: "Purchases");

            migrationBuilder.RenameTable(
                name: "product_group",
                newName: "ProductGroups");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "customer",
                newName: "Customers");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Vendors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Vendors",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Vendors",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "createdby_user_id",
                table: "Vendors",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Vendors",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_vendor_createdby_user_id",
                table: "Vendors",
                newName: "IX_Vendors_UserId");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Users",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Users",
                newName: "UserRole");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                table: "Users",
                newName: "UserPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "HashPassword");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_email",
                table: "Users",
                newName: "IX_Users_UserEmail");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "UnitsofMeasure",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "UnitsofMeasure",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "UnitsofMeasure",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "UnitsofMeasure",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "createdby_user_id",
                table: "UnitsofMeasure",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UnitsofMeasure",
                newName: "UnitofMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_unit_of_measure_createdby_user_id",
                table: "UnitsofMeasure",
                newName: "IX_UnitsofMeasure_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_unit_of_measure_code",
                table: "UnitsofMeasure",
                newName: "IX_UnitsofMeasure_Code");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "SaleDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "sales_price",
                table: "SaleDetails",
                newName: "SalesPrice");

            migrationBuilder.RenameColumn(
                name: "sale_id",
                table: "SaleDetails",
                newName: "SaleId");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "SaleDetails",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SaleDetails",
                newName: "SaleDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_sale_detail_sale_id",
                table: "SaleDetails",
                newName: "IX_SaleDetails_SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_sale_detail_product_id",
                table: "SaleDetails",
                newName: "IX_SaleDetails_ProductId");

            migrationBuilder.RenameColumn(
                name: "sale_date",
                table: "Sales",
                newName: "SaleDate");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "Sales",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "createdby_user_id",
                table: "Sales",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Sales",
                newName: "SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_sale_customer_id",
                table: "Sales",
                newName: "IX_Sales_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_sale_createdby_user_id",
                table: "Sales",
                newName: "IX_Sales_UserId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "PurchaseDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "sales_price",
                table: "PurchaseDetails",
                newName: "SalesPrice");

            migrationBuilder.RenameColumn(
                name: "purchase_price",
                table: "PurchaseDetails",
                newName: "PurchasePrice");

            migrationBuilder.RenameColumn(
                name: "purchase_id",
                table: "PurchaseDetails",
                newName: "PurchaseId");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "PurchaseDetails",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PurchaseDetails",
                newName: "PurchaseDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_detail_purchase_id",
                table: "PurchaseDetails",
                newName: "IX_PurchaseDetails_PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_detail_product_id",
                table: "PurchaseDetails",
                newName: "IX_PurchaseDetails_ProductId");

            migrationBuilder.RenameColumn(
                name: "vendor_id",
                table: "Purchases",
                newName: "VendorId");

            migrationBuilder.RenameColumn(
                name: "purchase_date",
                table: "Purchases",
                newName: "PurchaseDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Purchases",
                newName: "PurchaseId");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "Purchases",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_vendor_id",
                table: "Purchases",
                newName: "IX_Purchases_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_customer_id",
                table: "Purchases",
                newName: "IX_Purchases_UserId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ProductGroups",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "ProductGroups",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "ProductGroups",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "createdby_user_id",
                table: "ProductGroups",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductGroups",
                newName: "ProductGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_product_group_createdby_user_id",
                table: "ProductGroups",
                newName: "IX_ProductGroups_UserId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "unit_of_measure_id",
                table: "Products",
                newName: "UnitOfMeasureId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Products",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "product_group_id",
                table: "Products",
                newName: "ProductGroupId");

            migrationBuilder.RenameColumn(
                name: "createdby_user_id",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_product_unit_of_measure_id",
                table: "Products",
                newName: "IX_Products_UnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_product_product_group_id",
                table: "Products",
                newName: "IX_Products_ProductGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_product_createdby_user_id",
                table: "Products",
                newName: "IX_Products_UserId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Customers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Customers",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Customers",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "createdby_user_id",
                table: "Customers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_customer_createdby_user_id",
                table: "Customers",
                newName: "IX_Customers_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserRole",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "User")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserPhoneNumber",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors",
                column: "VendorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitsofMeasure",
                table: "UnitsofMeasure",
                column: "UnitofMeasureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleDetails",
                table: "SaleDetails",
                column: "SaleDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales",
                table: "Sales",
                column: "SaleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseDetails",
                table: "PurchaseDetails",
                column: "PurchaseDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "PurchaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductGroups",
                table: "ProductGroups",
                column: "ProductGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroups_Users_UserId",
                table: "ProductGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupId",
                table: "Products",
                column: "ProductGroupId",
                principalTable: "ProductGroups",
                principalColumn: "ProductGroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitsofMeasure_UnitOfMeasureId",
                table: "Products",
                column: "UnitOfMeasureId",
                principalTable: "UnitsofMeasure",
                principalColumn: "UnitofMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Products_ProductId",
                table: "PurchaseDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_Purchases_PurchaseId",
                table: "PurchaseDetails",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "PurchaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Users_UserId",
                table: "Purchases",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Vendors_VendorId",
                table: "Purchases",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "VendorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetails_Products_ProductId",
                table: "SaleDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetails_Sales_SaleId",
                table: "SaleDetails",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "SaleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitsofMeasure_Users_UserId",
                table: "UnitsofMeasure",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Users_UserId",
                table: "Vendors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
