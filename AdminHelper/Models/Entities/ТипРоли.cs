using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHelper.models.entities
{
    [Table("ТипРоли")]
    public partial class RoleType
    {
        public RoleType()
        {
            Roles = new HashSet<Role>();
        }

        [Column("Id")]
        public int Id { get; set; }
        [Column("Название")]
        public string Name { get; set; } = null!;

        public virtual ICollection<Role> Roles { get; set; }

        public override string ToString() => Name;
    }
}
