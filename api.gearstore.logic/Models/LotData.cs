using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.gearstore.logic.Models
{
    public class LotData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long? OwnerId { get; set; }
        
        [ForeignKey("OwnerId")]
        public UserData Owner { get; set; }

        public DateTime DateOpened { get; set; }

        public DateTime? DateClosed { get; set; }

        public double Price { get; set; }
        
        public long CharId { get; set; }
        
        [ForeignKey("CharId")]
        public CharData Character { get; set; }

        public LotData(long? ownerId, DateTime opened, DateTime? closed, double price, long characterId)
        {
            OwnerId = ownerId;
            DateOpened = DateTime.Now;
            DateClosed = null;
            Price = price;
            CharId = characterId;
        }

        public LotData() {}

        public static LotData Create(UserData owner, DateTime opened, DateTime? closed, double price, CharData character) =>
            new()
            {
                Owner = owner,
                DateOpened = DateTime.Now,
                DateClosed = null,
                Price = price,
                Character = character
            };

        public bool IsClosed() => 
            DateClosed is not null;

        public void CloseLot() => 
            DateClosed = DateTime.Now;
    }
}