using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class ObjRefMap
    {
        public Guid ObjRefMapId { get; set; }
        public Guid? ProjectsId { get; set; }
        public Guid? ObjectRefsId { get; set; }

        public virtual ObjectRefs ObjectRefs { get; set; }
        public virtual Projects Projects { get; set; }
    }
}
