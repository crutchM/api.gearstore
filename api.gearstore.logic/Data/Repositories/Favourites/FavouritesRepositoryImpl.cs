using System.Collections.Generic;
using System.Linq;
using api.gearstore.logic.Data.DbContext;
using api.gearstore.logic.Models;
using Microsoft.EntityFrameworkCore;

namespace api.gearstore.logic.Data.Repositories.Favourites
{
    public class FavouritesRepositoryImpl : IFavouritesRepository
    {
        private readonly AppDbContext _context;

        public FavouritesRepositoryImpl(AppDbContext context) =>
            _context = context;

        public bool IsFav(long userId, long lotId) => 
            GetUsersFavourites(userId).Any(lot => lot.Id == lotId);

        public IEnumerable<LotData> GetUsersFavourites(long userId) => 
            _context.Favourites
                .Include(x => x.User)
                .Include(x => x.Lot)
                .ToList()
                .Where(x => x.UserId == userId)
                .Select(f => f.Lot);

        public void Create(long lotId, long userId)
        {
            var fav = Find(lotId, userId);
            if (fav is not null)
                return;
            _context.Favourites.Add(new FavouritesData(userId, lotId));
            _context.SaveChanges();
        }

        public void Delete(long lotId, long userId)
        {
            var fav = Find(lotId, userId);
            if (fav is null) 
                return;
            _context.Favourites.Remove(fav);
            _context.SaveChanges();
        }

        private FavouritesData Find(long lotId, long userId) => 
            _context.Favourites.FirstOrDefault(x => x.LotId == lotId && x.UserId == userId);
    }
}