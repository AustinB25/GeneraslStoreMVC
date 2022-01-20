namespace GeneraslStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionFunctionalityStarted : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            AddColumn("dbo.Products", "Transaction_TransactionId", c => c.Int());
            CreateIndex("dbo.Products", "Transaction_TransactionId");
            AddForeignKey("dbo.Products", "Transaction_TransactionId", "dbo.Transactions", "TransactionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Transaction_TransactionId", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "Transaction_TransactionId" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropColumn("dbo.Products", "Transaction_TransactionId");
            DropTable("dbo.Transactions");
        }
    }
}
