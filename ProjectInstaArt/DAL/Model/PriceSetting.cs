using System;
using System.Collections.Generic;

namespace ProjectInstaArt.DAL.Model
{
    public partial class PriceSetting
    {
        public string PriceRuleId { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public long UnitId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public bool IsValid { get; set; }

        public virtual Product ProductCodeNavigation { get; set; } = null!;
        public virtual Unit Unit { get; set; } = null!;
    }
}
