using System.ComponentModel.DataAnnotations.Schema;

namespace AdminHelper.models.entities
{
    [Table("Наполненность")]
    public partial class Fullness
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Наполненность")]
        public string FullnessName { get; set; } = null!;
        [Column("Надбавка")]
        public int Allowance { get; set; }
    }
}
