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

namespace MovieApi.Controllers
{

    // The controller responible for handling all request about movie details

    public class MoviesController : ApiController
    {
        private IMDbContext db = new MDbContext();

        public MoviesController() { }

        public MoviesController(IMDbContext db)
        {
            this.db = db;
        }

        /*  GET: api/movies/id
        *   Returns the movie with a specific id
        *   If no movie is found at that id status code 204 id returned
        *
        *   The result of the query is cached at the server end, and 
        *   a max-age in the respnse header is sendt to the client
        */
        
        /// <param name="id">The id of the movie</param>
        /// <returns>A Json object or status code 204</returns>
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
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

            if (!movie.Any())
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(movie);
        }

        /*  GET: api/movies/id/credits
        *   Returns the movies an actor has contributed to
        *   If no movies are found status code 204 id returned
        *
        *   The result of the query is cached at the server end, and 
        *   a max-age in the respnse header is sendt to the client
        */

        /// <param name="id">The id of the movie</param>
        /// <returns>A Json object or status code 204</returns>
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        [Route("api/movies/{id}/credits")]
        public async Task<IHttpActionResult> GetActors(int id)
        {
            var actors = await (from actor in db.Actors
                                join movie in db.MovieCasts on actor.ActorId equals movie.ActorId
                                where movie.MovieId == id
                                select new {
                                    Id = actor.ActorId,
                                    Key = actor.Name,
                                    Img = actor.ImageUrl,
                                    Date = actor.BirthDate,
                                    Character = movie.Character
                                }).ToListAsync();
            if (!actors.Any())
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            

            return Ok(actors);
        }

        /* GET: api/movies/popular?pageNum=&pageSize=
        *  Returns the top rated movies in the database in descending order.
        *  Returns an empty list if none is found.
        */

        /// <param name="pageSize">The requested number of movies per page</param>
        /// <param name="pageSize">The sepesific page requsted</param>
        /// <returns>A Json object, empty if no match</returns>
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        [HttpGet]
        [Route("api/movies/popular")]
        public async Task<IHttpActionResult> GetPopular(int pageSize=20, int pageNum=1)
        { 
            var movies = await db.Movies
                        .OrderByDescending(m => m.Rating)
                        .Select(m => new {
                              Id = m.MovieId,
                              Title = m.Title,
                              Rating = m.Rating,
                              PosterUrl = m.PosterUrl,
                              Genres = m.Genres.Select(g => g.Name)
                        })
                        .ToListAsync();
            
            var page = movies.Skip((pageNum - 1) * pageSize).Take(pageSize);
           
            return Ok(page);
        }
    }
}

