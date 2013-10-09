namespace MvcSku.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        ManufacturerId = c.Int(nullable: false, identity: true),
                        ManufacturerName = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        UnitId = c.Int(nullable: false, identity: true),
                        UnitName = c.String(),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Depth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Manufacturer_ManufacturerId = c.Int(),
                    })
                .PrimaryKey(t => t.UnitId)
                .ForeignKey("dbo.Manufacturer", t => t.Manufacturer_ManufacturerId)
                .Index(t => t.Manufacturer_ManufacturerId);
            
            CreateTable(
                "dbo.Tagging",
                c => new
                    {
                        TaggingId = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaggingId)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagKey = c.String(),
                        TagValue = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tagging", new[] { "UnitId" });
            DropIndex("dbo.Tagging", new[] { "TagId" });
            DropIndex("dbo.Unit", new[] { "Manufacturer_ManufacturerId" });
            DropForeignKey("dbo.Tagging", "UnitId", "dbo.Unit");
            DropForeignKey("dbo.Tagging", "TagId", "dbo.Tag");
            DropForeignKey("dbo.Unit", "Manufacturer_ManufacturerId", "dbo.Manufacturer");
            DropTable("dbo.Tag");
            DropTable("dbo.Tagging");
            DropTable("dbo.Unit");
            DropTable("dbo.Manufacturer");
        }
    }
}
