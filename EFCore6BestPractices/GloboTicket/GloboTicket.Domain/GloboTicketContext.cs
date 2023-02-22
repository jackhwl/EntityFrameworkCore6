using GloboTicket.Domain.Entities;
using GloboTicket.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.Domain;
public class GloboTicketContext : DbContext
{
	private IModelConfiguration modelConfiguration;
	public GloboTicketContext(DbContextOptions<GloboTicketContext> options, IModelConfiguration modelConfiguration) : base(options)
	{
		this.modelConfiguration = modelConfiguration;
	}

	//public DbSet<Venue> Venue => Set<Venue>();
 //   public DbSet<Act> Act => Set<Act>();
 //   public DbSet<Show> Show	=> Set<Show>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketContext).Assembly);
		modelConfiguration.ConfigureModel(modelBuilder);
	}
}