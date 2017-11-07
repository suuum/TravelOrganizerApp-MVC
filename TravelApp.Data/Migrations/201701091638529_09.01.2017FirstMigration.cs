namespace TravelApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09012017FirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attraction", "OpenHours", c => c.String());
            AddColumn("dbo.Attraction", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attraction", "Cost");
            DropColumn("dbo.Attraction", "OpenHours");
        }
    }
}
