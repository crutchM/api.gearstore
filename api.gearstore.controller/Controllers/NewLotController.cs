using System;
using api.gearstore.controller.Models.JsonObjects;
using api.gearstore.logic.Data.Repositories.Chars;
using api.gearstore.logic.Data.Repositories.Lots;
using api.gearstore.logic.Data.Repositories.Sessions;
using api.gearstore.logic.Data.Repositories.Users;
using api.gearstore.logic.Models;
using api.gearstore.logic.Models.Enums;
using api.gearstore.logic.Services.NewLot;
using Microsoft.AspNetCore.Mvc;

namespace api.gearstore.controller.Controllers
{
    [Route("api/lots/new")]
    [ApiController]
    public class NewLotController
    {
        private readonly ICharRepository _charRepository;
        private readonly ILotsRepository _lotsRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly INewLotValidator _validator;

        public NewLotController( 
            ICharRepository charRepository, 
            ILotsRepository lotsRepository, 
            ISessionRepository sessionRepository, 
            INewLotValidator validator
        ) {
            _charRepository = charRepository;
            _lotsRepository = lotsRepository;
            _sessionRepository = sessionRepository;
            _validator = validator;
        }

        [HttpPost]
        public JsonResult CreateNewLot(string sessionId, LotJson lotJson)
        {
            var user = _sessionRepository.GetIfExists(sessionId)?.User;
            if (user is null)
                return new JsonResult(
                    new ActionResultJson().WithLoadedRepresentation((false, "Не удалось найти сессию"))
                );
            
            var (lot, _) = lotJson.ToImage();
            var validationResult = ValidateLot(lot);
            if (validationResult != NewLotResult.Success)
                return new JsonResult(
                    new ActionResultJson().WithLoadedRepresentation((false, GetErrorMessage(validationResult)))
                );
            
            _charRepository.Create(lot.Character);
            lot.Owner = user;
            lot.OwnerId = user.Id;
            var result = _lotsRepository.Create(lot);
            return new JsonResult(
                new ActionResultJson().WithLoadedRepresentation(
                    (result, result ? "" : "Не удалось создать лот")
                )
            );
        }

        private string GetErrorMessage(NewLotResult result) =>
            result switch
            {
                NewLotResult.Success => "",
                NewLotResult.FieldsAreEmpty => "Заполните все поля",
                NewLotResult.DollIsInvalid => "Укажите действующую ссылку на куклу или оставьте поле пустым",
                NewLotResult.PriceIsInvalid => "Цена должна быть больше нуля",
                NewLotResult.LvlIsInvalid => "Некорректное значение уровня",
                _ => "Возникла неизвесная ошибка"
            };

        private NewLotResult ValidateLot(LotData lot) =>
            !_validator.IsFieldsFilled(lot) ? NewLotResult.FieldsAreEmpty :
            !_validator.IsDollValid(lot) ? NewLotResult.DollIsInvalid :
            !_validator.IsLvlValid(lot) ? NewLotResult.LvlIsInvalid :
            !_validator.IsPriceValid(lot) ? NewLotResult.PriceIsInvalid : 
            NewLotResult.Success;
    }
}