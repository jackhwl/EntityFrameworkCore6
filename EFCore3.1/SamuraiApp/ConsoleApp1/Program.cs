using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp1
{
	class Program
	{
        private static SamuraiContext context = new SamuraiContext();

        private static void Main(string[] args)
        {
            //GetSamurais("Before Add:");
            //AddSamurai();
            //GetSamurais("After Add:");
            //AddBattles();
            QueryAndUpdateBattle_Disconnected();
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Sampson" };
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }
        private static void AddBattles()
        {
            var battle = new Battle { Name = "Battle of Okehazama", StartDate= new DateTime(1560, 5,1), EndDate = new DateTime(1560, 6, 15) };
            context.Battles.Add(battle);
            context.SaveChanges();
        }
        private static void QueryAndUpdateBattle_Disconnected()
        {
            var battle = context.Battles.AsNoTracking().FirstOrDefault();
            battle.EndDate = new DateTime(1560, 6, 30);
            using(var newContextInstance = new SamuraiContext())
			{
                newContextInstance.Battles.Update(battle);
                newContextInstance.SaveChanges();
			}
        }
        private static void GetSamurais(string text)
        {
            var samurais = context.Samurais.Where(s => EF.Functions.Like(s.Name, "%abc%")).ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
