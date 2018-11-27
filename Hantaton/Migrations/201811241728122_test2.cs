namespace Hantaton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "AnalogousProduct_Id", "dbo.AnalogousProduct");
            DropIndex("dbo.Product", new[] { "AnalogousProduct_Id" });
            RenameColumn(table: "dbo.Product", name: "AnalogousProduct_Id", newName: "AnalogousProductId");
            AlterColumn("dbo.Product", "AnalogousProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "AnalogousProductId");
            AddForeignKey("dbo.Product", "AnalogousProductId", "dbo.AnalogousProduct", "Id", cascadeDelete: true);
            DropColumn("dbo.AnalogousProduct", "ProductId");
            DropColumn("dbo.Product", "APId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "APId", c => c.Int(nullable: false));
            AddColumn("dbo.AnalogousProduct", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Product", "AnalogousProductId", "dbo.AnalogousProduct");
            DropIndex("dbo.Product", new[] { "AnalogousProductId" });
            AlterColumn("dbo.Product", "AnalogousProductId", c => c.Int());
            RenameColumn(table: "dbo.Product", name: "AnalogousProductId", newName: "AnalogousProduct_Id");
            CreateIndex("dbo.Product", "AnalogousProduct_Id");
            AddForeignKey("dbo.Product", "AnalogousProduct_Id", "dbo.AnalogousProduct", "Id");
        }
    }
}
