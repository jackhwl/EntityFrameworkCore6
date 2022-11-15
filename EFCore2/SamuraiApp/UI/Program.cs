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
			InsertSamurai();
		}

		private static void InsertSamurai()
		{
			var battle = new Battle { Name = "Jack Huang" };
			using(var context = new SamuraiContext())
			{
				context.Battles.Add(battle);
				context.SaveChanges();
			}
		}
	}
}
