﻿using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using System;

namespace SamuraiApp.Data
{
	public class SamuraiContext: DbContext
	{
		public SamuraiContext()
		{

		}
		public DbSet<Samurai> Samurais { get; set; }
		public DbSet<Quote> Quotes { get; set; }
		public DbSet<Clan> Clans { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb; Initial Catalog=SamuraiAppData31;Trusted_Connection=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
		}
	}
}
