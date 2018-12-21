using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;
using MovieApi.Context;
using MovieApi.Models;


namespace MovieApi.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly MovieDbContext db = new MovieDbContext();

        // GET: api/movies
        // Returns a page of movies
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public async Task<IHttpActionResult> GetMovies(int pageNumber = 1, int pageSize = 10)
        {
            var sorted = await db.Movies.OrderBy(m => m.Title).ToListAsync();
            if (sorted == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(sorted.Skip((pageNumber - 1) * pageSize).Take(pageSize));
        }

        // GET: api/movies/5
        // Returns the movie with a specific id
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

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
                         select actor).ToListAsync();

            return Ok(actors);
        }
    }
}

