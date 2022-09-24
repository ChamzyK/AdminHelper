namespace AdminHelper.models.entities
{
    public partial class СпектакльЖанр
    {
        public int? IdСпектакль { get; set; }
        public int? IdЖанр { get; set; }

        public virtual Жанр? IdЖанрNavigation { get; set; }
        public virtual Спектакль? IdСпектакльNavigation { get; set; }
    }
}
