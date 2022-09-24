using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHelper.models.entities
{
    [Table("СпектакльНаполненность")]
    public partial class SpectacleFullness
    {
        [Column("IdСпектакль")]
        public int? SpectacleId { get; set; }
        [Column("IdНаполненность")]
        public int? FullnessId { get; set; }

        public virtual Fullness? FullnessIdNavigation { get; set; }
        public virtual Spectacle? SpectacleIdNavigation { get; set; }
    }
}
