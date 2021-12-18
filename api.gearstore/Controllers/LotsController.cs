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
    public class LotsController : Controller
    {
        ILotsRepository _lotsRepository;

        public LotsController(ILotsRepository lotsRepository)
        {
            _lotsRepository = lotsRepository;
        }

        [HttpGet]
        public JsonResult GetAll() =>
            new( _lotsRepository.GetAll());

        // [HttpPost]
        // public JsonResult CreateLot(LotData lot) =>
        //     BoolResultJson(_lotsRepository.Create(lot));
        //
        //
        // [HttpDelete]
        // public JsonResult Clean()
        // {
        //     return BoolResultJson(_lotsRepository.Clean());
        // }
        //
        // [HttpPut]
        // public JsonResult CloseLot(long id)
        // {
        //     return BoolResultJson(_lotsRepository.Update(id));
        // }
        //
        // private static JsonResult BoolResultJson(bool value) =>
        //     new(value ? "Done successfully" : $"Unknown error");
    }
}
