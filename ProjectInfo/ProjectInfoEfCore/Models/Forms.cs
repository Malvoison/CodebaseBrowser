using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class Forms
    {
        public Forms()
        {
            FormsMap = new HashSet<FormsMap>();
            FormsSql = new HashSet<FormsSql>();
        }

        public Guid FormsId { get; set; }
        public string FormFile { get; set; }
        public byte[] FormFileContent { get; set; }
        public string DocType { get; set; }

        public virtual ICollection<FormsMap> FormsMap { get; set; }
        public virtual ICollection<FormsSql> FormsSql { get; set; }
    }
}
