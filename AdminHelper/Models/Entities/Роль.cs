namespace AdminHelper.models.entities
{
    public partial class Роль
    {
        public int Id { get; set; }
        public int? Название { get; set; }
        public int? IdСпектакль { get; set; }
        public int? IdАктер { get; set; }
        public int? Ставка { get; set; }

        public virtual Актер? IdАктерNavigation { get; set; }
        public virtual Спектакль? IdСпектакльNavigation { get; set; }
        public virtual ТипРоли? НазваниеNavigation { get; set; }
    }
}
