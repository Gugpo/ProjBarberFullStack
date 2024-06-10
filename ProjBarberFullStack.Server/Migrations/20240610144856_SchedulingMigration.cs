using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjBarberFullStack.Server.Migrations
{
	/// <inheritdoc />
	public partial class SchedulingMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Scheduling",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Services = table.Column<int>(type: "int", nullable: false),
					SchedulingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					SchedulingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Scheduling", x => x.Id);
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Scheduling");
		}
	}
}
