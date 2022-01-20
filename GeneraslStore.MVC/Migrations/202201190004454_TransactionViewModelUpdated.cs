namespace GeneraslStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionViewModelUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionViewModels",
                c => new
                    {
                        TransactionViewID = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionViewID);
            
            AddColumn("dbo.Products", "TransactionViewModel_TransactionViewID", c => c.Int());
            CreateIndex("dbo.Products", "TransactionViewModel_TransactionViewID");
            AddForeignKey("dbo.Products", "TransactionViewModel_TransactionViewID", "dbo.TransactionViewModels", "TransactionViewID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "TransactionViewModel_TransactionViewID", "dbo.TransactionViewModels");
            DropIndex("dbo.Products", new[] { "TransactionViewModel_TransactionViewID" });
            DropColumn("dbo.Products", "TransactionViewModel_TransactionViewID");
            DropTable("dbo.TransactionViewModels");
        }
    }
}
