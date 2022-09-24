namespace AdminHelper.models.entities
{
    public partial class СпектакльРежиссер
    {
        public int? IdСпектакль { get; set; }
        public int? IdРежиссер { get; set; }

        public virtual Режиссер? IdРежиссерNavigation { get; set; }
        public virtual Спектакль? IdСпектакльNavigation { get; set; }
    }
}
