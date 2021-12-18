using api.gearstore.logic.Models;
using api.gearstore.logic.Models.Enums;

namespace api.gearstore.logic.Services.Registration
{
    public interface IRegistrationService
    {
        RegistrationResult RegisterNewUser(UserData user);
    }
}