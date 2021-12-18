using System;
using api.gearstore.logic.Models;
using Newtonsoft.Json;

namespace api.gearstore.controller.Models.JsonObjects
{
    [JsonObject]
    public class LotPreviewJson : IJsonRepresentation<Tuple<LotData, CharData>>
    {
        [JsonProperty("server")]
        public string Server { get; set; }
        
        [JsonProperty("race")]
        public string Race { get; set; }
        
        [JsonProperty("price")]
        public int Price { get; set; }
        
        [JsonProperty("lvl")]
        public int Level { get; set; }

        public Tuple<LotData, CharData> ToImage() =>
            (
                new LotData(
                    id: -1,
                    ownerId: -1,
                    opened: new DateTime(0),
                    closed: null,
                    price: Price,
                    description: null
                ), 
                new CharData(
                    id: -1,
                    level: Level,
                    server: Server,
                    race: Race,
                    @class: null,
                    heaven: null,
                    doll: null,
                    description: null
                )
            ).ToTuple();

        public void Represent(Tuple<LotData, CharData> image)
        {
            var (lot, character) = image;
            Price = (int)lot.Price;
            Level = character.Level;
            Server = character.Server;
            Race = character.Race;
        }
    }
}