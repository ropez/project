namespace MovieApi.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MovieApi.Models;
    using MovieApi.Interfaces;

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
