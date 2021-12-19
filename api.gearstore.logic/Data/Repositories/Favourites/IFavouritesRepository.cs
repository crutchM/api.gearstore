using System.Collections.Generic;
using System.Linq;
using api.gearstore.logic.Models;

namespace api.gearstore.logic.Data.Repositories.Favourites
{
    public interface IFavouritesRepository
    {
        IQueryable<FavouritesData> GetUsersFavourites(long userId);

        void Create(long lotId, long userId);

        void Delete(long lotId, long userId);
    }
}