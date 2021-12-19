using api.gearstore.logic.Models;

namespace api.gearstore.logic.Services.NewLot
{
    public class NewLotValidatorImpl : INewLotValidator
    {
        public bool IsFieldsFilled(LotData lot) =>
            lot.Character?.Class is not null &&
            lot.Character?.Heaven is not null &&
            lot.Character?.Level != -1 &&
            (int)lot.Price != -1;

        public bool IsDollValid(LotData lot) =>
            lot.Character is not null && 
            (lot.Character.Doll is null || lot.Character.Doll.StartsWith("https://"));

        public bool IsLvlValid(LotData lot) => 
            lot.Character is not null && lot.Character.Level >= 0;

        public bool IsPriceValid(LotData lot) => 
            lot.Price > 0;
    }
}