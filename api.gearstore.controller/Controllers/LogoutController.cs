using api.gearstore.logic.Services.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.gearstore.controller.Controllers
{
    [Route("api/users/logout")]
    [ApiController]
    public class LogoutController
    {
        private readonly IAuthService _authService;

        public LogoutController(IAuthService authService) => 
            _authService = authService;

        [HttpPost]
        public IActionResult Logout(string sessionId)
        {
            _authService.LogOut(sessionId);
            return sessionId is null ? new BadRequestResult() : new OkResult();
        }
    }
}