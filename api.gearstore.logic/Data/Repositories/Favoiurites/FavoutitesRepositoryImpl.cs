using System.Collections.Generic;
using System.Linq;
using api.gearstore.logic.Data.DbContext;
using api.gearstore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace api.gearstore.logic.Data.Repositories.Users
{
    public class FavoutitesRepositoryImpl : IFavouritesRepository
    {
        private AppDbContext _context;

        public FavoutitesRepositoryImpl(AppDbContext context) =>
            _context = context;
        
        
        public IEnumerable<FavouritesData> GetAll()
        {
            return _context.Favourites;
        }

        public IEnumerable<FavouritesData> GetByLotId(long lotId)
        {
            return _context.Favourites.Where(x => x.LotId == lotId);
        }

        public IEnumerable<FavouritesData> GetByUserId(long userId)
        {
            return _context.Favourites.Where(x => x.UserId == userId);
        }

        public bool Create(long lotId, long userId)
        {
            EntityEntry<FavouritesData> resultState = _context.Favourites.Add(new FavouritesData(lotId, userId));
            _context.SaveChanges();
            return resultState.State == EntityState.Unchanged;
        }

        public FavouritesData GetOnePos(long lotId, long userId)
        {
            return _context.Favourites.First(x => x.LotId == lotId && x.UserId == userId);
        }

        public FavouritesData Delete(long lotId, long userId)
        {
            FavouritesData data = GetOnePos(lotId, userId);
            if (data is not null)
            {
                _context.Favourites.Remove(data);
            }

            return data;
        }
    }
}