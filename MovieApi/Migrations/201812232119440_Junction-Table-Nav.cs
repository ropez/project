namespace MovieApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JunctionTableNav : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieDirector1",
                c => new
                    {
                        Movie_MovieId = c.Int(nullable: false),
                        Director_DirectorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_MovieId, t.Director_DirectorId })
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Directors", t => t.Director_DirectorId, cascadeDelete: true)
                .Index(t => t.Movie_MovieId)
                .Index(t => t.Director_DirectorId);
            
            CreateTable(
                "dbo.GenreMovies",
                c => new
                    {
                        Genre_GenreId = c.Int(nullable: false),
                        Movie_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_GenreId, t.Movie_MovieId })
                .ForeignKey("dbo.Genres", t => t.Genre_GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId, cascadeDelete: true)
                .Index(t => t.Genre_GenreId)
                .Index(t => t.Movie_MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GenreMovies", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.GenreMovies", "Genre_GenreId", "dbo.Genres");
            DropForeignKey("dbo.MovieDirector1", "Director_DirectorId", "dbo.Directors");
            DropForeignKey("dbo.MovieDirector1", "Movie_MovieId", "dbo.Movies");
            DropIndex("dbo.GenreMovies", new[] { "Movie_MovieId" });
            DropIndex("dbo.GenreMovies", new[] { "Genre_GenreId" });
            DropIndex("dbo.MovieDirector1", new[] { "Director_DirectorId" });
            DropIndex("dbo.MovieDirector1", new[] { "Movie_MovieId" });
            DropTable("dbo.GenreMovies");
            DropTable("dbo.MovieDirector1");
        }
    }
}
