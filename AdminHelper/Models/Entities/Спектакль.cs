using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHelper.models.entities
{
    [Table("Спектакль")]
    public partial class Spectacle
    {
        public Spectacle()
        {
            Roles = new HashSet<Role>();
        }

        [Column("Id")]
        public int Id { get; set; }
        [Column("Название")]
        public string Name { get; set; } = null!;
        [Column("Дата")]
        public DateTime? Date { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
