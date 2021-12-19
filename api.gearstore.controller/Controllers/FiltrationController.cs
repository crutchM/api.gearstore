﻿using System.Collections.Generic;
using System.Linq;
using api.gearstore.controller.Models.JsonObjects;
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

        public FiltrationController(ILotsRepository lotRepository, ISessionRepository sessionRepository)
        {
            _lotRepository = lotRepository;
            _sessionRepository = sessionRepository;
        }

        [HttpGet]
        public JsonResult GetFilteredLots(FiltrationJson json)
        {
            var result = json.Type switch
            {
                "all" =>
                    _lotRepository.GetAll().Where(l => !l.IsClosed()),
                "own" =>
                    _lotRepository.GetByOwnerId(_sessionRepository.GetIfExists(json.SessionId).UserId),
                "fav" =>
                    new List<LotData>(), // finish after API-13,
                _ =>
                    new List<LotData>()
            };
            
            return new JsonResult(Filter(result, json));
        }

        private IEnumerable<LotJson> Filter(IEnumerable<LotData> lots, FiltrationJson json) =>
            lots.Where(  // by server and race
                lot =>
                    json.Race is null || json.Race == lot.Character.Race &&
                    json.Server is null || lot.Character.Server == json.Server
            ).Where(  // by level
                lot =>
                    json.MinLvl == -1 || json.MinLvl <= lot.Character.Level &&
                    json.MaxLvl == -1 || lot.Character.Level <= json.MaxLvl
            ).Where(  // by price
                lot =>
                    json.MinPrice == -1 || json.MinPrice <= lot.Price &&
                    json.MaxPrice == -1 || lot.Price <= json.MaxPrice
            ).Select(  // transform
                lot => new LotJson().WithLoadedRepresentation((
                    lot,
                    false  // finish after API-13
                ))
            );
    }
}