using DotaGuideToGreatness.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.Controllers
{
    public class TestingController : ControllerBase
    {
        private readonly IItemsManager _itemsManager;

        public TestingController(IItemsManager itemsManager)
        {
            _itemsManager = itemsManager;
        }



    }
}
