using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHelper.models.entities
{
    [Table("Жанр")]
    public partial class Genre
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Жанр")]
        public string GenreName { get; set; } = null!;
    }
}
