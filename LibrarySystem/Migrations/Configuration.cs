namespace LibrarySystem.Migrations
{
    using LibrarySystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibrarySystem.DAL.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibrarySystem.DAL.LibraryContext context)
        {
           
            var consumers = new List<Consumer>
            {
                new Consumer { FirstName = "Sebastian",   LastName = "Baba",
                    RegisterDate = DateTime.Parse("5/5/2015") },
                new Consumer { FirstName = "Christine", LastName = "Co",
                    RegisterDate = DateTime.Parse("6/6/2016") },
                new Consumer { FirstName = "Chris",   LastName = "Flores",
                    RegisterDate = DateTime.Parse("1/1/2012") },
                new Consumer { FirstName = "Harkaran",    LastName = "Grewal",
                    RegisterDate = DateTime.Parse("2/2/2013") },
                new Consumer { FirstName = "Amin",      LastName = "Hassan",
                    RegisterDate = DateTime.Parse("3/3/2014") },
                new Consumer { FirstName = "Armando",    LastName = "Montoya",
                    RegisterDate = DateTime.Parse("7/7/2018") },
                new Consumer { FirstName = "Yi",    LastName = "Weng",
                    RegisterDate = DateTime.Parse("4/4/2015") },
            };
            consumers.ForEach(s => context.Consumers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var inventories = new List<Inventory>
            {
                new Inventory {BookID = 1000, BookTitle = "MVC Totorial #1", Price="$49.99", },
                new Inventory {BookID = 1001, BookTitle = "MVC Totorial #2", Price="$69.99", },
                new Inventory {BookID = 1002, BookTitle = "MVC Totorial #3", Price="$89.99", },
                new Inventory {BookID = 1003, BookTitle = "MVC Totorial #4", Price="$99.99", },
                new Inventory {BookID = 1004, BookTitle = "MVC Totorial #5", Price="$109.99", },
                new Inventory {BookID = 1005, BookTitle = "MVC Totorial #6", Price="$119.99", },
            };
            inventories.ForEach(s => context.Inventories.AddOrUpdate(p => p.BookTitle, s));
            context.SaveChanges();
           
            var transactions = new List<Transaction>
            {
                new Transaction {
                    ConsumerID = consumers.Single(s => s.LastName == "Baba").ConsumerID,
                    BookID = inventories.Single(c => c.BookTitle == "MVC Totorial #1" ).BookID,
                    ReferrenceID =1,
                    Date=DateTime.Parse("2018-01-01")
                },
                new Transaction {
                    ConsumerID = consumers.Single(s => s.LastName == "Baba").ConsumerID,
                    BookID = inventories.Single(c => c.BookTitle == "MVC Totorial #2" ).BookID,
                    ReferrenceID =10,
                    Date=DateTime.Parse("2018-02-01")
                },
                 new Transaction {
                    ConsumerID = consumers.Single(s => s.LastName == "Co").ConsumerID,
                    BookID = inventories.Single(c => c.BookTitle == "MVC Totorial #2" ).BookID,
                    ReferrenceID =2,
                     Date =DateTime.Parse("2017-05-01")
                 },
                 new Transaction {
                    ConsumerID = consumers.Single(s => s.LastName == "Flores").ConsumerID,
                    BookID = inventories.Single(c => c.BookTitle == "MVC Totorial #3" ).BookID,
                    ReferrenceID =3,
                     Date =DateTime.Parse("2016-12-11")
                 },
                 new Transaction {
                     ConsumerID = consumers.Single(s => s.LastName == "Grewal").ConsumerID,
                    BookID = inventories.Single(c => c.BookTitle == "MVC Totorial #4" ).BookID,
                    ReferrenceID =4,
                     Date =DateTime.Parse("2015-5-2")
                 },
                 new Transaction {
                     ConsumerID = consumers.Single(s => s.LastName == "Hassan").ConsumerID,
                    BookID = inventories.Single(c => c.BookTitle == "MVC Totorial #5" ).BookID,
                    ReferrenceID =5,
                    Date=DateTime.Parse("2015-5-22")
                 },
                 new Transaction {
                    ConsumerID = consumers.Single(s => s.LastName == "Montoya").ConsumerID,
                    BookID = inventories.Single(c => c.BookTitle == "MVC Totorial #5" ).BookID,
                    ReferrenceID =9,
                     Date =DateTime.Parse("2012-3-10")
                 },
                 new Transaction {
                    ConsumerID = consumers.Single(s => s.LastName == "Weng").ConsumerID,
                    BookID = inventories.Single(c => c.BookTitle == "MVC Totorial #1" ).BookID,
                    ReferrenceID=6,
                     Date =DateTime.Parse("2017-6-5")
                 }
            };

            foreach (Transaction e in transactions)
            {
                var transactionInDataBase = context.Transactions.Where(
                    s =>
                         s.Consumer.ConsumerID == e.ConsumerID &&
                         s.Inventory.BookID == e.BookID).SingleOrDefault();
                if (transactionInDataBase == null)
                {
                    context.Transactions.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}