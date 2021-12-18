using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.gearstore.logic.Models
{
    public class SessionData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        public string SessionId { get; set; }
        
        public UserData User { get; set; }

        public SessionData(string sessionId, UserData user) : this(sessionId) => 
            User = user;

        private SessionData(string sessionId) => 
            SessionId = sessionId;
    }
}