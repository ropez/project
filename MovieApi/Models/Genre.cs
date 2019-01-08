namespace MovieApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;



    // The database table/model connecting a genre id to a genre name
    //
    // The GenreMovie junction table connects a movie to a genre(s)
    //

    public partial class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenreId { get; set; }

        [Required]
        public string Name { get; set; }
        
        public ICollection<Movie> Movies { get; set; }
    }
}
