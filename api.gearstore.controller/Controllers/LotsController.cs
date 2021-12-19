using Microsoft.AspNetCore.Mvc;
using api.gearstore.logic.Models;
using api.gearstore.logic.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.gearstore.controller.Models.JsonObjects;
using api.gearstore.logic.Data.Repositories.Lots;
using api.gearstore.logic.Data.Repositories.Sessions;

namespace api.gearstore.controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotsController : Controller
    {
        private readonly ILotsRepository _lotsRepository;
        private readonly ISessionRepository _sessionRepository;

        public LotsController(ILotsRepository lotsRepository, ISessionRepository sessionRepository)
        {
            _lotsRepository = lotsRepository;
            _sessionRepository = sessionRepository;
        }

        [HttpGet]
        public JsonResult GetAll(string sessionId, string type)
        {
            var result = type switch
            {
                "all" =>
                    _lotsRepository.GetAll().Where(l => l.DateClosed == null),
                "own" =>
                    _lotsRepository.GetByOwnerId(
                        _sessionRepository.GetIfExists(sessionId)?.UserId ?? -1
                    ) ?? Enumerable.Empty<LotData>(),
                "fav" =>
                    Enumerable.Empty<LotData>().AsQueryable(), // finish after API-13,
                _ =>
                    Enumerable.Empty<LotData>().AsQueryable()
            };
            return new JsonResult(
                result.Select(
                    lot => new LotJson().WithLoadedRepresentation((
                        lot,
                        false // finish after API-13
                    ))
                )
            );
        }

        [HttpPut]
        public JsonResult CloseLot(long lotId)
        {
            var result = _lotsRepository.Close(lotId);
            return new JsonResult(new ActionResultJson().WithLoadedRepresentation((
                result,
                result ? "" : "Не удалось закрыть лот"
            )));
        }
    }
}
