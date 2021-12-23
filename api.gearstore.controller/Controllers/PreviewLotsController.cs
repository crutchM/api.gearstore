using System.Linq;
using api.gearstore.controller.Models.JsonObjects;
using api.gearstore.logic.Data.Repositories.Lots;
using Microsoft.AspNetCore.Mvc;

namespace api.gearstore.controller.Controllers
{
    [Route("/api/lots/preview")]
    [ApiController]
    public class PreviewLotsController
    {
        private readonly ILotsRepository _lots;

        public PreviewLotsController(ILotsRepository lots) => 
            _lots = lots;

        [HttpGet]
        public JsonResult GetPreviewLots()
        {
            var lots = _lots.GetAll().OrderBy(lot => lot.DateOpened).Take(4);
            return new JsonResult(lots.Select( lot =>
                new LotPreviewJson().WithLoadedRepresentation(lot)
            ));
        }
    }
}