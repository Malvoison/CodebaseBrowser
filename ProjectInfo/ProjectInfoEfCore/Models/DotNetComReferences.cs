using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class DotNetComReferences
    {
        public Guid DotNetComReferencesId { get; set; }
        public Guid? DotNetProjectsId { get; set; }
        public string ReferenceInclude { get; set; }
        public string ComGuid { get; set; }
        public string VersionMajor { get; set; }
        public string VersionMinor { get; set; }

        public virtual DotNetProjects DotNetProjects { get; set; }
    }
}
