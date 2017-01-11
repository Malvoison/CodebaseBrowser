using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class DotNetSkipped
    {
        public Guid DotNetSkippedId { get; set; }
        public string ProjectPath { get; set; }
    }
}
