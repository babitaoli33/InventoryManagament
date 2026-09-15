using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryByawAstha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RestructuredEntireSolution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Role",
                table: "Users",
                newName: "UserRole");

            migrationBuilder.RenameColumn(
                name: "User_PhoneNumber",
                table: "Users",
                newName: "UserPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "User_Name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "User_Email",
                table: "Users",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Users",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "Users",
                newName: "User_Role");

            migrationBuilder.RenameColumn(
                name: "UserPhoneNumber",
                table: "Users",
                newName: "User_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "User_Name");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "User_Email");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "User_Id");
        }
    }
}
