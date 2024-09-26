using System;
using System.Collections.Generic;

namespace ProjectInstaArt.DAL.Model
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public long CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public bool IsValid { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
