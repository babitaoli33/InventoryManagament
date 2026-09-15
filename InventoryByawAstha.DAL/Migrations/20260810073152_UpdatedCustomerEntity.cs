using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryByawAstha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCustomerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_user_createdby_user_id",
                table: "customer");

            migrationBuilder.DropForeignKey(
                name: "FK_sale_customer_customer_id",
                table: "sale");

            migrationBuilder.DropIndex(
                name: "IX_customer_createdby_user_id",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "User",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "createdby_user_id",
                table: "customer");

            migrationBuilder.AddColumn<string>(
                name: "phone_number",
                table: "customer",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_sale_customer_customer_id",
                table: "sale",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sale_customer_customer_id",
                table: "sale");

            migrationBuilder.DropColumn(
                name: "phone_number",
                table: "customer");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "customer",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "createdby_user_id",
                table: "customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_customer_createdby_user_id",
                table: "customer",
                column: "createdby_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_customer_user_createdby_user_id",
                table: "customer",
                column: "createdby_user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sale_customer_customer_id",
                table: "sale",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
