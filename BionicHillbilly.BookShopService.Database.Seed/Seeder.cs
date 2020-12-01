using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using BionicHillbilly.BookShopService.Domain;

namespace BionicHillbilly.BookShopService.Database.Seed
{
    public static class Seeder
    {
        /// <summary>
        /// Seeds the database
        /// </summary>
        /// <param name="context">The database context to seed</param>
        public static void SeedDatabase(BookShopContext context)
        {
                context.Database.EnsureCreated();
                var location = Assembly.GetExecutingAssembly().Location;
                var p =  Path.Combine(Path.GetDirectoryName(location), "seed.json");

                using var rdr = new StreamReader(p, true);
                var data = rdr.ReadToEnd();
                var books = JsonSerializer.Deserialize<List<Book>>(data);

                if (context.Books.Any())
                    return;
                context.Books.AddRange(books);
                context.SaveChanges();
            }
    }
}