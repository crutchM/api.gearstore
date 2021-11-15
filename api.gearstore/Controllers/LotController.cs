using Microsoft.AspNetCore.Mvc;
using api.gearstore.logic.Models;
using api.gearstore.logic.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.gearstore.controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotController : Controller
    {
        ILotsRepository _lotsRepository;

        public LotController(ILotsRepository lotsRepository)
        {
            _lotsRepository = lotsRepository;
        }

        [HttpGet]
        public JsonResult GetAll() =>
             new JsonResult( _lotsRepository.GetAll());

        [HttpPost]
        public JsonResult CreateLot(LotData lot) =>
            BoolResultJson(_lotsRepository.Create(lot));


        [HttpDelete]
        public JsonResult Clean()
        {
            return BoolResultJson(_lotsRepository.Clean());
        }

        [HttpPut]
        public JsonResult CloseLot(long id)
        {
            return BoolResultJson(_lotsRepository.Update(id));
        }


        
        private static JsonResult BoolResultJson(bool value) =>
            new(value ? "Done successfully" : $"Unknown error");
    }
}
