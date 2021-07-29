using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.Domain.Entities
{
    public class GainPerLevel : BaseEntity
    {
        public double StrengthGain { get; set; }
        public double AgilityGain { get; set; }
        public double IntelligenceGain { get; set; }
    }
}
