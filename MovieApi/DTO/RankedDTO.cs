using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieApi.DTO
{

    // A Data transfer object used when returning a search, and the receiver doesnt know the type of the returned object.
    // Includes some of the most important info about the movie or actor. 
    // Another way to construct the DTO would be { type: '', object: ..The movie/actor object }

    public class RankedDTO 
    {
        public string Type { get; set; }

        public string Key { get; set; }

        public int Id { get; set; }

        public string Img { get; set; }

        public DateTime? Date { get; set; }

        public int Rank { get; set; }
    }
}

