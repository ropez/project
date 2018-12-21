namespace MovieApi.Models
{
    using MovieApi.Searchable;
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Actor")]
    public partial class Actor : ISearchable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ActorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeathDate { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        
        [JsonIgnore]
        public string searchableData
        {
            get
            {
                return Name;
            }
        }
    }
}
