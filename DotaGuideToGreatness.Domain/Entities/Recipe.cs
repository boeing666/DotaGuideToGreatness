using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.Domain.Entities
{
    public class Recipe : BaseEntity
    {
        public List<Item> AssambleItems { get; set; }

        [NotMapped]
        public List<long> RequiredItemsId { get; set; }

        public long ItemId { get; set; }
        public Item Item { get; set; }
    }
}
