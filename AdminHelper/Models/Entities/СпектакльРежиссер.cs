using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHelper.models.entities
{
    [Table("СпектакльРежиссер")]
    public partial class SpectacleDirector
    {
        [Column("IdСпектакль")]
        public int? SpectacleId { get; set; }
        [Column("IdРежиссер")]
        public int? DirectorId { get; set; }

        public virtual Director? DirectorIdNavigation { get; set; }
        public virtual Spectacle? SpectacleIdNavigation { get; set; }
    }
}
