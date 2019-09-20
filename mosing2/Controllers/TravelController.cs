using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mosing2.Models;
using mosing2.ViewModels;

namespace mosing2.Controllers
{
    public class TravelController : Controller
    {
        private readonly ITravelDataProvider _provider;

        public TravelController(ITravelDataProvider provider)
        {
            _provider = provider;
        }

        // GET: Travel
        public ActionResult Index()
        {
            Traveling travel = _provider.GetTravel();

            return Ok(travel.Adapt<Travel>());
        }

    }
}