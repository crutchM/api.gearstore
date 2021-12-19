using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.gearstore.logic.Models
{
    public class FavouritesData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public UserData User { get; set; }

        public long LotId { get; set; }

        [ForeignKey("LotId")]
        public LotData Lot { get; set; }

        public FavouritesData(long userId, long lotId)
        {
            UserId = userId;
            LotId = lotId;
        }
    }
}