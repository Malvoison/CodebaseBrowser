using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class DotNetHelp
    {
        public Guid DotNetHelpId { get; set; }
        public Guid? DotNetCompileFilesId { get; set; }
        public string HelpText { get; set; }

        public virtual DotNetCompileFiles DotNetCompileFiles { get; set; }
    }
}
