namespace DotaGuideToGreatness.Domain.Entities
{
    public class Spell : BaseEntity
    {
        public string Description { get; set; }
        public bool Ultimate { get; set; }
        public double ManaCost { get; set; }
        public double CoolDown  { get; set; }

        public Hero Hero { get; set; }
        public long HeroId { get; set; }
    }
}
