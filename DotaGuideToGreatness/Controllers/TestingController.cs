using DotaGuideToGreatness.BusinessLogic.Interfaces;
using DotaGuideToGreatness.Domain.Entities;
using DotaGuideToGreatness.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestingController : ControllerBase
    {
        private readonly IHeroesManager _heroesManager;

        public TestingController(IHeroesManager heroesManager)
        {
            _heroesManager = heroesManager;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(long id)
        {
            var result = await _heroesManager.GetItemById(id);

            if (result.StatusCode == StatusCodes.NotFound)
                return NotFound();

            if (result.Succeed == false)
                return BadRequest();

            return Ok(result.Payload);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddItem(Hero hero)
        {
            var result = await _heroesManager.AddNewHero(hero);

            if (result.Succeed)
                return Ok(result.Payload);

            return BadRequest(result.Message);
        }


        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var hero = new Hero
            {
                Id = 0,
                Name = "Test",
                StartingHealth = 560,
                StartingMana = 291,
                Damage = 50,
                Armor = 3,
                StrengthGain = 2.2,
                AgilityGain = 1.5,
                IntelligenceGain = 3.5,
                MainAttribute = Domain.Enums.Hero.Attributes.Intelligence,
                Spells = new List<Spell>
                {
                    new Spell
                    {
                        CoolDown = 1,
                        Description = "Testing Discrio",
                        HeroId = 0,
                        Id = 0,
                        Name = "TestName"
                    },
                    new Spell
                    {
                        CoolDown = 1,
                        Description = "Testing Discrio",
                        HeroId = 0,
                        Id = 0,
                        Name = "TestName"
                    }
                }
            };

            var result = await _heroesManager.AddNewHero(hero);
            return Ok();
        }

    }
}
