using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class DotNetProjects
    {
        public DotNetProjects()
        {
            DotNetCompileFiles = new HashSet<DotNetCompileFiles>();
            DotNetComReferences = new HashSet<DotNetComReferences>();
            DotNetRefMap = new HashSet<DotNetRefMap>();
        }

        public Guid DotNetProjectsId { get; set; }
        public string OutputType { get; set; }
        public string RootNamespace { get; set; }
        public string AssemblyName { get; set; }
        public string TargetFrameworkVersion { get; set; }
        public string ProjectFile { get; set; }
        public string ProjectFolder { get; set; }
        public string ProjectParentFolder { get; set; }
        public byte[] ProjectFileContent { get; set; }
        public string DocType { get; set; }

        public virtual ICollection<DotNetCompileFiles> DotNetCompileFiles { get; set; }
        public virtual ICollection<DotNetComReferences> DotNetComReferences { get; set; }
        public virtual ICollection<DotNetRefMap> DotNetRefMap { get; set; }
    }
}
