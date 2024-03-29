﻿using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UI
{
	internal class Program
	{
		private static SamuraiContext _context = new SamuraiContext();
		private static void Main(string[] args)
		{
			//InsertBattle();
			//InsertSamurai();
			//InsertMultipleBattles();
			//InsertMultipleDifferentObjects();
			//SimpleSamuraiQuery();
			//MoreQueries();
			//RetrieveAndUpdateSamurai();
			RetrieveAndUpdateMultipleSamurais();
		}
		private static void DeleteUsingId(int samuraiId)
		{
			var samurai = _context.Samurais.Find(samuraiId);
			_context.Remove(samurai);
			_context.SaveChanges();
			//alternate: call a stored procedure!
			//_context.Database.ExecuteSqlCommand("exec DeletedById {0}", samuraiId);
		}
		private static void RetrieveAndUpdateMultipleSamurais()
		{
			var samurais = _context.Samurais.ToList();
			samurais.ForEach(s => s.Name += "San");
			_context.SaveChanges();
		}

		private static void RetrieveAndUpdateSamurai()
		{
			var samurai = _context.Samurais.FirstOrDefault();
			samurai.Name += "San";
			_context.SaveChanges();
		}

		private static void MoreQueries()
		{
			var name = "Jack Huang 3";
			var samurais = _context.Samurais.Where(s => s.Name == name).ToList();
		}

		private static void SimpleSamuraiQuery()
		{
			using (var context = new SamuraiContext())
			{
				var samurais = context.Samurais.ToList();
			}
		}

		private static void InsertBattle()
		{
			var battle = new Battle { Name = "Battle of Nagashino" };
			using(var context = new SamuraiContext())
			{
				context.Battles.Add(battle);
				context.SaveChanges();
			}
		}
		private static void InsertSamurai()
		{
			var samurai = new Samurai { Name = "Jack Huang 0" };
			using (var context = new SamuraiContext())
			{
				context.Samurais.Add(samurai);
				context.SaveChanges();
			}
		}
		private static void InsertMultipleBattles()
		{
			var battle = new Battle { Name = "Jack Huang 1" };
			var battle2 = new Battle { Name = "Jack Huang 2" };
			using (var context = new SamuraiContext())
			{
				context.Battles.AddRange(battle, battle2);
				context.SaveChanges();
			}
		}
		private static void InsertMultipleDifferentObjects()
		{
			
			var battle2 = new Battle { Name = "Battle of Nagashino 4"};
			
			using (var context = new SamuraiContext())
			{
				context.Battles.AddRange(battle2);
				context.SaveChanges();
				var samurai = new Samurai { Name = "Jack Huang 4" };
				context.Samurais.AddRange(samurai);
				context.SaveChanges();
			}
		}
	}
}
