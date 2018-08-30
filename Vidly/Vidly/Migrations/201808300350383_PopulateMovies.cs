namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (2, 'Thriller')");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (3, 'Family')");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (4, 'Romance')");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (5, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
