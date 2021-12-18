using api.gearstore.logic.Models;
using api.gearstore.logic.Models.Enums;

namespace api.gearstore.logic.Services.Authorization
{
    public interface IAuthService
    {
        LoginResult LogIn(UserLoginData loginData);

        void LogOut(string sessionId);
    }
}