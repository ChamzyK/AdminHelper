using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHelper.models.entities
{
    [Table("СпектакльЖанр")]
    public partial class SpectacleGenre
    {
        [Column("IdСпектакль")]
        public int? SpectacleId { get; set; }
        [Column("IdЖанр")]
        public int? GenreId { get; set; }

        public virtual Genre? GenreIdNavigation { get; set; }
        public virtual Spectacle? SpectacleIdNavigation { get; set; }
    }
}
