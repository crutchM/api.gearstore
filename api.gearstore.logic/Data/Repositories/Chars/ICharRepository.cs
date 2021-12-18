using System.Collections.Generic;
using api.gearstore.logic.Models;

namespace api.gearstore.logic.Data.Repositories.Chars
{
    public interface ICharRepository
    {
        List<CharData> GetAll();
    }
}