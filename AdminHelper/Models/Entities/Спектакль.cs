using System;
using System.Collections.Generic;

namespace AdminHelper.models.entities
{
    public partial class Спектакль
    {
        public Спектакль()
        {
            Рольs = new HashSet<Роль>();
        }

        public int Id { get; set; }
        public string Название { get; set; } = null!;
        public DateTime? Дата { get; set; }

        public virtual ICollection<Роль> Рольs { get; set; }
    }
}
