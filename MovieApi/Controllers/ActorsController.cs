using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using WebApi.OutputCache.V2;
using MovieApi.Models;
using MovieApi.Context;
using System.Collections.Generic;

namespace MovieApi.Controllers
    
{
    public class ActorsController : ApiController
    {
        private readonly MovieDbContext db = new MovieDbContext();

        // GET: api/Actors
        // Returns a page of actors
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public async Task<IHttpActionResult> GetActors(int pageNumber=1, int pageSize=10)
        {
            var sorted = await db.Actors.OrderBy(a => a.Name).ToListAsync();
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
        public async Task<IHttpActionResult> GetMovies(int id)
        {
            var movies = await(from movie in db.Movies
                         join actor in db.MovieCasts on movie.MovieId equals actor.MovieId
                         where actor.ActorId == id
                         select movie).ToListAsync();

            return Ok(movies);
        }

       
    }
}