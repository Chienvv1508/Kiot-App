using System;
using System.Collections.Generic;

namespace ProjectInstaArt.DAL.Model
{
    public partial class Import
    {
        public Import()
        {
            ImportDetails = new HashSet<ImportDetail>();
        }

        public string ImportId { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime ImportDate { get; set; }
        public long Importer { get; set; }
        public string Supplier { get; set; } = null!;

        public virtual User ImporterNavigation { get; set; } = null!;
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
    }
}
