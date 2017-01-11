using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class RefMap
    {
        public Guid RefMapId { get; set; }
        public Guid? ProjectsId { get; set; }
        public Guid? ReferencezId { get; set; }

        public virtual Projects Projects { get; set; }
        public virtual Referencez Referencez { get; set; }
    }
}
