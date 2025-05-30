using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eatery_manager_server.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailAndRoleToLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Login",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Login",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Login");
        }
    }
}
