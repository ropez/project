namespace MovieApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    // The model / database table  that connects  an actor id to a movie id, and the character the 
    // actor played.
    // Note that this model/table has a Character properties in addition to the two id's. 
    // Therefore it's not implementet as a automatically generated junction table, and
    // we have to use joins to extract data

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
