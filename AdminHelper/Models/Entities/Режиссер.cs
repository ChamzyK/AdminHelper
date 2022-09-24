using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHelper.models.entities
{
    [Table("Режиссер")]
    public partial class Director
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Фамилия")]
        public string LastName { get; set; } = null!;
        [Column("Имя")]
        public string FirstName { get; set; } = null!;
        [Column("Отчество")]
        public string Patronymic { get; set; } = null!;
    }
}
