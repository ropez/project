using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieApi.Searchable
{
    public class RankedDTO
    {
        public string Type { get; set; }

        public int Rank { get; set; }

        public string Key { get; set; }

        public int Id { get; set; }
    }
}

