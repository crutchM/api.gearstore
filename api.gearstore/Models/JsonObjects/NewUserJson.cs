using System;
using api.gearstore.logic.Models;
using Newtonsoft.Json;

namespace api.gearstore.controller.Models.JsonObjects
{
    [JsonObject]
    public class NewUserJson : IJsonRepresentation<Tuple<UserData, string>>
    {
        [JsonProperty("login")]
        public string Username { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("phone")]
        public string Phone { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }
        
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        public Tuple<UserData, string> ToImage()
        {
            return (
                new UserData(
                    id: -1,
                    username: Username,
                    password: Password,
                    email: Email,
                    phone: Phone
                ), 
                SessionId
            ).ToTuple();
        }

        public void Represent(Tuple<UserData, string> image)
        {
            var (user, sessionId) = image;
            Username = user.Username;
            Password = user.Password;
            Email = user.Email;
            Phone = user.Phone;
            SessionId = sessionId;
        }
    }
}