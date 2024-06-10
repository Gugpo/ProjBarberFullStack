using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjBarberFullStack.Server.Migrations
{
	/// <inheritdoc />
	public partial class ScheduleMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "SchedulingTime",
				table: "Scheduling",
				type: "nvarchar(max)",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Scheduling",
				type: "nvarchar(max)",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");

			migrationBuilder.CreateTable(
				name: "Schedule",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ScheduleTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Schedule", x => x.Id);
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Schedule");

			migrationBuilder.AlterColumn<string>(
				name: "SchedulingTime",
				table: "Scheduling",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Scheduling",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true);
		}
	}
}
