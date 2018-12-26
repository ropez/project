namespace MovieApi.Models
{
    using MovieApi.Searchable;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Movie : ISearchable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public double Rating { get; set; }

        public string PosterUrl { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Released { get; set; }

        public string BackDropUrl { get; set; }
        
        public ICollection<Genre> Genres { get; set; }
        
        public ICollection<Director> Directors { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string SearchableData
        {
            get
            {
                return Title;
            }
        }
    }
}
