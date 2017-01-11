using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class ClassesSql
    {
        public Guid ClassesSqlId { get; set; }
        public Guid? ClassesId { get; set; }
        public string SqlText { get; set; }

        public virtual Classes Classes { get; set; }
    }
}
