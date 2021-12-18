using System.Linq;
using System.Text.RegularExpressions;
using api.gearstore.logic.Data.Repositories.Users;
using api.gearstore.logic.Models;
using api.gearstore.logic.Models.Enums;

namespace api.gearstore.logic.Services.Registration
{
    public class RegistrationService : IRegistrationService
    {
        private const int LoginMinLength = 6;
        private const int PasswordMinLength = 4;
        
        private const string PasswordRegex = "^[a-zA-Z0-9]+$";
        private const string LoginRegex = "^\\w+$";
        private const string PhoneRegex = "^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$";
        private const string EmailRegex = "^[a-zA-Z0-9.!#$%&’*+\\/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)+$";
        
        private readonly IUserRepository _repository;

        public RegistrationService(IUserRepository repository) => 
            _repository = repository;

        public RegistrationResult RegisterNewUser(UserData user)
        {
            if (!LoginIsValid(user.Username)) return RegistrationResult.LoginIsInvalid;
            if (!PasswordIsValid(user.Password)) return RegistrationResult.PasswordIsInvalid;
            if (!PhoneIsValid(user.Phone)) return RegistrationResult.PhoneIsInvalid;
            if (!EmailIsValid(user.Email)) return RegistrationResult.EmailIsInvalid;
            if (LoginIsOccupied(user.Username)) return RegistrationResult.LoginIsOccupied;
            if (PhoneIsOccupied(FormatPhone(user.Phone))) return RegistrationResult.PhoneIsOccupied;
            if (EmailIsOccupied(user.Email)) return RegistrationResult.EmailIsOccupied;
            user.Phone = FormatPhone(user.Phone);
            return _repository.Create(user) ? RegistrationResult.Success : RegistrationResult.UnknownError;
        }

        private bool LoginIsOccupied(string login) =>
            _repository.GetAll().Select(u => u.Username).Contains(login);
        
        private bool EmailIsOccupied(string email) =>
            _repository.GetAll().Select(u => u.Email).Contains(email);
        
        private bool PhoneIsOccupied(string formattedPhone) =>
            _repository.GetAll().Select(u => u.Phone).Contains(formattedPhone);

        private static bool EmailIsValid(string email) =>
            new Regex(EmailRegex).IsMatch(email);

        private static bool PhoneIsValid(string phone) =>
            new Regex(PhoneRegex).IsMatch(phone);

        private static bool LoginIsValid(string login) =>
            login.Length >= LoginMinLength && new Regex(LoginRegex).IsMatch(login);

        private static bool PasswordIsValid(string password) =>
            password.Length >= PasswordMinLength && new Regex(PasswordRegex).IsMatch(password);

        private static string FormatPhone(string raw) =>
            string.Join("", raw.Replace("+7", "8").ToCharArray().Where(char.IsDigit));
    }
}