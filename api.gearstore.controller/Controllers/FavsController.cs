using api.gearstore.logic.Data.Repositories;
using api.gearstore.logic.Data.Repositories.Sessions;
using api.gearstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;

namespace api.gearstore.controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavsController
    {
        private readonly ILogger<FavsController> _logger;
        private IFavouritesRepository _favsRepo;
        private ISessionRepository _session;

        public FavsController(IFavouritesRepository favourites, ISessionRepository session, ILogger<FavsController> logger)
        {
            _favsRepo = favourites;
            _session = session;
            _logger = logger;
        }


        [HttpGet]
        public JsonResult GetAll()
        {
            _logger.LogDebug("Requesting for getting all favs");
            return new JsonResult(_favsRepo.GetAll());
        }

        [HttpGet]
        public JsonResult GetAllByUser(long userId)
        {
            _logger.LogDebug("Requesting for getting all favs for one user");
            return new JsonResult(_favsRepo.GetByUserId(userId));
        }



        [HttpPost]
        public JsonResult ChangeFavStatement(long lotId, string sessionId, bool isSelected)
        {
            _logger.LogDebug("requesting for add or delete favs by bool flag");
            if (isSelected)
            {
                return BoolResultJson(_favsRepo.Create(lotId, _session.GetIfExists(sessionId).UserId)); 
            }
            var data = _favsRepo.Delete(lotId, _session.GetIfExists(sessionId).UserId);
            return BoolResultJson(data is not null);
        }
        
        
        private static JsonResult BoolResultJson(bool value) =>
            new(value ? "Done successfully" : $"Unknown error");

    }
}