namespace MvcSku.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedTaggings : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tagging", "TagId", "dbo.Tag");
            DropForeignKey("dbo.Tagging", "UnitId", "dbo.Unit");
            DropIndex("dbo.Tagging", new[] { "TagId" });
            DropIndex("dbo.Tagging", new[] { "UnitId" });
            DropTable("dbo.Tagging");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tagging",
                c => new
                    {
                        TaggingId = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaggingId);
            
            CreateIndex("dbo.Tagging", "UnitId");
            CreateIndex("dbo.Tagging", "TagId");
            AddForeignKey("dbo.Tagging", "UnitId", "dbo.Unit", "UnitId", cascadeDelete: true);
            AddForeignKey("dbo.Tagging", "TagId", "dbo.Tag", "TagId", cascadeDelete: true);
        }
    }
}
