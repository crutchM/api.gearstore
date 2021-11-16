using api.gearstore.logic.Data.Repositories;
using api.gearstore.logic.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace api.gearstore.controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserRepository _repository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository repository, ILogger<UserController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            _logger.LogDebug("Request for getting all users");
            return new JsonResult(_repository.GetAll());
        }

        [HttpPost]
        public JsonResult AddUser(UserData user)
        {
            _logger.LogDebug($"Request for adding user {user}");
            return BoolResultJson(
                _repository.Create(user)
            );
        }

        [HttpDelete]
        public JsonResult RemoveAll()
        {
            _logger.LogInformation("Request for cleanup user table");
            return BoolResultJson(
                _repository.Clean()
            );
        }

        private static JsonResult BoolResultJson(bool value) =>
            new(value ? "Done successfully" : $"Unknown error");
    }
}
