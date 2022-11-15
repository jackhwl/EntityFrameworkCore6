using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace SamuraiApp.Data
{
	public class SamuraiContext:DbContext
	{
		public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

		public DbSet<Samurai> Samurais { get; set; }
		public DbSet<Quote> Quotes { get; set; }
		public DbSet<Battle> Battles { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//ConfigurationManager.AppSettings["ConnectionString"]
			optionsBuilder
				.UseLoggerFactory(MyLoggerFactory)
				.EnableSensitiveDataLogging(true)
				.UseSqlServer("Data Source=(localdb)\\mssqllocaldb; Initial Catalog=SamuraiAppData;Trusted_Connection=True;");
		}
	}
}
