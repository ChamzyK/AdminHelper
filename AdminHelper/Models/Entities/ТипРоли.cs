using System.Collections.Generic;

namespace AdminHelper.models.entities
{
    public partial class ТипРоли
    {
        public ТипРоли()
        {
            Рольs = new HashSet<Роль>();
        }

        public int Id { get; set; }
        public string Название { get; set; } = null!;

        public virtual ICollection<Роль> Рольs { get; set; }
    }
}
