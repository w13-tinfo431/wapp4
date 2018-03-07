namespace LibrarySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consumer",
                c => new
                    {
                        ConsumerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        Secret = c.String(),
                    })
                .PrimaryKey(t => t.ConsumerID);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        ReferrenceID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ConsumerID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReferrenceID)
                .ForeignKey("dbo.Consumer", t => t.ConsumerID, cascadeDelete: true)
                .ForeignKey("dbo.Inventory", t => t.BookID, cascadeDelete: true)
                .Index(t => t.ConsumerID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        BookID = c.Int(nullable: false),
                        BookTitle = c.String(),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "BookID", "dbo.Inventory");
            DropForeignKey("dbo.Transaction", "ConsumerID", "dbo.Consumer");
            DropIndex("dbo.Transaction", new[] { "BookID" });
            DropIndex("dbo.Transaction", new[] { "ConsumerID" });
            DropTable("dbo.Inventory");
            DropTable("dbo.Transaction");
            DropTable("dbo.Consumer");
        }
    }
}
