using System;
using System.Collections.Generic;
using System.Linq;
using api.gearstore.controller.Models.JsonObjects;
using api.gearstore.logic.Data.Repositories.Favourites;
using api.gearstore.logic.Data.Repositories.Lots;
using api.gearstore.logic.Data.Repositories.Sessions;
using api.gearstore.logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.gearstore.controller.Controllers
{
    [Route("api/lots/filtered")]
    [ApiController]
    public class FiltrationController
    {
        private readonly ILotsRepository _lotRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IFavouritesRepository _favouritesRepository;

        public FiltrationController(
            ILotsRepository lotRepository, 
            ISessionRepository sessionRepository, 
            IFavouritesRepository favouritesRepository
        ) {
            _lotRepository = lotRepository;
            _sessionRepository = sessionRepository;
            _favouritesRepository = favouritesRepository;
        }

        [HttpGet]
        public JsonResult GetFilteredLots(FiltrationJson json)
        {
            var userId = _sessionRepository.GetIfExists(json.SessionId)?.UserId ?? -1;
            var result = json.Type switch
            {
                "all" =>
                    _lotRepository.GetAll().Where(l => !l.IsClosed()),
                "own" =>
                    _lotRepository.GetByOwnerId(userId) ?? Enumerable.Empty<LotData>(),
                "fav" =>
                    _favouritesRepository.GetUsersFavourites(userId) ?? Enumerable.Empty<LotData>(),
                _ =>
                    Enumerable.Empty<LotData>()
            };
            
            return new JsonResult(Filter(result, json));
        }

        private IEnumerable<LotJson> Filter(IEnumerable<LotData> lots, FiltrationJson json)
        {
            var userId = _sessionRepository.GetIfExists(json.SessionId)?.UserId ?? -1;
            return lots.Where( // by server and race
                lot =>
                    (json.Race == null || json.Race == lot.Character.Race) &&
                    (json.Server == null || lot.Character.Server == json.Server)
            ).Where( // by level
                lot =>
                    (json.MinLvl == null || lot.Character.Level >= json.MinLvl) &&
                    (json.MaxLvl == null || lot.Character.Level <= json.MaxLvl)
            ).Where( // by price
                lot =>
                    (json.MinPrice == null || lot.Price >= json.MinPrice) &&
                    (json.MaxPrice == null || lot.Price <= json.MaxPrice)
            ).Select( // transform
                lot => new LotJson().WithLoadedRepresentation(Tuple.Create(
                    lot,
                    _favouritesRepository.IsFav(
                        userId,
                        lot.Id
                    )
                ).ToValueTuple())
            );
        }
    }
}