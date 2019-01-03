﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApi.DTOs
{
    public class DTO
    {
        public string Type { get; set; }

        public string Key { get; set; }

        public int Id { get; set; }

        public string Img { get; set; }

        public DateTime? Date { get; set; }
    }
}