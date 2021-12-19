using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.gearstore.Models
{
    public class FavouritesData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        [ForeignKey("UserId")]
        public long UserId { get; set; }
        
        [ForeignKey("LotId")]
        public long LotId { get; set; }
        
        public FavouritesData( long userId, long lotId)
        {
            UserId = userId;
            LotId = lotId;
        }
        
        public FavouritesData(){}
    }
}