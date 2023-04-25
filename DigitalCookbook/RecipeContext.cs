using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCookbook
{
    internal class RecipeContext : DbContext
    {
        private string _connectionString = "Server=(LocalDB)\\mssqllocalDB;Database=Recipes;Trusted_Connection=True;MultipleActiveResultSets=true";

        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Recipe>().HasData(
                new Recipe("Krabby Patty", Images.krabby_patty, true,
                new string[] { "Pay Mr. Krabs $4.00", "Spongebob makes the patty", "Squidward gives it" }));
        }


    }
}
