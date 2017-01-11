using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class ObjectRefs
    {
        public ObjectRefs()
        {
            ObjRefMap = new HashSet<ObjRefMap>();
        }

        public Guid ObjectRefsId { get; set; }
        public string ClsId { get; set; }
        public string ObjectVersion { get; set; }
        public string ObjectFile { get; set; }

        public virtual ICollection<ObjRefMap> ObjRefMap { get; set; }
    }
}
