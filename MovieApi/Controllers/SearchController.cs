using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MovieApi.Context;
using MovieApi.DTO;
using MovieApi.Interfaces;
using MovieApi.Models;
using MovieApi.Searchable;
using WebApi.OutputCache.V2;

namespace MovieApi.Controllers
{
    public class SearchController : ApiController
    {
        private IMDbContext db = new MDbContext();

        public SearchController() { }

        public SearchController(IMDbContext db)
        {
            this.db = db;
        }

        // GET: api/search
        // Returns a page of movies
        [HttpGet]
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public async Task<IHttpActionResult> Search(string key, int pageNum=1, int pageSize=20)
        {

            if (string.IsNullOrWhiteSpace(key) || key.Length <= 0)
            {
                return BadRequest("Unvalid search key");
            }

            var actorResult = (await db.Actors.ToListAsync())
                            .Select(a => new RankedDTO() {
                                Type = "actor",
                                Id = a.ActorId,
                                Rank = CalcRank(a, key),
                                Key = a.SearchableData,
                                Img = a.ImageUrl,
                                Date = a.BirthDate
                            }) 
                            .Where(obj => obj.Rank > 0);

            var movieResult = (await db.Movies.ToListAsync())
                            .Select(m => new RankedDTO() {
                                Type = "movie",
                                Id = m.MovieId,
                                Rank = CalcRank(m, key),
                                Key = m.SearchableData,
                                Img = m.PosterUrl,
                                Date = m.Released,

                            })
                            .Where(obj => obj.Rank > 0);
            
            var result = actorResult.Concat(movieResult);
            var orderedResult = result.OrderByDescending(obj => obj.Rank);
            var totalMatches = orderedResult.Count();
            var page = orderedResult.Skip((pageNum - 1) * pageSize).Take(pageSize);
      
            return Ok(new { Count = totalMatches, Page = page });
        }
        
        public static int CalcRank(ISearchable searchable, string query)
        { 
            int rank = 0;

            if(query.Length == 0)
            {
                return rank;
            }

            if (searchable.SearchableData.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                rank = (int) ((double)query.Length / searchable.SearchableData.Length * 100);
            }
            return rank;
        }  
    }
}
