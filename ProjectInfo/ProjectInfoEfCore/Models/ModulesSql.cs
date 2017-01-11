using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class ModulesSql
    {
        public Guid ModulesSqlId { get; set; }
        public Guid? ModulesId { get; set; }
        public string SqlText { get; set; }

        public virtual Modules Modules { get; set; }
    }
}
