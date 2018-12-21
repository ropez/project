namespace MovieApi.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Genre")]
    public partial class Genre 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenreId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
