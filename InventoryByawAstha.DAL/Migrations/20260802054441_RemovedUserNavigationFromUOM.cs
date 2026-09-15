using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryByawAstha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUserNavigationFromUOM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_unit_of_measure_user_createdby_user_id",
                table: "unit_of_measure");

            migrationBuilder.DropIndex(
                name: "IX_unit_of_measure_createdby_user_id",
                table: "unit_of_measure");

            migrationBuilder.DropColumn(
                name: "createdby_user_id",
                table: "unit_of_measure");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "createdby_user_id",
                table: "unit_of_measure",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_unit_of_measure_createdby_user_id",
                table: "unit_of_measure",
                column: "createdby_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_unit_of_measure_user_createdby_user_id",
                table: "unit_of_measure",
                column: "createdby_user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
