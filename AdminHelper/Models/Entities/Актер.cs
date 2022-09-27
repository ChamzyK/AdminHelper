using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHelper.models.entities
{
    //TODO: 12
    //Явно указали к какой таблице соответствует этот класс и его столбцы
    [Table("Актер")]
    public partial class Actor
    {
        public Actor()
        {
            Roles = new HashSet<Role>();
        }

        [Column("Id")]
        public int Id { get; set; }
        [Column("Фамилия")]
        public string LastName { get; set; } = null!;
        [Column("Имя")]
        public string FirstName { get; set; } = null!;
        [Column("Отчество")]
        public string Patronymic { get; set; } = null!;

        [Column("Роль")]
        public virtual ICollection<Role> Roles { get; set; }

        [NotMapped]
        public int Salary { get; set; }

        public override string ToString() => $"{LastName} {FirstName} {Patronymic}";
    }
}
