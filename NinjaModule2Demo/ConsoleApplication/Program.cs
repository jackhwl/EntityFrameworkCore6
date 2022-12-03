using NinjaDomain.Classes;
using NinjaDomain.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			Database.SetInitializer(new NullDatabaseInitializer<NinjaContext>());
			//InsertNinja();
			InsertMultipleNinjasNinja();
			Console.ReadKey();
		}

		private static void InsertMultipleNinjasNinja()
		{
			var ninja1 = new Ninja
			{
				Name = "Leonardo",
				ServedInOniwaban = false,
				DateOfBirth = new DateTime(1984, 1, 1),
				ClanId = 1
			};
			var ninja2 = new Ninja
			{
				Name = "Raphael",
				ServedInOniwaban = false,
				DateOfBirth = new DateTime(1985, 1, 1),
				ClanId = 1
			};
			using (var context = new NinjaContext())
			{
				context.Database.Log = Console.WriteLine;
				context.Ninjas.AddRange(new List<Ninja>{ninja1, ninja2 });
				context.SaveChanges();
			}
		}

		private static void InsertNinja()
		{
			var ninja = new Ninja
			{
				Name = "PeterChen",
				ServedInOniwaban = false,
				DateOfBirth = new DateTime(2018,2,2),
				ClanId = 1
			};

			using(var context = new NinjaContext())
			{
				context.Database.Log = Console.WriteLine;
				context.Ninjas.Add(ninja);
				context.SaveChanges();
			}
		}
	}
}
