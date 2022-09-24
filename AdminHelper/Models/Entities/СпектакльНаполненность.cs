namespace AdminHelper.models.entities
{
    public partial class СпектакльНаполненность
    {
        public int? IdСпектакль { get; set; }
        public int? IdНаполненность { get; set; }

        public virtual Наполненность? IdНаполненностьNavigation { get; set; }
        public virtual Спектакль? IdСпектакльNavigation { get; set; }
    }
}
