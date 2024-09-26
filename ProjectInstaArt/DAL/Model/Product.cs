using System;
using System.Collections.Generic;

namespace ProjectInstaArt.DAL.Model
{
    public partial class Product
    {
        public Product()
        {
            ImportDetails = new HashSet<ImportDetail>();
            OrderDetails = new HashSet<OrderDetail>();
            PriceSettings = new HashSet<PriceSetting>();
            Shelves = new HashSet<Shelf>();
            ShelvesHistories = new HashSet<ShelvesHistory>();
            Stocks = new HashSet<Stock>();
        }

        public string ProductCode { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public long CategoryId { get; set; }
        public string Description { get; set; } = null!;
        public string Company { get; set; } = null!;
        public bool IsValid { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<PriceSetting> PriceSettings { get; set; }
        public virtual ICollection<Shelf> Shelves { get; set; }
        public virtual ICollection<ShelvesHistory> ShelvesHistories { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
