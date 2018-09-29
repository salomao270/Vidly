namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genremodelupdatedapropertyname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "GenreTypeName", c => c.String());
            DropColumn("dbo.Genres", "GenreType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "GenreType", c => c.String());
            DropColumn("dbo.Genres", "GenreTypeName");
        }
    }
}
