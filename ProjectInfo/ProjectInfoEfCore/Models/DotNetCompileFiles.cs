using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class DotNetCompileFiles
    {
        public DotNetCompileFiles()
        {
            DotNetHelp = new HashSet<DotNetHelp>();
            DotNetSql = new HashSet<DotNetSql>();
        }

        public Guid DotNetCompileFilesId { get; set; }
        public Guid? DotNetProjectsId { get; set; }
        public string CompileFile { get; set; }
        public string CompileFileType { get; set; }
        public byte[] CompileFileContent { get; set; }
        public string DocType { get; set; }

        public virtual ICollection<DotNetHelp> DotNetHelp { get; set; }
        public virtual ICollection<DotNetSql> DotNetSql { get; set; }
        public virtual DotNetProjects DotNetProjects { get; set; }
    }
}
