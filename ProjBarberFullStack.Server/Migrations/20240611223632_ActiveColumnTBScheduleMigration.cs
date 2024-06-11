using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjBarberFullStack.Server.Migrations
{
    /// <inheritdoc />
    public partial class ActiveColumnTBScheduleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Schedule",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Schedule");
        }
    }
}
