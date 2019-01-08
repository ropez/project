namespace MovieApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    // The database table/model for a Director. 
    // The table is used to bind a director id to a name.
    //
    // The MovieDirector junction table connects a director id
    // a movie(s)
    //
    // If one wanted to make Directos searchable he Could just implement 
    // the ISeacrhAble interface

    public partial class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DirectorId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
