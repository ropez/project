namespace MovieApi.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MovieApi.Models;
    using MovieApi.Interfaces;

    //
    // The database context
    //
    //  The database contains the tables Actors, Movies, MovieCasts, Genres and Directors
    //  and the structur of these tables can be seen in the models folder. Two junction
    //  tables are in addition automatically generated, GenreMovies and MovieDirectors.
    //  These junction tables enables us to use navigational Linq queries between the tables. 
    //  See the method GetMovies in Movies controller for an example.
    // 

    public partial class MDbContext : DbContext, IMDbContext
    {
        public MDbContext()
            : base("name=db")
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<MovieCast> MovieCasts { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Actor>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Actor>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Director>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Genre>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MovieCast>()
                .Property(e => e.Character)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.PosterUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.BackDropUrl)
                .IsUnicode(false);
        }
    }
}
