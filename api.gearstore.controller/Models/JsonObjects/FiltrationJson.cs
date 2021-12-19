using api.gearstore.logic.Models;
using Newtonsoft.Json;

namespace api.gearstore.controller.Models.JsonObjects
{
    [JsonObject]
    public class FiltrationJson : IJsonRepresentation<(FiltrationParams, string, string)>
    {
        [JsonProperty("server")]
        public string Server { get; set; }
        
        [JsonProperty("race")]
        public string Race { get; set; }
        
        [JsonProperty("minLvl")]
        public int MinLvl { get; set; }
        
        [JsonProperty("maxLvl")]
        public int MaxLvl { get; set; }
        
        [JsonProperty("minPrice")]
        public int MinPrice { get; set; }
        
        [JsonProperty("maxPrice")]
        public int  MaxPrice { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        public (FiltrationParams, string, string) ToImage() =>
            (
                new FiltrationParams
                (
                    server: Server,
                    race: Race,
                    minLvl: MinLvl,
                    maxLvl: MaxLvl,
                    minPrice: MinPrice,
                    maxPrice: MaxPrice
                ),
                Type,
                SessionId
            );

        public void Represent((FiltrationParams, string, string) image)
        {
            var (filtrationParams, requestType, sessionId) = image;
            Server = filtrationParams.Server;
            Race = filtrationParams.Race;
            MinLvl = filtrationParams.MinLvl;
            MaxLvl = filtrationParams.MaxLvl;
            MinPrice = filtrationParams.MinPrice;
            MaxPrice = filtrationParams.MaxPrice;
            Type = requestType;
            SessionId = sessionId;
        }
    }
}