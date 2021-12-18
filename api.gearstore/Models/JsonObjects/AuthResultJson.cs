using System;
using Newtonsoft.Json;

namespace api.gearstore.controller.Models.JsonObjects
{
    [JsonObject]
    public class AuthResultJson : IJsonRepresentation<Tuple<bool, string>>
    {
        [JsonProperty("success")]
        public bool IsSuccessful { get; set; }
        
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        public Tuple<bool, string> ToImage() => 
            (IsSuccessful, ErrorMessage).ToTuple();

        public void Represent(Tuple<bool, string> image) => 
            (IsSuccessful, ErrorMessage) = image;
    }
}