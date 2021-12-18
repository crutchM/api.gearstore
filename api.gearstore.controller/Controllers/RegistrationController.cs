using System;
using api.gearstore.controller.Models.JsonObjects;
using api.gearstore.logic.Models.Enums;
using api.gearstore.logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.gearstore.controller.Controllers
{
    [Route("api/users/register")]
    [ApiController]
    public class RegistrationController
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService) => 
            _registrationService = registrationService;
        
        [HttpPost]
        public JsonResult Register(NewUserJson userJson)
        {
            var (user, sessionId) = userJson.ToImage();
            var result = _registrationService.RegisterNewUser(user);
            var errorMessage = result switch
            {
                RegistrationResult.Success => "",
                RegistrationResult.EmailIsInvalid => "Некорректное значение email",
                RegistrationResult.EmailIsOccupied => "Email уже зарегистрирован",
                RegistrationResult.LoginIsInvalid => "Логин должен быть длиной минимум в 6 символов и состоять только " +
                                                     "из цифр, букв латинского алфавита или символа _",
                RegistrationResult.LoginIsOccupied => "Логин занят",
                RegistrationResult.PasswordIsInvalid => "Пароль должен быть длиной минимум в 4 символа и состоять " +
                                                        "только из цифр или букв латинского алфавита",
                RegistrationResult.PhoneIsInvalid => "Некорректный номер телефона",
                RegistrationResult.PhoneIsOccupied => "Номер телефона уже зарегистрирован",
                _ => "Неизвестная ошибка"
            };
            var jsonResult = new RegistrationResultJson();
            jsonResult.Represent((result == RegistrationResult.Success, errorMessage).ToTuple());
            return new JsonResult(jsonResult);
        }
    }
}