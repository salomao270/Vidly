namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES ('Hangover', '05/06/2009', '30/08/2018' 8, 5)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES ('Die Hard', '20/07/1988', '30/08/2018', 6, 1)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES ('The Terminator', '26/08/1984', '30/08/2018', 10, 1)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES ('Toy Story', '22/11/1995', '30/08/2018', 8, 3)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES ('Titanic', '19/12/1997', '30/08/2018', 10, 4)");
        }
        
        public override void Down()
        {
        }
    }
}
