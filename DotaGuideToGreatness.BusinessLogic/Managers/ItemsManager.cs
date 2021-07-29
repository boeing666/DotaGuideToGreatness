using DotaGuideToGreatness.BusinessLogic.Interfaces;
using DotaGuideToGreatness.DAL.Interfaces;
using DotaGuideToGreatness.Domain.Entities;

namespace DotaGuideToGreatness.BusinessLogic.Managers
{
    public class ItemsManager : IItemsManager
    {
        private readonly IRepository<Item> _itemsRepository;

        public ItemsManager(IRepository<Item> itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }




    }
}
