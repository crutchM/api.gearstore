using api.gearstore.logic.Data.Repositories;
using api.gearstore.logic.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.gearstore.controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(_repository.GetAll());
        }

        [HttpPost]
        public JsonResult AddUser(UserData user)
        {
            return BoolResultJson(
                _repository.Create(user)
            );
        }

        [HttpDelete]
        public JsonResult RemoveAll()
        {
            return BoolResultJson(
                _repository.Clean()
            );
        }

        private static JsonResult BoolResultJson(bool value) =>
            new(value ? "Done successfully" : $"Unknown error");
    }
}
