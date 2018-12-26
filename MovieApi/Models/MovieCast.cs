namespace MovieApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MovieCast")]
    public partial class MovieCast
    {
        [Key, Column(Order = 0)]
        public int ActorId { get; set; }

        [Key, Column(Order = 1)]
        public int MovieId { get; set; }

        [Required]
        public string Character { get; set; }

    }
}
