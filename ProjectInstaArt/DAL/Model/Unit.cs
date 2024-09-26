using System;
using System.Collections.Generic;

namespace ProjectInstaArt.DAL.Model
{
    public partial class Unit
    {
        public Unit()
        {
            ImportDetails = new HashSet<ImportDetail>();
            OrderDetails = new HashSet<OrderDetail>();
            PriceSettings = new HashSet<PriceSetting>();
            Shelves = new HashSet<Shelf>();
            ShelvesHistories = new HashSet<ShelvesHistory>();
            Stocks = new HashSet<Stock>();
        }

        public long UnitId { get; set; }
        public string UnitName { get; set; } = null!;
        public bool IsBaseUnit { get; set; }
        public int Quantity { get; set; }
        public string ProductCode { get; set; } = null!;
        public bool IsValid { get; set; }

        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<PriceSetting> PriceSettings { get; set; }
        public virtual ICollection<Shelf> Shelves { get; set; }
        public virtual ICollection<ShelvesHistory> ShelvesHistories { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
