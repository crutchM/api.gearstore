namespace api.gearstore.logic.Models
{
    public class UserLoginData
    {
        public string InputUsername { get; set; }
        
        public string InputPassword { get; set; }
        
        public string SessionId { get; set; }
        
        public UserData FoundUser { get; set; }

        public UserLoginData(string inputUsername, string inputPassword, string sessionId, UserData foundUser)
        {
            InputUsername = inputUsername;
            InputPassword = inputPassword;
            SessionId = sessionId;
            FoundUser = foundUser;
        }
    }
}