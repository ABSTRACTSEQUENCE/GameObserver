namespace AdminPanel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fav : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsersGames",
                c => new
                    {
                        Users_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Users_Id, t.Game_Id })
                .ForeignKey("dbo.Users", t => t.Users_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.Users_Id)
                .Index(t => t.Game_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.UsersGames", "Users_Id", "dbo.Users");
            DropIndex("dbo.UsersGames", new[] { "Game_Id" });
            DropIndex("dbo.UsersGames", new[] { "Users_Id" });
            DropTable("dbo.UsersGames");
        }
    }
}
