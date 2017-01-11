using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class DotNetSql
    {
        public Guid DotNetSqlId { get; set; }
        public Guid? DotNetCompileFilesId { get; set; }
        public string SqlText { get; set; }

        public virtual DotNetCompileFiles DotNetCompileFiles { get; set; }
    }
}
