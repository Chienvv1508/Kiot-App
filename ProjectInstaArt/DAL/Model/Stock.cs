using System;
using System.Collections.Generic;

namespace ProjectInstaArt.DAL.Model
{
    public partial class Stock
    {
        public string StockId { get; set; } = null!;
        public string ImportDetailId { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public long UnitId { get; set; }
        public int Quantity { get; set; }

        public virtual ImportDetail ImportDetail { get; set; } = null!;
        public virtual Product ProductCodeNavigation { get; set; } = null!;
        public virtual Unit Unit { get; set; } = null!;
    }
}
