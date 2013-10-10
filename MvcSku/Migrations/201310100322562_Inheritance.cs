namespace MvcSku.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inheritance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Unit", "Radius", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Unit", "EdgeRadius", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Unit", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Manufacturer", "ManufacturerName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Unit", "UnitName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Tag", "TagKey", c => c.String(maxLength: 50));
            AlterColumn("dbo.Tag", "TagValue", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tag", "TagValue", c => c.String());
            AlterColumn("dbo.Tag", "TagKey", c => c.String());
            AlterColumn("dbo.Unit", "UnitName", c => c.String());
            AlterColumn("dbo.Manufacturer", "ManufacturerName", c => c.String());
            DropColumn("dbo.Unit", "Discriminator");
            DropColumn("dbo.Unit", "EdgeRadius");
            DropColumn("dbo.Unit", "Radius");
        }
    }
}
