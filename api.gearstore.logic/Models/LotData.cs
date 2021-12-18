using System;

namespace api.gearstore.logic.Models
{
    public class LotData
    {
        public long Id { get; set; }

        public UserData Owner { get; set; }

        public DateTime DateOpened { get; set; }

        public DateTime? DateClosed { get; set; }

        public double Price { get; set; }
        
        public CharData Character { get; set; }

        public LotData() {}

        public LotData(long id, UserData owner, DateTime opened, DateTime? closed, double price, CharData character)
        {
            Id = id;
            Owner = owner;
            DateOpened = DateTime.Now;
            DateClosed = null;
            Price = price;
            Character = character;
        }

        public bool IsClosed() => 
            DateClosed is not null;

        public void CloseLot() => 
            DateClosed = DateTime.Now;
    }
}