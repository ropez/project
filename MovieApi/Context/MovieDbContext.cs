namespace MovieApi
{
    using System.Data.Entity;

    public partial class MovieDbContext : DbContext
    {
        public MovieDbContext()
            : base("name=MovieDbContext")
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieCast> MovieCasts { get; set; }
        public virtual DbSet<MovieDirector> MovieDirectors { get; set; }
        public virtual DbSet<MovieGenre> MovieGenres { get; set; }

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

            modelBuilder.Entity<Movie>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Released)
                .IsUnicode(false);
        }
    }
}
