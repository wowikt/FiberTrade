namespace FifteenGameCodeFirstRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CurrentGames", "GameTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CurrentGames", "GameTime");
        }
    }
}
