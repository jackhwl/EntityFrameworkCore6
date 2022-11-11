using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UI
{
	internal class Program
	{
		private static SamuraiContext context = new SamuraiContext();

		private static void Main(string[] args)
		{
			context.Database.EnsureCreated();
			Console.WriteLine("Hello World!");
		}
	}
}
