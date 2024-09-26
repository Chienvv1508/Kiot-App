using System;
using System.Collections.Generic;

namespace ProjectInstaArt.DAL.Model
{
    public partial class OrderDetail
    {
        public string OrderDetailId { get; set; } = null!;
        public long OrderId { get; set; }
        public string ProductCode { get; set; } = null!;
        public string ImportDetailId { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public long Unit { get; set; }

        public virtual ImportDetail ImportDetail { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
        public virtual Product ProductCodeNavigation { get; set; } = null!;
        public virtual Unit UnitNavigation { get; set; } = null!;
    }
}
