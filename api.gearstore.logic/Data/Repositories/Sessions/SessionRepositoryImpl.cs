using System.Linq;
using api.gearstore.logic.Data.DbContext;
using api.gearstore.logic.Models;
using Microsoft.EntityFrameworkCore;

namespace api.gearstore.logic.Data.Repositories.Sessions
{
    public class SessionRepositoryImpl : ISessionRepository
    {
        private readonly AppDbContext _context;

        public SessionRepositoryImpl(AppDbContext context) => 
            _context = context;

        public bool IsRegistered(string sessionId) => 
            _context.Sessions.Select(s => s.SessionId).Contains(sessionId);

        public void Register(SessionData sessionData)
        {
            _context.Sessions.Add(sessionData);
            _context.SaveChanges();
        }

        public void Clean(string sessionId)
        {
            _context.Sessions.RemoveRange(_context.Sessions.Where(s => s.SessionId == sessionId));
            _context.SaveChanges();
        }

        public UserData GetUserByLogin(string login) => 
            _context.Users.FirstOrDefault(u => u.Username == login);

        public SessionData GetIfExists(string sessionId) => 
            _context.Sessions.Include(s => s.User).ToList()
                .FirstOrDefault(s => s.SessionId == sessionId);
    }
}