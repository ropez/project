using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;
using MovieApi.Context;
using MovieApi.Models;
using MovieApi.Interfaces;
using System.Collections.Generic;
using MovieApi.DTOs;

namespace MovieApi.Controllers
{
    public class MoviesController : ApiController
    {
        private IMDbContext db = new MDbContext();

        public MoviesController() { }

        public MoviesController(IMDbContext db)
        {
            this.db = db;
        }

        // GET: api/movies/5
        // Returns the movie with a specific id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = db.Movies
                    .Where(m => m.MovieId == id)
                    .Select(m => new {
                         MovieId = m.MovieId,
                         Title = m.Title,
                         Description = m.Description,
                         Rating = m.Rating,
                         PosterUrl = m.PosterUrl,
                         Released = m.Released,
                         BackDropUrl = m.BackDropUrl,
                         Genres = m.Genres.Select(g => g.Name),
                         Directors = m.Directors.Select(d => d.Name),
                     });
       
            return Ok(movie);
        }

        // GET: api/movies/credits/id
        // Returns the actors which contributed to the movie with a given id
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        [Route("api/movies/{id}/credits")]
        public async Task<IHttpActionResult> GetActors(int id)
        {
            var actors = await (from actor in db.Actors
                                join movie in db.MovieCasts on actor.ActorId equals movie.ActorId
                                where movie.MovieId == id
                                select new DTO {
                                    Type = "actor",
                                    Id = actor.ActorId,
                                    Key = actor.Name,
                                    Img = actor.ImageUrl,
                                    Date = actor.BirthDate
                                }).ToListAsync();

            return Ok(actors);
        }

        // GET: api/movies?pageNum=&pageSize=
        // Returns the n top rated movies
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        [HttpGet]
        [Route("api/movies/popular")]
        public async Task<IHttpActionResult> GetPopular(int pageSize=20, int pageNum=1)
        { 
            var movies = await db.Movies
                        .OrderByDescending(m => m.Rating)
                        .Select(m => new {
                              MovieId = m.MovieId,
                              Title = m.Title,
                              Rating = m.Rating,
                              PosterUrl = m.PosterUrl,
                         })
                        .ToListAsync();

            var totalCount = movies.Count();
            var page = movies.Skip((pageNum - 1) * pageSize).Take(pageSize);
           
            return Ok(new { Count = totalCount , Page = page });
        }
    }
}

