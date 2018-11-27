namespace Hantaton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnalogousProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name1 = c.String(),
                        Composition1 = c.String(),
                        Mass1 = c.String(),
                        Name2 = c.String(),
                        Composition2 = c.String(),
                        Mass2 = c.String(),
                        Name3 = c.String(),
                        Composition3 = c.String(),
                        Mass3 = c.String(),
                        Name4 = c.String(),
                        Composition4 = c.String(),
                        Mass4 = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Composition = c.String(),
                        Price = c.String(),
                        Mass = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drugstore",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        OpeningTime = c.Int(nullable: false),
                        ClosingTime = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        DopInform = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DrugstoresProducts",
                c => new
                    {
                        DrugstoreId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DrugstoreId, t.ProductId })
                .ForeignKey("dbo.Drugstore", t => t.DrugstoreId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.DrugstoreId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DrugstoresProducts", "ProductId", "dbo.Product");
            DropForeignKey("dbo.DrugstoresProducts", "DrugstoreId", "dbo.Drugstore");
            DropForeignKey("dbo.Drugstore", "CityId", "dbo.City");
            DropForeignKey("dbo.AnalogousProduct", "ProductId", "dbo.Product");
            DropIndex("dbo.DrugstoresProducts", new[] { "ProductId" });
            DropIndex("dbo.DrugstoresProducts", new[] { "DrugstoreId" });
            DropIndex("dbo.Drugstore", new[] { "CityId" });
            DropIndex("dbo.AnalogousProduct", new[] { "ProductId" });
            DropTable("dbo.DrugstoresProducts");
            DropTable("dbo.City");
            DropTable("dbo.Drugstore");
            DropTable("dbo.Product");
            DropTable("dbo.AnalogousProduct");
        }
    }
}
