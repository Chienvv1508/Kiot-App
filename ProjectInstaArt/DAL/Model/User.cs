using System;
using System.Collections.Generic;

namespace ProjectInstaArt.DAL.Model
{
    public partial class User
    {
        public User()
        {
            Imports = new HashSet<Import>();
        }

        public long UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int RoleId { get; set; }
        public bool IsValid { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Import> Imports { get; set; }
    }
}
