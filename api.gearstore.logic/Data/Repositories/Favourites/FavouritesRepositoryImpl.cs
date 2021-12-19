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

        public IQueryable<LotData> GetUsersFavourites(long userId) => 
            _context.Favourites.Where(x => x.UserId == userId)
                .Include(x => x.User)
                .Include(x => x.Lot)
                .Select(f => f.Lot);

        public void Create(long lotId, long userId)
        {
            _context.Favourites.Add(new FavouritesData(lotId, userId));
            _context.SaveChanges();
        }

        public void Delete(long lotId, long userId)
        {
            var data = Find(lotId, userId);
            if (data is not null) 
                _context.Favourites.Remove(data);
        }

        private FavouritesData Find(long lotId, long userId) => 
            _context.Favourites.First(x => x.LotId == lotId && x.UserId == userId);
    }
}