using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieApi.Searchable
{
    public class RankedSearchable
    {
        public ISearchable Searchable { get; set; }
        public double Rank { get; set; }
    }
}

