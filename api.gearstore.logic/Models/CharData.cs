using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.gearstore.logic.Models
{
    public class CharData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        public int Level { get; set; }
        
        public string Server { get; set; }
        
        public string Race { get; set; }
        
        public string Class { get; set; }
        
        public string Heaven { get; set; }
        
        public string Doll { get; set; }
        
        public string Description { get; set; }

        public CharData() {}

        public CharData(int level, string server, string race, string @class, string heaven, string doll, string description)
        {
            Level = level;
            Server = server;
            Race = race;
            Class = @class;
            Heaven = heaven;
            Doll = doll;
            Description = description;
        }
    }
}