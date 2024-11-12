﻿using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.Context
{
    public class CampContext : DbContext
    {
        // Dbset entity'lerimizi bir tablo olarak programa bildirmemizi sağlar.
        // DbSet<Category> 'teki Category bizim entity classımız. 
        // "Categories" ise tabloya yansıyacak olan kısım (Pillar lines)
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}