using api.gearstore.logic.Data.DbContext;
using api.gearstore.logic.Models;

namespace api.gearstore.logic.Data.Repositories.Chars
{
    public class CharRepositoryImpl : ICharRepository
    {
        private readonly AppDbContext _context;

        public CharRepositoryImpl(AppDbContext context) => 
            _context = context;

        public void Create(CharData charData)
        {
            _context.Add(charData);
            _context.SaveChanges();
        }
    }
}