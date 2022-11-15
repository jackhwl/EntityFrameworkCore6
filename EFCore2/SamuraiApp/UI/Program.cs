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
			InsertBattle();
			//InsertMultipleBattles();
		}

		private static void InsertBattle()
		{
			var battle = new Battle { Name = "Jack Huang" };
			using(var context = new SamuraiContext())
			{
				context.Battles.Add(battle);
				context.SaveChanges();
			}
		}
		private static void InsertMultipleBattles()
		{
			var battle = new Battle { Name = "Jack Huang" };
			using (var context = new SamuraiContext())
			{
				context.Battles.Add(battle);
				context.SaveChanges();
			}
		}
	}
}
