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
        private readonly IItemsManager _itemsManager;

        public TestingController(IItemsManager itemsManager)
        {
            _itemsManager = itemsManager;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(long id)
        {
            var result = await _itemsManager.GetItemById(id);

            if (result.StatusCode == StatusCodes.NotFound)
                return NotFound();

            if (result.Succeed == false)
                return BadRequest();

            return Ok(result.Payload);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddItem(Item item)
        {
            var result = await _itemsManager.AddNewItem(item);

            if (result.Succeed)
                return Ok(result.Payload);

            return BadRequest(result.Message);
        }

    }
}
