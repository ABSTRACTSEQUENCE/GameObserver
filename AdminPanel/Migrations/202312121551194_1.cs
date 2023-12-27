namespace AdminPanel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Screenshots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        game_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.game_Id)
                .Index(t => t.game_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Screenshots", "game_Id", "dbo.Games");
            DropIndex("dbo.Screenshots", new[] { "game_Id" });
            DropTable("dbo.Screenshots");
        }
    }
}
