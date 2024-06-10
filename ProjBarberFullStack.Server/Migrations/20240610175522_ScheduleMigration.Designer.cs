﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjBarberFullStack.Server.DataContext;

#nullable disable

namespace ProjBarberFullStack.Server.Migrations
{
	[DbContext(typeof(ApplicationDbContext))]
	[Migration("20240610175522_ScheduleMigration")]
	partial class ScheduleMigration
	{
		/// <inheritdoc />
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "8.0.6")
				.HasAnnotation("Relational:MaxIdentifierLength", 128);

			SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

			modelBuilder.Entity("ProjBarberFullStack.Server.Models.ScheduleModel", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<DateTime>("ChangeDate")
						.HasColumnType("datetime2");

					b.Property<DateTime>("CreationDate")
						.HasColumnType("datetime2");

					b.Property<string>("Name")
						.HasColumnType("nvarchar(max)");

					b.Property<DateTime>("ScheduleDate")
						.HasColumnType("datetime2");

					b.Property<string>("ScheduleTime")
						.HasColumnType("nvarchar(max)");

					b.HasKey("Id");

					b.ToTable("Schedule");
				});

			modelBuilder.Entity("ProjBarberFullStack.Server.Models.SchedulingModel", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<DateTime>("ChangeDate")
						.HasColumnType("datetime2");

					b.Property<DateTime>("CreationDate")
						.HasColumnType("datetime2");

					b.Property<string>("Name")
						.HasColumnType("nvarchar(max)");

					b.Property<DateTime>("SchedulingDate")
						.HasColumnType("datetime2");

					b.Property<string>("SchedulingTime")
						.HasColumnType("nvarchar(max)");

					b.Property<int>("Services")
						.HasColumnType("int");

					b.HasKey("Id");

					b.ToTable("Scheduling");
				});

			modelBuilder.Entity("ProjBarberFullStack.Server.Models.UserModel", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<DateTime>("ChangeDate")
						.HasColumnType("datetime2");

					b.Property<string>("Contact")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.Property<DateTime>("CreationDate")
						.HasColumnType("datetime2");

					b.Property<string>("Email")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.Property<string>("User")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.HasKey("Id");

					b.ToTable("Users");
				});
#pragma warning restore 612, 618
		}
	}
}
