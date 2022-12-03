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
			//InsertMultipleNinjasNinja();
			InsertNinjaWithEquipment();
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

		private static void SimpleNinjaQueries()
		{
			using(var context = new NinjaContext())
			{
				var ninja = context.Ninjas.ToList();
				var ninja1 = context.Ninjas.
					Where(n => n.DateOfBirth>=new DateTime(1984,1,1))
					.FirstOrDefault();
				var ninja2 = context.Ninjas.
					FirstOrDefault(n => n.DateOfBirth >= new DateTime(1984, 1, 1));
			}
		}
		private static void QueryAndUpdateNinja()
		{
			using (var context = new NinjaContext())
			{
				context.Database.Log = Console.WriteLine;
				var ninja = context.Ninjas.FirstOrDefault();
				ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);
				context.SaveChanges();
			}
		}
		private static void QueryAndUpdateNinjaDisconnected()
		{
			Ninja ninja;
			using (var context = new NinjaContext())
			{
				context.Database.Log = Console.WriteLine;
				ninja = context.Ninjas.FirstOrDefault();
			}

			ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);

			using (var context = new NinjaContext())
			{
				context.Database.Log = Console.WriteLine;
				context.Ninjas.Attach(ninja);
				context.Entry(ninja).State =  EntityState.Modified;
				context.SaveChanges();
			}
		}
		private static void RetrieveDataWithFind()
		{
			var keyval = 4;
			using (var context = new NinjaContext())
			{
				context.Database.Log = Console.WriteLine;
				var ninja = context.Ninjas.Find(keyval);
				Console.WriteLine("After Find#1:" + ninja.Name);
				var ninja2 = context.Ninjas.Find(keyval);
				Console.WriteLine("After Find#2:" + ninja2.Name);
				ninja = null;
			}
		}
		private static void RetrieveDataWithStoredProc()
		{
			using (var context = new NinjaContext())
			{
				context.Database.Log = Console.WriteLine;
				var ninjas = context.Ninjas.SqlQuery("exec GetOldNinjas");
				foreach(var ninja in ninjas)
				{
					Console.WriteLine(ninja.Name);
				}
			}
		}
		private static void DeleteNinja()
		{
			using (var context = new NinjaContext())
			{
				context.Database.Log = Console.WriteLine;
				var ninja = context.Ninjas.FirstOrDefault();
				context.Ninjas.Remove(ninja);
				context.SaveChanges();
			}
		}
		private static void DeleteNinja1()
		{
			Ninja ninja;
			using (var context = new NinjaContext())
			{
				context.Database.Log = Console.WriteLine;
				 ninja = context.Ninjas.FirstOrDefault();
				//context.Ninjas.Remove(ninjas);
				//context.SaveChanges();
			}
			using (var context = new NinjaContext())
			{
				context.Database.Log = Console.WriteLine;
				//context.Ninjas.Attach(ninja);
				//context.Ninjas.Remove(ninja);
				context.Entry(ninja).State = EntityState.Deleted;
				context.SaveChanges();
			}
		}
		private static void DeleteNinjaWithKeyValue()
		{
			var keyval = 1;
			using (var context = new NinjaContext())
			{
				context.Database.Log = Console.WriteLine;
				var ninja = context.Ninjas.Find(keyval);
				context.Ninjas.Remove(ninja);
				context.SaveChanges();
			}
		}
		private static void DeleteNinjaViaStoredProcedure()
		{
			var keyval = 3;
			using (var context = new NinjaContext())
			{
				context.Database.Log = Console.WriteLine;
				context.Database.ExecuteSqlCommand("exec DeleteNinjaViaId {0}", keyval);
			}
		}
		private static void InsertNinjaWithEquipment()
		{
			using (var context = new NinjaContext())
			{
				context.Database.Log = Console.WriteLine;
				var ninja = new Ninja
				{
					Name = "Kacy Catanzaro",
					ServedInOniwaban = false,
					DateOfBirth = new DateTime(1990, 1, 14),
					ClanId = 1
				};
				var muscles = new NinjaEquipment
				{
					Name = "Muscles",
					Type = EquipmentType.Tool
				};
				var spunk = new NinjaEquipment
				{
					Name = "Spunk",
					Type = EquipmentType.Weapon
				};
				context.Ninjas.Add(ninja);
				ninja.EquipmentOwned.Add(muscles);
				ninja.EquipmentOwned.Add(spunk);
				context.SaveChanges();
			}
		}
	}
}
