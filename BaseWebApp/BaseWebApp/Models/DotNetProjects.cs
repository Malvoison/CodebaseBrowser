namespace BaseWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DotNetProjects
    {
        public Guid DotNetProjectsId { get; set; }

        [StringLength(32)]
        public string OutputType { get; set; }

        [StringLength(128)]
        public string RootNamespace { get; set; }

        [StringLength(128)]
        public string AssemblyName { get; set; }

        [StringLength(8)]
        public string TargetFrameworkVersion { get; set; }

        [StringLength(128)]
        public string ProjectFile { get; set; }

        [StringLength(256)]
        public string ProjectFolder { get; set; }

        [StringLength(256)]
        public string ProjectParentFolder { get; set; }

        public byte[] ProjectFileContent { get; set; }

        [StringLength(8)]
        public string DocType { get; set; }
    }
}
