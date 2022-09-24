using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHelper.models.entities
{
    [Table("Роль")]
    public partial class Role
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Название")]
        public int? Name { get; set; }
        [Column("IdСпектакль")]
        public int? SpectacleId { get; set; }
        [Column("IdАктер")]
        public int? ActorId { get; set; }
        [Column("Ставка")]
        public int? Rate { get; set; }

        public virtual Actor? ActorIdNavigation { get; set; }
        public virtual Spectacle? SpectacleIdNavigation { get; set; }
        public virtual RoleType? NameNavigation { get; set; }
    }
}
