using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class Referencez
    {
        public Referencez()
        {
            RefMap = new HashSet<RefMap>();
        }

        public Guid ReferencezId { get; set; }
        public string ClsId { get; set; }
        public string ObjectVersion { get; set; }
        public string FilePath { get; set; }
        public string ObjectName { get; set; }

        public virtual ICollection<RefMap> RefMap { get; set; }
    }
}
