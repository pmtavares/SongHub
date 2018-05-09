namespace SongHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsCanceledGig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gigs", "IsCanceled");
        }
    }
}
