namespace Hantaton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "AnalogousProductId", "dbo.AnalogousProduct");
            DropIndex("dbo.Product", new[] { "AnalogousProductId" });
            AddColumn("dbo.Product", "AnalogousName_1", c => c.String());
            AddColumn("dbo.Product", "AnalogousName_2", c => c.String());
            AddColumn("dbo.Product", "AnalogousName_3", c => c.String());
            AddColumn("dbo.Product", "AnalogousName_4", c => c.String());
            DropColumn("dbo.Product", "AnalogousProductId");
            DropTable("dbo.AnalogousProduct");
        }
        
        public override void Down()
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
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Product", "AnalogousProductId", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "AnalogousName_4");
            DropColumn("dbo.Product", "AnalogousName_3");
            DropColumn("dbo.Product", "AnalogousName_2");
            DropColumn("dbo.Product", "AnalogousName_1");
            CreateIndex("dbo.Product", "AnalogousProductId");
            AddForeignKey("dbo.Product", "AnalogousProductId", "dbo.AnalogousProduct", "Id", cascadeDelete: true);
        }
    }
}
