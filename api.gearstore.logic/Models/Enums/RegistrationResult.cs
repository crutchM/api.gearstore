namespace api.gearstore.logic.Models.Enums
{
    public enum RegistrationResult
    {
        Success,
        LoginIsOccupied,
        EmailIsOccupied,
        PhoneIsOccupied,
        LoginIsInvalid,
        PasswordIsInvalid,
        EmailIsInvalid,
        PhoneIsInvalid,
        UnknownError,
    }
}