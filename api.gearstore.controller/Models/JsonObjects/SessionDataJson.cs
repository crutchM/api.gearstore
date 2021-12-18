using System;
using Newtonsoft.Json;

namespace api.gearstore.controller.Models.JsonObjects
{
    [JsonObject]
    public class SessionDataJson : IJsonRepresentation<Tuple<bool, string>>
    {
        public bool IsAuthorized { get; set; }
        
        public string ErrorMessage { get; set; }
        
        public Tuple<bool, string> ToImage() => 
            (IsAuthorized, ErrorMessage).ToTuple();

        public void Represent(Tuple<bool, string> image) => 
            (IsAuthorized, ErrorMessage) = image;
    }
}