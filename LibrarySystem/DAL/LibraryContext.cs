using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibrarySystem.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LibrarySystem.DAL
{
    public class LibraryContext: DbContext
    {
        public LibraryContext() : base("LibraryContext")
        {
        }
    public DbSet<Consumer> Consumers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}