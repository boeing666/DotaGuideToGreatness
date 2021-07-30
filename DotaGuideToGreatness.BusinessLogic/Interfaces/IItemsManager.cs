using DotaGuideToGreatness.Domain;
using DotaGuideToGreatness.Domain.Entities;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.BusinessLogic.Interfaces
{
    public interface IItemsManager
    {
        Task<Result<Item>> GetItemById(long id);
        Task<Result<Item>> AddNewItem(Item item);
    }
}
