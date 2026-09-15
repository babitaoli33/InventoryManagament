using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryByawAstha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedTotalAmountToPurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "purchase",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "purchase");
        }
    }
}
