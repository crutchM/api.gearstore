using System;
using api.gearstore.logic.Models;
using Newtonsoft.Json;

namespace api.gearstore.controller.Models.JsonObjects
{
    [JsonObject]
    public class LotPreviewJson : IJsonRepresentation<LotData>
    {
        [JsonProperty("server")]
        public string Server { get; set; }
        
        [JsonProperty("race")]
        public string Race { get; set; }
        
        [JsonProperty("price")]
        public int Price { get; set; }
        
        [JsonProperty("lvl")]
        public int Level { get; set; }
        
        [JsonProperty("doll")]
        public string Doll { get; set; }

        public LotData ToImage() =>
            LotData.Create(
                owner: null,
                opened: new DateTime(0),
                closed: null,
                price: Price,
                character: new CharData(
                    level: Level,
                    server: Server,
                    race: Race,
                    @class: null,
                    heaven: null,
                    doll: Doll,
                    description: null
                )
            );

        public void Represent(LotData image)
        {
            Price = (int)image.Price;
            Level = image.Character.Level;
            Server = image.Character.Server;
            Race = image.Character.Race;
            Doll = image.Character.Doll;
        }
    }
}