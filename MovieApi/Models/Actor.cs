namespace MovieApi.Models
{
    using MovieApi.Searchable;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Actor : ISearchable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ActorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeathDate { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [JsonIgnore]
        [NotMapped]
        public string SearchableData
        {
            get
            {
                return Name;
            }
        }
        
    }
}
