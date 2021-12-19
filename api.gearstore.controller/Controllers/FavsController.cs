using api.gearstore.logic.Data.Repositories;
using api.gearstore.logic.Data.Repositories.Sessions;
using api.gearstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.gearstore.controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavsController
    {
        private IFavouritesRepository _favsRepo;
        private ISessionRepository _session;

        public FavsController(IFavouritesRepository favourites, ISessionRepository session)
        {
            _favsRepo = favourites;
            _session = session;
        }


        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(_favsRepo.GetAll());
        }

        [HttpGet]
        public JsonResult GetAllByUser(long userId)
        {
            return new JsonResult(_favsRepo.GetByUserId(userId));
        }



        [HttpPost]
        public JsonResult ChangeFavStatement(long lotId, string sessionId, bool isSelected)
        {
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