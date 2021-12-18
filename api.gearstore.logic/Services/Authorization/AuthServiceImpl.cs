using api.gearstore.logic.Data.Repositories.Sessions;
using api.gearstore.logic.Models;
using api.gearstore.logic.Models.Enums;

namespace api.gearstore.logic.Services.Authorization
{
    public class AuthServiceImpl : IAuthService
    {
        private readonly ISessionRepository _repository;

        public AuthServiceImpl(ISessionRepository repository) => 
            _repository = repository;

        public LoginResult LogIn(UserLoginData loginData)
        {
            var user = _repository.GetUserByLogin(loginData.InputUsername);
            if (user is null) return LoginResult.NoSuchUser;
            if (user.Password != loginData.InputPassword) return LoginResult.InvalidPassword;
            if (!_repository.IsRegistered(loginData.SessionId)) 
                _repository.Register(new SessionData(loginData.SessionId, user.Id));
            return LoginResult.Success;
        }

        public void LogOut(string sessionId) => 
            _repository.Clean(sessionId);

        public SessionData GetIfRegistered(string sessionId) => 
            _repository.GetIfExists(sessionId);
    }
}