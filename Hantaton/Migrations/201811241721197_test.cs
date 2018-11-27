namespace Hantaton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnalogousProduct", "ProductId", "dbo.Product");
            DropIndex("dbo.AnalogousProduct", new[] { "ProductId" });
            AddColumn("dbo.Product", "APId", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "AnalogousProduct_Id", c => c.Int());
            CreateIndex("dbo.Product", "AnalogousProduct_Id");
            AddForeignKey("dbo.Product", "AnalogousProduct_Id", "dbo.AnalogousProduct", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "AnalogousProduct_Id", "dbo.AnalogousProduct");
            DropIndex("dbo.Product", new[] { "AnalogousProduct_Id" });
            DropColumn("dbo.Product", "AnalogousProduct_Id");
            DropColumn("dbo.Product", "APId");
            CreateIndex("dbo.AnalogousProduct", "ProductId");
            AddForeignKey("dbo.AnalogousProduct", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
        }
    }
}
