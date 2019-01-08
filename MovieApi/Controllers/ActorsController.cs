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
using System.Web.Http.Description;
using MovieApi.Interfaces;


/*
 *  The controller that handles all requests for actor information.
 */

namespace MovieApi.Controllers
    
{
    public class ActorsController : ApiController
    {
        private IMDbContext db = new MDbContext();
        
        public ActorsController() { }

        public ActorsController(IMDbContext db)
        {
            this.db = db;
        }
  
        /*  GET: api/Actors/id
        *   Returns the actor with a specific id
        *   If no actor is found at that id status code 204 id returned
        *
        *   The result of the query is cached at the server end, and 
        *   a max-age in the respnse header is sendt to the client
        */

        /// <param name="id">The id of the actor</param>
        /// <returns>A Json object or status code 204</returns>
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public IHttpActionResult GetActor(int id)
        {
              
            var actor = db.Actors.Find(id);

            if (actor == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(actor);
        }
       
        /*  GET: api/Actors/id/credits
         *  Returns the movies the actor with a specific id has starred in
         *  Returns status code 204 if no movies are found.
         *  
         *  The result of the query is cached at the server end, and 
         *  a max-age in the respnse header is sendt to the client
         *
         */

        /// <param name="id">The id of the actor</param>
        /// <returns>A Json object or status code 204</returns>
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        [Route("api/actors/{id}/credits")]
        public async Task<IHttpActionResult> GetMovies(int id)
        { 
            var movies = await (db.MovieCasts
                    .Join(db.Movies, mc => mc.MovieId, m => m.MovieId, (mc, m) => new {mc, m})
                    .Where(obj => obj.mc.ActorId == id)
                    .Select(obj => new {
                        Id = obj.m.MovieId,
                        Key = obj.m.Title,
                        Img = obj.m.PosterUrl,
                        Date = obj.m.Released
                    }).ToListAsync());

            if (!movies.Any()) {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(movies);
        }
    }
}