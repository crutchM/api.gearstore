namespace api.gearstore.logic.Models
{
    public class FiltrationParams
    {
        public string Server { get; set; }
        
        public string Race { get; set; }
        
        public int MinLvl { get; set; }
        
        public int MaxLvl { get; set; }
        
        public int MinPrice { get; set; }
        
        public int  MaxPrice { get; set; }

        public FiltrationParams() {}

        public FiltrationParams(string server, string race, int minLvl, int maxLvl, int minPrice, int maxPrice)
        {
            Server = server;
            Race = race;
            MinLvl = minLvl;
            MaxLvl = maxLvl;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
        }
    }
}