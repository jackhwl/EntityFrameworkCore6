using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SamuraiApp.Domain;
using System;

namespace SamuraiApp.Data
{
	public class SamuraiContext: DbContext
	{
		public SamuraiContext()
		{
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}
		public SamuraiContext(DbContextOptions<SamuraiContext> options) : base(options)
		{
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		public DbSet<Samurai> Samurais { get; set; }
		public DbSet<Quote> Quotes { get; set; }
		public DbSet<Clan> Clans { get; set; }
		public DbSet<Battle> Battles { get; set; }

		//public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
		//{
		//	builder
		//	.AddFilter((category, level) => 
		//		category == DbLoggerCategory.Database.Command.Name 
		//		&& level == LogLevel.Information)
		//	.AddConsole();

		//});

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					//.UseLoggerFactory(ConsoleLoggerFactory).EnableSensitiveDataLogging()
					.UseSqlServer("Data Source=(localdb)\\mssqllocaldb; Initial Catalog=SamuraiTestData31;Trusted_Connection=True;");
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
			modelBuilder.Entity<House>().ToTable("Horses");
		}
	}
}
