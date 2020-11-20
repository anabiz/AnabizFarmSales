using System;
using AnabizFarmSales.Modals;
using Microsoft.EntityFrameworkCore;

namespace AnabizFarmSales.Data
{
    public class AnabizFarmSalesContext : DbContext
    {
        internal readonly object farmSales;

        public AnabizFarmSalesContext(DbContextOptions<AnabizFarmSalesContext> opt) : base(opt)
        {

        }

        public DbSet<FarmSale> FarmSales { get; set; }
    }
}
