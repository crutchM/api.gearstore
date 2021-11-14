using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.gearstore.logic.Models
{
    public class LotData
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }

        public DateTime DateOpened { get; set; }

        public DateTime? DateClosed { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }
        //мейби стоит сделать еще статус заказа, но с другой стороны если у нас есть dateClosed, то казалось бы и не надо

        public LotData(long id, long ownerID, DateTime opened, DateTime closed, double price, string description)
        {
            Id = id;
            OwnerId = ownerID;
            DateOpened = opened;
            DateClosed = null;
            Price = price;
            Description = description;
        }

        public void CloseLot()
        {
            DateClosed = DateTime.Now;
        }
        public LotData() { }

        public void Copy(LotData lot)
        {
            Price = lot.Price;
            Description = lot.Description;
        }
        

    }
}
