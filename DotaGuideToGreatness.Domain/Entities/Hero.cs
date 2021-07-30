using DotaGuideToGreatness.Domain.Enums.Hero;
using System.Collections.Generic;

namespace DotaGuideToGreatness.Domain.Entities
{
    public class Hero : BaseEntity
    {
        public  Attributes MainAttribute { get; set; }

        public int MaxHealth { get; set; }
        public int MaxMana { get; set; }
        public int StartingHealth { get; set; }
        public int StartingMana { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }

        public double StrengthGain { get; set; }
        public double AgilityGain { get; set; }
        public double IntelligenceGain { get; set; }

        public List<Spell> Spells { get; set; }

        //public List<Item> Inventory { get; set; }
    }
}
