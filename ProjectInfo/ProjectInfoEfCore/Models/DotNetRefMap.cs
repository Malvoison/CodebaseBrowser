using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class DotNetRefMap
    {
        public Guid DotNetRefMapId { get; set; }
        public Guid DotNetProjectsId { get; set; }
        public Guid DotNetReferencesId { get; set; }

        public virtual DotNetProjects DotNetProjects { get; set; }
        public virtual DotNetReferences DotNetReferences { get; set; }
    }
}
