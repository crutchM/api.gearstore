using System.Collections.Generic;
using System.Linq;
using api.gearstore.logic.Models;

namespace api.gearstore.logic.Data.Repositories.Lots
{
    public interface ILotsRepository
    {
        IEnumerable<LotData> GetAll();
        LotData GetById(long id);
        IEnumerable<LotData> GetByOwnerId(long ownerId);
        bool Create(LotData lot);
        bool Close(long id);
        LotData DeleteById(long id);
        bool Clean();
    }
}
