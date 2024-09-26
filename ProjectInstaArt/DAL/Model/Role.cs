using System;
using System.Collections.Generic;

namespace ProjectInstaArt.DAL.Model
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public bool IsValid { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
