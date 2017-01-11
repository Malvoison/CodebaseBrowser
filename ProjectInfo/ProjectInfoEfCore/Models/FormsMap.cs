using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class FormsMap
    {
        public Guid FormsMapId { get; set; }
        public Guid? ProjectsId { get; set; }
        public Guid? FormsId { get; set; }

        public virtual Forms Forms { get; set; }
        public virtual Projects Projects { get; set; }
    }
}
