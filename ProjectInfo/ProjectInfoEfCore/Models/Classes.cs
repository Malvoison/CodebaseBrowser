using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectInfoEfCore.Models
{
    public partial class Classes
    {
        public Classes()
        {
            ClassesSql = new HashSet<ClassesSql>();
            ClassMap = new HashSet<ClassMap>();
        }

        public Guid ClassesId { get; set; }
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }
        [Display(Name = "Class File")]
        public string ClassFile { get; set; }
        public byte[] ClassFileContent { get; set; }
        public string DocType { get; set; }

        public virtual ICollection<ClassesSql> ClassesSql { get; set; }
        public virtual ICollection<ClassMap> ClassMap { get; set; }
    }
}
