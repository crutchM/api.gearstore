using System;
using api.gearstore.logic.Models;
using Newtonsoft.Json;

namespace api.gearstore.controller.Models.JsonObjects
{
    [JsonObject]
    public class LotJson : IJsonRepresentation<Tuple<LotData, UserData, CharData, bool>>
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

        public Tuple<LotData, UserData, CharData, bool> ToImage() =>
            (
                new LotData(
                    id: Id,
                    ownerId: -1,
                    opened: new DateTime(DateOpened),
                    closed: null,
                    price: Price,
                    description: Description
                ),
                new UserData(
                    id: -1,
                    username: null,
                    password: null,
                    email: Email,
                    phone: Phone
                ),
                new CharData(
                    id: -1,
                    level: Level,
                    server: Server,
                    race: Race,
                    @class: Class,
                    heaven: Heaven,
                    doll: Doll,
                    description: Description
                ),
                IsFavorite
            ).ToTuple();

        public void Represent(Tuple<LotData, UserData, CharData, bool> image)
        {
            var (lot, user, character, isFav) = image;
            Id = lot.Id;
            Server = character.Server;
            Race = character.Race;
            Phone = user.Phone;
            Email = user.Email;
            Class = character.Class;
            Heaven = character.Heaven;
            Doll = character.Doll;
            Level = character.Level;
            DateOpened = lot.DateOpened.Ticks;
            Price = (int)lot.Price;
            Description = lot.Description;
            IsFavorite = isFav;
        }
    }
}