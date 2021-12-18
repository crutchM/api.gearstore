using System;
using api.gearstore.controller.Models.JsonObjects;
using api.gearstore.logic.Services.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.gearstore.controller.Controllers
{
    [Route("api/users/session")]
    [ApiController]
    public class SessionController
    {
        private readonly IAuthService _authService;

        public SessionController(IAuthService authService) => 
            _authService = authService;

        [HttpGet]
        public IActionResult CheckSession(string sessionId)
        {
            if (sessionId is null) return new BadRequestResult();
            var sessionData = _authService.GetIfRegistered(sessionId);
            return new JsonResult(
                new SessionDataJson().WithLoadedRepresentation((sessionData is not null, sessionData?.User?.Username)
                    .ToTuple())
            );
        }
    }
}