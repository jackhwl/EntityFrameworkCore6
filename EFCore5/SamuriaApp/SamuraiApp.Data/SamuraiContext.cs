using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using System;

namespace SamuraiApp.Data
{
	public class SamuraiContext: DbContext
	{
		public DbSet<Samurai> Samurais { get; set; }
		public DbSet<Quote>	Quotes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb; Initial Catalog=SamuraiTestData5;Trusted_Connection=True;");
		}
	}
}
