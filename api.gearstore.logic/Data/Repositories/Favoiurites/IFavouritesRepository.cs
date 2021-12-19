using System.Collections.Generic;
using api.gearstore.Models;

namespace api.gearstore.logic.Data.Repositories
{
    public interface IFavouritesRepository
    {
        IEnumerable<FavouritesData> GetAll();

        IEnumerable<FavouritesData> GetByLotId(long lotId);

        IEnumerable<FavouritesData> GetByUserId(long userId);

        bool Create(long lotId, long userId);

        FavouritesData GetOnePos(long lotId, long userId);

        FavouritesData Delete(long lotId, long userId);
    }
}