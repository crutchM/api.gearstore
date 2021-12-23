using System.Collections.Generic;
using System.Linq;
using api.gearstore.logic.Data.DbContext;
using api.gearstore.logic.Models;
using Microsoft.EntityFrameworkCore;

namespace api.gearstore.logic.Data.Repositories.Lots
{
    public class LotRepositoryImpl : ILotsRepository
    {
        private readonly AppDbContext _context;

        public LotRepositoryImpl(AppDbContext context) => 
            _context = context;

        public bool Clean()
        {
            _context.Lots.RemoveRange(_context.Lots);
            _context.SaveChanges();
            return !GetAll().Any();
        }

        public bool Create(LotData lot)
        {
            var resultState =
                _context.Lots.Add(lot);
            _context.SaveChanges();
            return resultState.State == EntityState.Unchanged;
        }

        public LotData DeleteById(long id)
        {
            var lot = GetById(id);
            if (lot is not null) 
                _context.Lots.Remove(lot);

            return lot;
        }

        public IEnumerable<LotData> GetAll() => 
            _context.Lots
                .Include(l => l.Character)
                .Include(l => l.Owner)
                .ToList();

        public LotData GetById(long id) => 
            _context.Lots.Find(id);

        public IEnumerable<LotData> GetByOwnerId(long ownerId) => 
            _context.Lots
                .Where(x => x.OwnerId == ownerId)
                .Include(l => l.Character)
                .Include(l => l.Owner)
                .ToList();

        public bool Close(long id)
        {
            var oldLot = GetById(id);
            if (oldLot.IsClosed())
                return false;
            oldLot.CloseLot();
            _context.Lots.Update(oldLot);
            _context.SaveChanges();
            return true;
        }
    }
}
