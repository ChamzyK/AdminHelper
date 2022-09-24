namespace AdminHelper.models.entities
{
    public partial class Режиссер
    {
        public int Id { get; set; }
        public string Фамилия { get; set; } = null!;
        public string Имя { get; set; } = null!;
        public string Отчество { get; set; } = null!;
    }
}
