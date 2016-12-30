namespace BaseWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Projects
    {
        public Guid ProjectsId { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        [StringLength(32)]
        public string ExeName32 { get; set; }

        [StringLength(32)]
        public string ProjectType { get; set; }

        [StringLength(32)]
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
