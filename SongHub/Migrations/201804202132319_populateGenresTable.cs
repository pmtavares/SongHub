namespace SongHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into genres (Id, Name) VALUES (1, 'Jazz')");
            Sql("Insert into genres (Id, Name) VALUES (2, 'Blues')");
            Sql("Insert into genres (Id, Name) VALUES (3, 'Rock')");
            Sql("Insert into genres (Id, Name) VALUES (4, 'Country')");

        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres where id in(1,2,3,4)");
        }
    }
}
