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
using MovieApi.Searchable;
using WebApi.OutputCache.V2;

namespace MovieApi.Controllers
{
    public class SearchController : ApiController
    {

        private readonly MovieDbContext db = new MovieDbContext();


        // GET: api/search
        // Returns a page of movies
        [HttpGet]
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public async Task<IHttpActionResult> Search(string key)
        {

            if (string.IsNullOrWhiteSpace(key))
            {
                return BadRequest("Unvalid search key");
            }

            var result = (await db.Actors.ToListAsync())
                            .Select(a => new RankedSearchable() { Searchable = a, Rank = CalcRank(a, key) }) 
                            .Where(obj => obj.Rank > 0);

            
            var movieResult = (await db.Movies.ToListAsync())
                            .Select(m => new RankedSearchable() { Searchable = m, Rank = CalcRank(m, key) })
                            .Where(obj => obj.Rank > 0);

            result = result.Concat(movieResult);
            var orderedResult = result.OrderBy(obj => obj.Rank)
                                      .Select(obj => obj.Searchable);

            return Ok(orderedResult);
        }

        private static double CalcRank(ISearchable searchable, string query)
        {
            double rank = -1;
            if (searchable.searchableData.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                rank = searchable.searchableData.Length / query.Length;
            }
            return rank;
        }
    }
}
