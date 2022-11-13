using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
	public class SamuraiContext : DbContext
	{
		public SamuraiContext(DbContextOptions<SamuraiContext> options) : base(options)
		{

		}
		public DbSet<Samurai> Samurais { get; set; }
		public DbSet<Quote> Quotes { get; set; }
		public DbSet<Battle> Battles { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	//ConfigurationManager.AppSettings["ConnectionString"]
		//	optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb; Initial Catalog=SamuraiAppData;Trusted_Connection=True;");
		//}
	}
}
