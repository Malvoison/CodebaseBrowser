using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Executable Name")]
        public string ExeName32 { get; set; }
        [Display(Name = "Project Type")]
        public string ProjectType { get; set; }
        [Display(Name = "Project File")]
        public string ProjectFile { get; set; }
        [Display(Name = "Project Folder")]
        public string ProjectFolder { get; set; }
        [Display(Name = "Parent Folder")]
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
