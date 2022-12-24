using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamuraiApp.UI
{
	class Program
	{
        private static SamuraiContext _context = new SamuraiContext();

        private static void Main(string[] args)
        {
            //_context.Database.EnsureCreated();
            //AddSamuraisByName("Shimada", "Okamoto", "Kikuchio", "Hayashida");
            //AddVariousTypes();
            // GetSamurais();
            //         GetSamurais("Before Add:");
            //AddSamurai();
            //GetSamurais("After Add:");
            //InsertNewSamuraiWithAQuote();
            //Simple_AddQuoteToExistingSamuraiNotTracked(2);
            //FilteringWithRelatedData();
            QuerySamuraiBattleStats();

            Console.Write("Press any key...");
            Console.ReadKey();
        }

		private static void QuerySamuraiBattleStats()
		{
			var firststat = _context.SamuraiBattleStats.FirstOrDefault();
            var sampsonState = _context.SamuraiBattleStats.FirstOrDefault(b => b.Name == "Sampson");
		}

		private static void FilteringWithRelatedData()
		{
			var samurais = _context.Samurais
                .Where(s => s.Quotes.Any(q => q.Text.Contains("dinner")))
                .ToList();
		}

		private static void Simple_AddQuoteToExistingSamuraiNotTracked(int samuraiId)
		{
			var quote = new Quote { Text = "Thanks for dinner!", SamuraiId = samuraiId};
            using var newContext = new SamuraiContext();
            newContext.Quotes.Add(quote);
            newContext.SaveChanges();
		}

		private static void InsertNewSamuraiWithAQuote()
		{
			var samurai = new Samurai 
            {
                Name = "Kambei Shimada",
                Quotes = new List<Quote>
				{
                    new Quote { Text = "I've come to save you"}
				}
			};
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
		}

		private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Julie" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        private static void AddSamuraisByName(params string[] names)
        {
            foreach(string name in names)
			{
                _context.Samurais.Add(new Samurai { Name = name });
			}
            
            _context.SaveChanges();
        }
        private static void AddVariousTypes()
		{
			//_context.AddRange(new Samurai { Name = "Shimada"},
			//    new Samurai { Name = "Okamoto" },
			//    new Battle { Name = "Battle of Anegawa" },
			//    new Battle { Name = "Battle of Nagashino" }
			//);
			//_context.Samurais.AddRange(new Samurai { Name = "Shimada" },
			//    new Samurai { Name = "Okamoto" }
			//    );
			_context.Battles.AddRange(new Battle { Name = "Battle of Anegawa" },
				new Battle { Name = "Battle of Nagashino" }
				);
            _context.SaveChanges();
        }
        private static void GetSamurais()
        {
            var samurais = _context.Samurais
                .TagWith("ConsoleApp.Program.GetSamurais method")
                .ToList();
            Console.WriteLine($"Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
