using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class OddToFoodDbContext : DbContext
    {
        public OddToFoodDbContext(DbContextOptions<OddToFoodDbContext> options): base(options)
        {

        }
        //This is the table that will be created in the DB (OdeToFood) given in the connection string configuration
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
