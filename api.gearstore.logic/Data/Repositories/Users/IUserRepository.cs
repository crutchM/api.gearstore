using System.Collections.Generic;
using System.Linq;
using api.gearstore.logic.Models;

namespace api.gearstore.logic.Data.Repositories.Users
{
    public interface IUserRepository
    {
        IQueryable<UserData> GetAll();
        UserData GetById(long id);
        bool Create(UserData user);
        void Update(UserData user);
        UserData DeleteById(long id);
        bool Clean();
    }
}
