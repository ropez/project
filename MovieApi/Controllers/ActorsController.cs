using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Routing;
using WebApi.OutputCache.V2;

namespace MovieApi.Controllers

/*
 * Async await?
 */
{
    public class ActorsController : ApiController
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: api/Actors
        // Returns a page of actors
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public IHttpActionResult GetActors(int pageNumber=1, int pageSize=10)
        {
            var sorted = db.Actors.OrderBy(a => a.Name);
            if(sorted == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(sorted.Skip((pageNumber - 1) * pageSize).Take(pageSize));
        }

        // GET: api/Actors/5
        // Returns the actor with a specific id
        public IHttpActionResult GetActor(int id)
        {
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(actor);
        }

        // GET: api/Actors/Credits/id
        // Returns the movies the actor with a specific id has starred in
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        [Route("api/actors/{id}/credits")]
        public IHttpActionResult GetMovies(int id)
        {
            var movies = from movie in db.Movies
                         join actor in db.MovieCasts on movie.MovieId equals actor.MovieId
                         where actor.ActorId == id
                         select movie;

            return Ok(movies);
        }

        // GET: api/actors?search=
        // Returns actors which name starts or matches with the query string
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        [HttpGet]
        public IHttpActionResult Query(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return BadRequest("Unvalid search string");
            }

            return Ok(db.Actors.Where(a => a.Name.Contains(search)));
            
        }
    }
}