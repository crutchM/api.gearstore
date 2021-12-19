using System;
using api.gearstore.logic.Models;
using Newtonsoft.Json;

namespace api.gearstore.controller.Models.JsonObjects
{
    [JsonObject]
    public class LotJson : IJsonRepresentation<(LotData, bool)>
    {
        [JsonProperty("lotId")]
        public long Id { get; set; }
        
        [JsonProperty("server")]
        public string Server { get; set; }
        
        [JsonProperty("race")]
        public string Race { get; set; }
        
        [JsonProperty("sellerPhone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("class")]
        public string Class { get; set; }
        
        [JsonProperty("heaven")]
        public string Heaven { get; set; }
        
        [JsonProperty("doll")]
        public string Doll { get; set; }
        
        [JsonProperty("lvl")]
        public int Level { get; set; }
        
        [JsonProperty("date")]
        public long DateOpened { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("isFavorite")]
        public bool IsFavorite { get; set; }

        public (LotData, bool) ToImage() =>
        (
            LotData.Create(
                owner: new UserData(
                    username: null,
                    password: null,
                    email: Email,
                    phone: Phone
                ),
                opened: new DateTime(DateOpened),
                closed: null,
                price: Price,
                character: new CharData(
                    level: Level,
                    server: Server,
                    race: Race,
                    @class: Class,
                    heaven: Heaven,
                    doll: Doll,
                    description: Description
                )
            ),
            IsFavorite
        );

        public void Represent((LotData, bool) image)
        {
            var (lot, isFav) = image;
            Id = lot.Id;
            Server = lot.Character.Server;
            Race = lot.Character.Race;
            Phone = lot.Owner.Phone;
            Email = lot.Owner.Email;
            Class = lot.Character.Class;
            Heaven = lot.Character.Heaven;
            Doll = lot.Character.Doll;
            Level = lot.Character.Level;
            DateOpened = lot.DateOpened.Ticks;
            Price = (int)lot.Price;
            Description = lot.Character.Description;
            IsFavorite = isFav;
        }
    }
}