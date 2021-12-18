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
        
        public long UserId { get; set; }
        
        [ForeignKey("UserId")]
        public UserData User { get; set; }

        public SessionData(string sessionId, long userId)
        {
            SessionId = sessionId;
            UserId = userId;
        }
    }
}