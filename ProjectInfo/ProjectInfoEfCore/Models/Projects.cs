using System;
using System.Collections.Generic;

namespace ProjectInfoEfCore.Models
{
    public partial class Projects
    {
        public Projects()
        {
            ClassMap = new HashSet<ClassMap>();
            FormsMap = new HashSet<FormsMap>();
            ModMap = new HashSet<ModMap>();
            ObjRefMap = new HashSet<ObjRefMap>();
            RefMap = new HashSet<RefMap>();
        }

        public Guid ProjectsId { get; set; }
        public string Name { get; set; }
        public string ExeName32 { get; set; }
        public string ProjectType { get; set; }
        public string ProjectFile { get; set; }
        public string ProjectFolder { get; set; }
        public string ProjectParentFolder { get; set; }
        public byte[] ProjectFileContent { get; set; }
        public string DocType { get; set; }

        public virtual ICollection<ClassMap> ClassMap { get; set; }
        public virtual ICollection<FormsMap> FormsMap { get; set; }
        public virtual ICollection<ModMap> ModMap { get; set; }
        public virtual ICollection<ObjRefMap> ObjRefMap { get; set; }
        public virtual ICollection<RefMap> RefMap { get; set; }
    }
}
