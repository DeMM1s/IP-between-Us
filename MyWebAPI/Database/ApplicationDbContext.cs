using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;
using System;

namespace MyWebAPI.Database
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<IPInfo> IPInfos { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<IPInfo>()
			.Property(i => i.IntermediateIP)
			.HasConversion(
				v => string.Join(',', v),
				v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
			modelBuilder.Entity<IPInfo>().HasKey(i => new { i.StartIP, i.EndIP });
		}
	}
}
