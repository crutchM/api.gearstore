using System;
using Newtonsoft.Json;

namespace api.gearstore.controller.Models.JsonObjects
{
    [JsonObject]
    public class SessionDataJson : IJsonRepresentation<Tuple<bool, string>>
    {
        [JsonProperty("isLoggedIn")]
        public bool IsAuthorized { get; set; }
        
        [JsonProperty("login")]
        public string Login { get; set; }
        
        public Tuple<bool, string> ToImage() => 
            (IsAuthorized, Login).ToTuple();

        public void Represent(Tuple<bool, string> image) => 
            (IsAuthorized, Login) = image;
    }
}