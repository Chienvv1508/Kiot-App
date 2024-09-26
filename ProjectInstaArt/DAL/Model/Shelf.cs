using System;
using System.Collections.Generic;

namespace ProjectInstaArt.DAL.Model
{
    public partial class Shelf
    {
        public string ShelvesId { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public string ImportDetailId { get; set; } = null!;
        public int Quantity { get; set; }
        public long Unit { get; set; }

        public virtual ImportDetail ImportDetail { get; set; } = null!;
        public virtual Product ProductCodeNavigation { get; set; } = null!;
        public virtual Unit UnitNavigation { get; set; } = null!;
    }
}
