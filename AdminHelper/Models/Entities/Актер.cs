using System.Collections.Generic;

namespace AdminHelper.models.entities
{
    public partial class Актер
    {
        public Актер()
        {
            Рольs = new HashSet<Роль>();
        }

        public int Id { get; set; }
        public string Фамилия { get; set; } = null!;
        public string Имя { get; set; } = null!;
        public string Отчество { get; set; } = null!;

        public virtual ICollection<Роль> Рольs { get; set; }
    }
}
