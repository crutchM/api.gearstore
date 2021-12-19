using System;
using System.Collections.Generic;
using System.Linq;
using api.gearstore.controller.Models.JsonObjects;
using api.gearstore.logic.Data.Repositories;
using api.gearstore.logic.Data.Repositories.Favourites;
using api.gearstore.logic.Data.Repositories.Sessions;
using api.gearstore.logic.Models;
using api.gearstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;

namespace api.gearstore.controller.Controllers
{
    [Route("api/lots/[controller]")]
    [ApiController]
    public class FavouritesController
    {
        private readonly ILogger<FavouritesController> _logger;
        private readonly IFavouritesRepository _favourites;
        private readonly ISessionRepository _sessions;

        public FavouritesController(IFavouritesRepository favourites, ISessionRepository sessions, ILogger<FavouritesController> logger)
        {
            _favourites = favourites;
            _sessions = sessions;
            _logger = logger;
        }
        
        [HttpGet]
        public JsonResult GetUserFavourites(string sessionId)
        {
            var session = _sessions.GetIfExists(sessionId);
            if (session is null)
                return new JsonResult(new List<LotData>());
            _logger.LogDebug("Requesting for getting all favs for one user");
            var lots = _favourites.GetUsersFavourites(session.User.Id);
            return new JsonResult(
                lots.Select(
                    l => new LotJson().WithLoadedRepresentation(Tuple.Create(l, true).ToValueTuple())
                )
            );
        }
        
        [HttpPut]
        public IActionResult ChangeFavStatement(long lotId, string sessionId, bool isChecked)
        {
            _logger.LogDebug("requesting for add or delete favs by bool flag");
            if (isChecked) _favourites.Create(lotId, _sessions.GetIfExists(sessionId).UserId);
            else _favourites.Delete(lotId, _sessions.GetIfExists(sessionId).UserId);
            return new OkResult();
        }
    }
}