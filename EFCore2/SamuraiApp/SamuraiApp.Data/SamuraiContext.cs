using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using System.Configuration;

namespace SamuraiApp.Data
{
	public class SamuraiContext:DbContext
	{
		public DbSet<Samurai> Samurais { get; set; }
		public DbSet<Quote> Quotes { get; set; }
		public DbSet<Battle> Battles { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["viDesktop.ConnectionString"].ToString());
		}
	}
}
