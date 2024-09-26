using System;
using System.Collections.Generic;

namespace ProjectInstaArt.DAL.Model
{
    public partial class ImportDetail
    {
        public ImportDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Shelves = new HashSet<Shelf>();
            ShelvesHistories = new HashSet<ShelvesHistory>();
            Stocks = new HashSet<Stock>();
        }

        public string ImportDetailId { get; set; } = null!;
        public string ImportId { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public string BatchCode { get; set; } = null!;
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public long UnitId { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }

        public virtual Import Import { get; set; } = null!;
        public virtual Product ProductCodeNavigation { get; set; } = null!;
        public virtual Unit Unit { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Shelf> Shelves { get; set; }
        public virtual ICollection<ShelvesHistory> ShelvesHistories { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
