using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UI
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			//InsertBattle();
			//InsertSamurai();
			//InsertMultipleBattles();
			//InsertMultipleDifferentObjects();
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
			var samurai = new Samurai { Name = "Jack Huang 0", BattleId = 2 };
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
			var samurai = new Samurai { Name = "Jack Huang 1" };
			var battle2 = new Battle { Name = "Battle of Nagashino"};
			using (var context = new SamuraiContext())
			{
				context.AddRange(samurai, battle2);
				context.SaveChanges();
			}
		}
	}
}
