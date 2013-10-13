namespace MvcSku.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTagsUnitsCollections : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagUnit",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Unit_UnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Unit_UnitId })
                .ForeignKey("dbo.Tag", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Unit", t => t.Unit_UnitId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Unit_UnitId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TagUnit", new[] { "Unit_UnitId" });
            DropIndex("dbo.TagUnit", new[] { "Tag_TagId" });
            DropForeignKey("dbo.TagUnit", "Unit_UnitId", "dbo.Unit");
            DropForeignKey("dbo.TagUnit", "Tag_TagId", "dbo.Tag");
            DropTable("dbo.TagUnit");
        }
    }
}
