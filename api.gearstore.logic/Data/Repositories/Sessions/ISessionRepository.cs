using api.gearstore.logic.Models;

namespace api.gearstore.logic.Data.Repositories.Sessions
{
    public interface ISessionRepository
    {
        bool IsRegistered(string sessionId);

        void Register(SessionData sessionData);

        void Clean(string sessionId);

        UserData GetUserByLogin(string login);

        SessionData GetIfExists(string sessionId);
    }
}