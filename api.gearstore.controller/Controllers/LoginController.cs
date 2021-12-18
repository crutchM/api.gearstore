using System;
using api.gearstore.controller.Models.JsonObjects;
using api.gearstore.logic.Models.Enums;
using api.gearstore.logic.Services.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.gearstore.controller.Controllers
{
    [Route("api/users/login")]
    [ApiController]
    public class LoginController
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService) => 
            _authService = authService;

        [HttpPost]
        public JsonResult Login(LoginUserJson loginJson)
        {
            var result = _authService.LogIn(loginJson.ToImage());
            var errorMessage = result switch
            {
                LoginResult.Success => "",
                LoginResult.InvalidPassword => "Неверный пароль",
                LoginResult.NoSuchUser => "Пользователь с указанным логином не найден",
                _ => "Возникла неизвестная ошибка"
            };
            return new JsonResult
            (
                new AuthResultJson().WithLoadedRepresentation
                (
                    (result == LoginResult.Success, errorMessage).ToTuple()
                )
            );
        }
    }
}