using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class DotNetReferences
    {
        public DotNetReferences()
        {
            DotNetRefMap = new HashSet<DotNetRefMap>();
        }

        public Guid DotNetReferencesId { get; set; }
        public string ReferenceInclude { get; set; }

        public virtual ICollection<DotNetRefMap> DotNetRefMap { get; set; }
    }
}
