using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class Modules
    {
        public Modules()
        {
            ModMap = new HashSet<ModMap>();
            ModulesSql = new HashSet<ModulesSql>();
        }

        public Guid ModulesId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleFile { get; set; }
        public byte[] ModuleFileContent { get; set; }
        public string DocType { get; set; }

        public virtual ICollection<ModMap> ModMap { get; set; }
        public virtual ICollection<ModulesSql> ModulesSql { get; set; }
    }
}
