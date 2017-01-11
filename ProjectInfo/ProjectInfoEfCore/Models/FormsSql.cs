using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class FormsSql
    {
        public Guid FormsSqlId { get; set; }
        public Guid? FormsId { get; set; }
        public string SqlText { get; set; }

        public virtual Forms Forms { get; set; }
    }
}
