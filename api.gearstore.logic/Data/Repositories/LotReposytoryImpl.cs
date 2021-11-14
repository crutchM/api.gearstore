using api.gearstore.logic.Data.DbContext;
using api.gearstore.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.gearstore.logic.Data.Repositories
{
    class LotReposytoryImpl : ILotsRepository
    {
        private readonly AppDbContext _context;

        public LotReposytoryImpl(AppDbContext context)
        {
            _context = context;
        }
        public bool Clean()
        {
            _context.Lots.RemoveRange(_context.Lots);
            _context.SaveChanges();
            return !GetAll().Any();
        }

        public bool Create(LotData lot)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<LotData> resultState =
                _context.Lots.Add(lot);
            _context.SaveChanges();
            return resultState.State == Microsoft.EntityFrameworkCore.EntityState.Unchanged;
        }

        public LotData DeleteById(long id)
        {
            LotData lot = GetById(id);
            if (lot is not null)
            {
                _context.Lots.Remove(lot);
            }

            return lot;
        }

        public IEnumerable<LotData> GetAll()
        {
            return _context.Lots;
        }

        public LotData GetById(long id)
        {
            return _context.Lots.Find(id);
        }

        public IEnumerable<LotData> GetByOwnerId(long ownerId)
        {
            return _context.Lots.Where(x => x.OwnerId == ownerId);
        }

        public void Update(LotData lot)
        {
            var oldLot = GetById(lot.Id);
            oldLot.Copy(lot);

            _context.Lots.Update(oldLot);
            _context.SaveChanges();
        }
    }
}
