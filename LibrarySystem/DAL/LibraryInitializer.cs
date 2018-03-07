using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LibrarySystem.Models;

namespace LibrarySystem.DAL
{
    public class LibraryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            var consumers = new List<Consumer>
            {
                new Consumer{FirstName="Chris",LastName = "Flores",RegisterDate=DateTime.Parse("2012-01-01")},
                new Consumer{FirstName="Harkaran",LastName="Grewal",RegisterDate=DateTime.Parse("2013-02-02")},
                new Consumer{FirstName="Amin",LastName="Hassan",RegisterDate=DateTime.Parse("2014-03-03")},
                new Consumer{FirstName="Yi",LastName="Weng",RegisterDate=DateTime.Parse("2015-04-04")},
                new Consumer{FirstName="Sebastian",LastName="Baba",RegisterDate=DateTime.Parse("2015-05-05")},
                new Consumer{FirstName="Christine",LastName="Co",RegisterDate=DateTime.Parse("2016-06-06")},
                new Consumer{FirstName="Armando",LastName="Montoya",RegisterDate=DateTime.Parse("2018-07-07")},
            };
            consumers.ForEach(s => context.Consumers.Add(s));
            context.SaveChanges();
            var inventories = new List<Inventory>
            {
                new Inventory{BookID=0001,BookTitle="MVC Totorial #1",Price="$49.99"},
                new Inventory{BookID=0002,BookTitle="MVC Totorial #2",Price="$69.99"},
                new Inventory{BookID=0003,BookTitle="MVC Totorial #3",Price="$89.99"},
                new Inventory{BookID=0004,BookTitle="MVC Totorial #4",Price="$99.99"},
                new Inventory{BookID=0005,BookTitle="MVC Totorial #5",Price="$109.99"},
                new Inventory{BookID=0006,BookTitle="MVC Totorial #6",Price="$119.99"},
            };
            inventories.ForEach(s => context.Inventories.Add(s));
            context.SaveChanges();
            var transactions = new List<Transaction>
            {
                new Transaction{ReferrenceID=1000,Date=DateTime.Parse("2018-01-01"),ConsumerID=1,BookID=0001},
                new Transaction{ReferrenceID=1001,Date=DateTime.Parse("2018-02-01"),ConsumerID=2, BookID=0002},
                new Transaction{ReferrenceID=1002,Date=DateTime.Parse("2017-05-01"),ConsumerID=3, BookID=0002},
                new Transaction{ReferrenceID=2000,Date=DateTime.Parse("2016-12-11"),ConsumerID=4, BookID=0004},
                new Transaction{ReferrenceID=3000,Date=DateTime.Parse("2015-5-2"),ConsumerID=5, BookID=0004},
            };
            transactions.ForEach(s => context.Transactions.Add(s));
            context.SaveChanges();
        }
    }
}