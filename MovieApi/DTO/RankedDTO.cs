using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieApi.DTO
{
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

