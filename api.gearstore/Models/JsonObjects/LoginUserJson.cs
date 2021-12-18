using api.gearstore.logic.Models;
using Newtonsoft.Json;

namespace api.gearstore.controller.Models.JsonObjects
{
    [JsonObject]
    public class LoginUserJson : IJsonRepresentation<UserLoginData>
    {
        [JsonProperty("login")]
        public string InputUsername { get; set; }
        
        [JsonProperty("password")]
        public string InputPassword { get; set; }
        
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        public UserLoginData ToImage() =>
            new UserLoginData
            (
                inputUsername: InputUsername,
                inputPassword: InputPassword,
                sessionId: SessionId,
                foundUser: null
            );

        public void Represent(UserLoginData image)
        {
            InputUsername = image.InputUsername;
            InputPassword = image.InputPassword;
            SessionId = image.SessionId;
        }
    }
}