using api.gearstore.logic.Models;
using Newtonsoft.Json;

namespace api.gearstore.controller.Models.JsonObjects
{
    [JsonObject]
    public class FiltrationJson : IJsonRepresentation<FiltrationParams>
    {
        [JsonProperty("server")]
        public string Server { get; set; }
        
        [JsonProperty("server")]
        public string Race { get; set; }
        
        [JsonProperty("minLvl")]
        public int MinLvl { get; set; }
        
        [JsonProperty("maxLvl")]
        public int MaxLvl { get; set; }
        
        [JsonProperty("minPrice")]
        public int MinPrice { get; set; }
        
        [JsonProperty("maxPrice")]
        public int  MaxPrice { get; set; }

        public FiltrationParams ToImage() =>
            new FiltrationParams
            (
                server: Server,
                race: Race,
                minLvl: MinLvl,
                maxLvl: MaxLvl,
                minPrice: MinPrice,
                maxPrice: MaxPrice
            );

        public void Represent(FiltrationParams image)
        {
            Server = image.Server;
            Race = image.Race;
            MinLvl = image.MinLvl;
            MaxLvl = image.MaxLvl;
            MinPrice = image.MinPrice;
            MaxPrice = image.MaxPrice;
        }
    }
}