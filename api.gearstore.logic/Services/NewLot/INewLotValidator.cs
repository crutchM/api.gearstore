using api.gearstore.logic.Models;

namespace api.gearstore.logic.Services.NewLot
{
    public interface INewLotValidator
    {
        bool IsFieldsFilled(LotData lot);

        bool IsDollValid(LotData lot);

        bool IsLvlValid(LotData lot);

        bool IsPriceValid(LotData lot);
    }
}