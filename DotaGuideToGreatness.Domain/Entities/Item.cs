using DotaGuideToGreatness.Domain.Enums.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.Domain.Entities
{
    public class Item : BaseEntity
    {
        public string Description { get; set; }
        public ItemTier Tier { get; set; }
        public Recipe Recipe { get; set; }

    }
}
