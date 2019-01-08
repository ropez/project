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

    // The controller responible for handling all search queries

    public class SearchController : ApiController
    {
        private IMDbContext db = new MDbContext();

        public SearchController() { }

        public SearchController(IMDbContext db)
        {
            this.db = db;
        }

        // GET: api/search?key=&pageNum&pageSize
        // Returns a list of actors and movies that matches the search key.
        // The matches are wrapped in a RankedDTO object 1) for sorting,
        // 2) When one performs a search one often only needs some info about the
        // object, and more detailed info can be retrieved later, 3) The receiver of
        // the result has a standardized object to handle.

        /// <param name="pageSize">The requested number of matches per page</param>
        /// <param name="pageSize">The spesific page requsted</param>
        /// <returns>A Json object, empty if no match, or Bad Request</returns>
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
        

        /*
         *  A simple ranking algorithm. Calculates a ratio of the number of characters in the search key
         *  and the the number of characters in the string that matches. A full match equals 100, no match equals 0 
         */
        
        /// <param name="searchAble">An object implementing the Isearchable interface</param>
        /// <param name="pageSize">The search key</param>
        /// <returns>A ratio of the number of characters in the seacrh key and in the match.</returns>
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
