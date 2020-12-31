namespace FifteenGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CurrentGameCells", "CurrentGame_Id", "dbo.CurrentGames");
            DropForeignKey("dbo.CurrentGames", "User_Id", "dbo.AbpUsers");
            DropIndex("dbo.CurrentGameCells", new[] { "CurrentGame_Id" });
            DropIndex("dbo.CurrentGames", new[] { "User_Id" });
            RenameColumn(table: "dbo.CurrentGameCells", name: "CurrentGame_Id", newName: "CurrentGameId");
            RenameColumn(table: "dbo.CurrentGames", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.CurrentGameCells", "CurrentGameId", c => c.Int(nullable: false));
            AlterColumn("dbo.CurrentGames", "UserId", c => c.Long(nullable: false));
            CreateIndex("dbo.CurrentGameCells", "CurrentGameId");
            CreateIndex("dbo.CurrentGames", "UserId");
            AddForeignKey("dbo.CurrentGameCells", "CurrentGameId", "dbo.CurrentGames", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CurrentGames", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CurrentGames", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.CurrentGameCells", "CurrentGameId", "dbo.CurrentGames");
            DropIndex("dbo.CurrentGames", new[] { "UserId" });
            DropIndex("dbo.CurrentGameCells", new[] { "CurrentGameId" });
            AlterColumn("dbo.CurrentGames", "UserId", c => c.Long());
            AlterColumn("dbo.CurrentGameCells", "CurrentGameId", c => c.Int());
            RenameColumn(table: "dbo.CurrentGames", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.CurrentGameCells", name: "CurrentGameId", newName: "CurrentGame_Id");
            CreateIndex("dbo.CurrentGames", "User_Id");
            CreateIndex("dbo.CurrentGameCells", "CurrentGame_Id");
            AddForeignKey("dbo.CurrentGames", "User_Id", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.CurrentGameCells", "CurrentGame_Id", "dbo.CurrentGames", "Id");
        }
    }
}
