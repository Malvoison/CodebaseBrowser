using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class ModMap
    {
        public Guid ModMapId { get; set; }
        public Guid? ProjectsId { get; set; }
        public Guid? ModulesId { get; set; }

        public virtual Modules Modules { get; set; }
        public virtual Projects Projects { get; set; }
    }
}
