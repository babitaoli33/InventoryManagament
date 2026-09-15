using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryByawAstha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedSaleRelatedEntitiesAndConfigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sale_customer_customer_id",
                table: "sale");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "sale_detail",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "customer_id",
                table: "sale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "sale",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_sale_customer_customer_id",
                table: "sale",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sale_customer_customer_id",
                table: "sale");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "sale_detail");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "sale");

            migrationBuilder.AlterColumn<int>(
                name: "customer_id",
                table: "sale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_sale_customer_customer_id",
                table: "sale",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "id");
        }
    }
}
