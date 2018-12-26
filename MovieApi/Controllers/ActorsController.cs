﻿using System.Data;
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
  
        // GET: api/Actors/5
        // Returns the actor with a specific id 
        public IHttpActionResult GetActor(int id)
        {
              
            var actor = db.Actors.Find(id);

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
            var movies = await (db.MovieCasts
                    .Join(db.Movies, mc => mc.MovieId, m => m.MovieId, (mc, m) => new {mc, m})
                    .Where(obj => obj.mc.ActorId == id)
                    .Select(obj => new {
                        MovieId = obj.m.MovieId,
                        Title = obj.m.Title,
                        Rating = obj.m.Rating,
                        Poster = obj.m.PosterUrl
                    }).ToListAsync());


            if (!movies.Any())
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(movies);
        }
    }
}