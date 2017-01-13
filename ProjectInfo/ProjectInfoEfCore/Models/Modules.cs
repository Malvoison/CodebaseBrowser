using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Module Name")]
        public string ModuleName { get; set; }
        [Display(Name = "Module File")]
        public string ModuleFile { get; set; }
        public byte[] ModuleFileContent { get; set; }
        public string DocType { get; set; }

        public virtual ICollection<ModMap> ModMap { get; set; }
        public virtual ICollection<ModulesSql> ModulesSql { get; set; }
    }
}
