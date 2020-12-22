﻿namespace FifteenGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataModelCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrentGameCells",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CellIndex = c.Int(nullable: false),
                        CellValue = c.Int(nullable: false),
                        CurrentGame_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CurrentGames", t => t.CurrentGame_Id)
                .Index(t => t.CurrentGame_Id);
            
            CreateTable(
                "dbo.CurrentGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameStartTime = c.DateTime(nullable: false),
                        GameTime = c.Time(nullable: false, precision: 7),
                        MoveCount = c.Int(nullable: false),
                        Comment = c.String(),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.FinishedGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameFinishDate = c.DateTime(nullable: false),
                        MoveCount = c.Int(nullable: false),
                        GameTime = c.Time(precision: 7),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinishedGames", "User_Id", "dbo.AbpUsers");
            DropForeignKey("dbo.CurrentGames", "User_Id", "dbo.AbpUsers");
            DropForeignKey("dbo.CurrentGameCells", "CurrentGame_Id", "dbo.CurrentGames");
            DropIndex("dbo.FinishedGames", new[] { "User_Id" });
            DropIndex("dbo.CurrentGames", new[] { "User_Id" });
            DropIndex("dbo.CurrentGameCells", new[] { "CurrentGame_Id" });
            DropTable("dbo.FinishedGames");
            DropTable("dbo.CurrentGames");
            DropTable("dbo.CurrentGameCells");
        }
    }
}
