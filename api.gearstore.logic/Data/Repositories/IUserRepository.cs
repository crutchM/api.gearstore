using api.gearstore.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.gearstore.logic.Data.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserData> GetAll();
        UserData GetById(long id);
        bool Create(UserData user);
        void Update(UserData user);
        UserData DeleteById(long id);
        bool Clean();
    }
}
