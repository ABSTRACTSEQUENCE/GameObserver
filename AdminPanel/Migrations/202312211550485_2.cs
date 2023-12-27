namespace AdminPanel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Screenshots", "Game_Id", "dbo.Games");
            DropIndex("dbo.Screenshots", new[] { "Game_Id" });
            AlterColumn("dbo.Screenshots", "Game_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Screenshots", "Game_Id");
            AddForeignKey("dbo.Screenshots", "Game_Id", "dbo.Games", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Screenshots", "Game_Id", "dbo.Games");
            DropIndex("dbo.Screenshots", new[] { "Game_Id" });
            AlterColumn("dbo.Screenshots", "Game_Id", c => c.Int());
            CreateIndex("dbo.Screenshots", "Game_Id");
            AddForeignKey("dbo.Screenshots", "Game_Id", "dbo.Games", "Id");
        }
    }
}
