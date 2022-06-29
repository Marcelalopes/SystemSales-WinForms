using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsSales.Models;

namespace WinFormsSales.Context
{
    /// <summary>
    /// Bank connection class
    /// </summary>
    class SalesContext: DbContext
    { 
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ItemSale> SalesItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server=DESKTOP-9G183NR\\SQLEXPRESS;database=sales2;trusted_connection=true;");
        }
    }
}
