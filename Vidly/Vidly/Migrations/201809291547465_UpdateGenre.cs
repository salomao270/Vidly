namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Genres SET GenreTypeName = 'Action' WHERE Id = 1");
            Sql("UPDATE Genres SET GenreTypeName = 'Thriller' WHERE Id = 2");
            Sql("UPDATE Genres SET GenreTypeName = 'Family' WHERE Id = 3");
            Sql("UPDATE Genres SET GenreTypeName = 'Romance' WHERE Id = 4");
            Sql("UPDATE Genres SET GenreTypeName = 'Comedy' WHERE Id = 5");

        }
        
        public override void Down()
        {
        }
    }
}
