using api.gearstore.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.gearstore.logic.Data.Repositories
{
    public interface ILotsRepository
    {
        IEnumerable<LotData> GetAll();
        LotData GetById(long id);
        IEnumerable<LotData> GetByOwnerId(long ownerId);
        bool Create(LotData lot);
        void Update(LotData lot);
        LotData DeleteById(long id);
        bool Clean();
    }
}
