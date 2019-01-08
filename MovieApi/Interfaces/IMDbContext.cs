using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieApi.Interfaces
{

    // An interface that the DbContext can implement to enable mocking
    public interface IMDbContext
    {
        DbSet<Actor> Actors { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<MovieCast> MovieCasts { get; set; }
        DbSet<Movie> Movies { get; set; }
    }
}