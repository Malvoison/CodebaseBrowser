using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class ClassMap
    {
        public Guid ClassMapId { get; set; }
        public Guid? ProjectsId { get; set; }
        public Guid? ClassesId { get; set; }

        public virtual Classes Classes { get; set; }
        public virtual Projects Projects { get; set; }
    }
}
