using Microsoft.AspNetCore.Mvc;
using api.gearstore.logic.Models;
using api.gearstore.logic.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.gearstore.logic.Data.Repositories.Lots;

namespace api.gearstore.controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotsController : Controller
    {
        private readonly ILotsRepository _lotsRepository;

        public LotsController(ILotsRepository lotsRepository)
        {
            _lotsRepository = lotsRepository;
        }

        [HttpGet]
        public JsonResult GetAll(string sessionId="")
        {
            return new JsonResult(_lotsRepository.GetAll());
        }
    }
}
