using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryByawAstha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUnitOfMeasureConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_user_phonenumber",
                table: "user",
                column: "phonenumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unit_of_measure_name",
                table: "unit_of_measure",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_phonenumber",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_unit_of_measure_name",
                table: "unit_of_measure");
        }
    }
}
