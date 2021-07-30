using DotaGuideToGreatness.Domain;
using DotaGuideToGreatness.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.BusinessLogic.Interfaces
{
    public interface IHeroesManager
    {
        Task<Result<Hero>> GetItemById(long id);
        Task<Result<Hero>> AddNewHero(Hero hero);
    }
}
