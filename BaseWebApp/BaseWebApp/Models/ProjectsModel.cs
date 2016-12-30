namespace BaseWebApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectsModel : DbContext
    {
        public ProjectsModel()
            : base("name=ProjectsModel")
        {
        }

        public virtual DbSet<DotNetProjects> DotNetProjects { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DotNetProjects>()
                .Property(e => e.OutputType)
                .IsUnicode(false);

            modelBuilder.Entity<DotNetProjects>()
                .Property(e => e.RootNamespace)
                .IsUnicode(false);

            modelBuilder.Entity<DotNetProjects>()
                .Property(e => e.AssemblyName)
                .IsUnicode(false);

            modelBuilder.Entity<DotNetProjects>()
                .Property(e => e.TargetFrameworkVersion)
                .IsUnicode(false);

            modelBuilder.Entity<DotNetProjects>()
                .Property(e => e.ProjectFile)
                .IsUnicode(false);

            modelBuilder.Entity<DotNetProjects>()
                .Property(e => e.ProjectFolder)
                .IsUnicode(false);

            modelBuilder.Entity<DotNetProjects>()
                .Property(e => e.ProjectParentFolder)
                .IsUnicode(false);

            modelBuilder.Entity<DotNetProjects>()
                .Property(e => e.DocType)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.ExeName32)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.ProjectType)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.ProjectFile)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.ProjectFolder)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.ProjectParentFolder)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.DocType)
                .IsUnicode(false);
        }
    }
}
