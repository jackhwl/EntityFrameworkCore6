using GloboTicket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GloboTicket.Infrastructure.Configuration;
internal class VenueConfiguration
{
    public void Configure(EntityTypeBuilder<Venue> builder)
    {
        builder.ToTable("VenueTable");
    }
}
