﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsSales.Models;

namespace WinFormsSales.Context
{
    class SalesContext: DbContext
    { 
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server=DESKTOP-9G183NR\\SQLEXPRESS;database=sale_db;trusted_connection=true;");
        }
    }
}