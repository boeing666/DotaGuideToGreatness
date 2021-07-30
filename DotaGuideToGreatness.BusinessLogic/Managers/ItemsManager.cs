using DotaGuideToGreatness.BusinessLogic.Interfaces;
using DotaGuideToGreatness.DAL.Interfaces;
using DotaGuideToGreatness.Domain;
using DotaGuideToGreatness.Domain.Entities;
using DotaGuideToGreatness.Domain.Enums;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.BusinessLogic.Managers
{
    public class ItemsManager : IItemsManager
    {
        private readonly IRepository<Item> _itemsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ItemsManager(IRepository<Item> itemsRepository, IUnitOfWork unitOfWork)
        {
            _itemsRepository = itemsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Item>> AddNewItem(Item item)
        {
            var result = await _itemsRepository.Add(item);

            if(await _unitOfWork.CommitAsync())
            {
                return Result<Item>.Success(result.Payload);
            }

            return Result<Item>.Failed(StatusCodes.FailedToSave);
        }

        public async Task<Result<Item>> GetItemById(long id)
        {
            return await _itemsRepository.GetById(id);
        }
    }
}
