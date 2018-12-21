namespace MovieApi.Models
{
    using MovieApi.Searchable;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Movie")]
    public partial class Movie : ISearchable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public double Rating { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string Released { get; set; }

        [JsonIgnore]
        public string searchableData
        {
            get
            {
                return Title;
            }
        }
    }
}
