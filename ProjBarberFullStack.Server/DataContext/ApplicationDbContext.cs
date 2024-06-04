﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProjBarberFullStack.Server.Models;

namespace ProjBarberFullStack.Server.DataContext
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<UserModel> Users { get; set; }
	}
}
