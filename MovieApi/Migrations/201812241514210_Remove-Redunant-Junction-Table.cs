namespace MovieApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRedunantJunctionTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MovieDirector1", newName: "MovieDirectors");
            DropTable("dbo.MovieDirector");
            DropTable("dbo.MovieGenre");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieGenre",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.GenreId });
            
            CreateTable(
                "dbo.MovieDirector",
                c => new
                    {
                        DirectorId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DirectorId, t.MovieId });
            
            RenameTable(name: "dbo.MovieDirectors", newName: "MovieDirector1");
        }
    }
}
