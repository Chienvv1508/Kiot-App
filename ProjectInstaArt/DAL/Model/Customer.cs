using System;
using System.Collections.Generic;

namespace ProjectInstaArt.DAL.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string Phone { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal Coin { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
