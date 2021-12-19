using System;
using Newtonsoft.Json;

namespace api.gearstore.controller.Models.JsonObjects
{
    [JsonObject]
    public class ActionResultJson : IJsonRepresentation<(bool, string)>
    {
        [JsonProperty("success")]
        public bool IsSuccessful { get; set; }
        
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        public (bool, string) ToImage() => 
            (IsSuccessful, ErrorMessage);

        public void Represent((bool, string) image) => 
            (IsSuccessful, ErrorMessage) = image;
    }
}