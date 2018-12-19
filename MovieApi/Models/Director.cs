namespace MovieApi
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Director")]
    public partial class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DirectorId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
