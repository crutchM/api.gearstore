using System.Collections.Generic;
using System.Linq;
using api.gearstore.logic.Models;

namespace api.gearstore.logic.Data.Repositories.Lots
{
    public interface ILotsRepository
    {
        IQueryable<LotData> GetAll();
        LotData GetById(long id);
        IQueryable<LotData> GetByOwnerId(long ownerId);
        bool Create(LotData lot);
        bool Close(long id);
        LotData DeleteById(long id);
        bool Clean();
    }
}
