﻿using GloboTicket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Domain.Services;
public class PromotionService
{
    private readonly GloboTicketContext context;

    public PromotionService(GloboTicketContext context)
	{
        this.context = context;
    }

    public async Task<Show> BookShow(Venue venue, Act act, DateTimeOffset date)
    {
        var show = new Show(venue, act)
        {
            //ShowGuid = s
            Date = date
        };

        await context.AddAsync(show);
        await context.SaveChangesAsync();

        return show;
    }

    public async Task<Venue> CreateVenue(Guid venueGuid, string name, string address)
    {
        var venue = new Venue
        {
            VenueGuid = venueGuid,
            Name = name,
            Address = address
        };

        await context.AddAsync(venue);
        await context.SaveChangesAsync();

        return venue;
    }

    public async Task<Act> CreateAct(Guid actGuid, string name)
    {
        var act = new Act
        {
            ActGuid = actGuid,
            Name = name
        };

        await context.AddAsync(act);
        await context.SaveChangesAsync();

        return act;
    }
}
