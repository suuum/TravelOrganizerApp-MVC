namespace TravelApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationV2_27122016 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TripPlan", "GuidId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TripPlan", "GuidId");
        }
    }
}
