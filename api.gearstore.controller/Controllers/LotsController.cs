using Microsoft.AspNetCore.Mvc;
using api.gearstore.logic.Models;
using api.gearstore.logic.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.gearstore.controller.Models.JsonObjects;
using api.gearstore.logic.Data.Repositories.Favourites;
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
        private readonly IFavouritesRepository _favouritesRepository;

        public LotsController(
            ILotsRepository lotsRepository, 
            ISessionRepository sessionRepository, 
            IFavouritesRepository favouritesRepository
        ) {
            _lotsRepository = lotsRepository;
            _sessionRepository = sessionRepository;
            _favouritesRepository = favouritesRepository;
        }

        [HttpGet]
        public JsonResult GetAll(string sessionId, string type)
        {
            var userId = _sessionRepository.GetIfExists(sessionId)?.UserId ?? -1;
            var result = type switch
            {
                "all" =>
                    _lotsRepository.GetAll().Where(l => l.DateClosed == null),
                "own" =>
                    _lotsRepository.GetByOwnerId(userId) ?? Enumerable.Empty<LotData>(),
                "fav" =>
                    _favouritesRepository.GetUsersFavourites(userId) ?? Enumerable.Empty<LotData>(),
                _ =>
                    Enumerable.Empty<LotData>()
            };
            return new JsonResult(
                result.Select(
                    lot => new LotJson().WithLoadedRepresentation((
                        lot,
                        _favouritesRepository.IsFav(userId, lot.Id)
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
