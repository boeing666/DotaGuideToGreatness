using DotaGuideToGreatness.BusinessLogic.Interfaces;
using DotaGuideToGreatness.DAL.Interfaces;
using DotaGuideToGreatness.Domain;
using DotaGuideToGreatness.Domain.Entities;
using DotaGuideToGreatness.Domain.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.BusinessLogic.Managers
{
    public class HeroesManager : IHeroesManager
    {
        private readonly ILogger _logger;
        private readonly IRepository<Hero> _heroRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HeroesManager(IRepository<Hero> heroRepository, IUnitOfWork unitOfWork, ILoggerFactory loggerFactory)
        {
            _heroRepository = heroRepository;
            _unitOfWork = unitOfWork;
            _logger = loggerFactory.CreateLogger<HeroesManager>();
        }

        public async Task<Result<Hero>> AddNewHero(Hero hero)
        {
            try
            {
                _logger.LogTrace($"HeroesManager tring to add new hero: {hero.Name}");

                var result = await _heroRepository.Add(hero);

                if (await _unitOfWork.CommitAsync())
                    return Result<Hero>.Success(result.Payload);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception Adding New Hero: {hero.Name}");
                return Result<Hero>.Exception(ex);
            }

            return Result<Hero>.Failed(StatusCodes.FailedToSave);
        }

        public async Task<Result<Hero>> GetItemById(long id)
        {
            return await _heroRepository.GetById(id);
        }
    }
}
