using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectInfoEfCore.Models
{
    public partial class ProjectInfoContext : DbContext
    {
        public virtual DbSet<ClassMap> ClassMap { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<ClassesSql> ClassesSql { get; set; }
        public virtual DbSet<DotNetComReferences> DotNetComReferences { get; set; }
        public virtual DbSet<DotNetCompileFiles> DotNetCompileFiles { get; set; }
        public virtual DbSet<DotNetHelp> DotNetHelp { get; set; }
        public virtual DbSet<DotNetProjects> DotNetProjects { get; set; }
        public virtual DbSet<DotNetRefMap> DotNetRefMap { get; set; }
        public virtual DbSet<DotNetReferences> DotNetReferences { get; set; }
        public virtual DbSet<DotNetSkipped> DotNetSkipped { get; set; }
        public virtual DbSet<DotNetSql> DotNetSql { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<FormsMap> FormsMap { get; set; }
        public virtual DbSet<FormsSql> FormsSql { get; set; }
        public virtual DbSet<ModMap> ModMap { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<ModulesSql> ModulesSql { get; set; }
        public virtual DbSet<ObjRefMap> ObjRefMap { get; set; }
        public virtual DbSet<ObjectRefs> ObjectRefs { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<RefMap> RefMap { get; set; }
        public virtual DbSet<Referencez> Referencez { get; set; }

        public ProjectInfoContext(DbContextOptions<ProjectInfoContext> options)
            : base(options)
        {
        }

        // Unable to generate entity type for table 'dbo.teststring'. Please see the warning messages.

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Data Source=BHM-KWATTS\KEN1;Initial Catalog=ProjectInfo;Integrated Security=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassMap>(entity =>
            {
                entity.HasIndex(e => e.ClassesId)
                    .HasName("ClassMap_IX2");

                entity.HasIndex(e => e.ProjectsId)
                    .HasName("ClassMap_IX1");

                entity.Property(e => e.ClassMapId).HasDefaultValueSql("newsequentialid()");

                entity.HasOne(d => d.Classes)
                    .WithMany(p => p.ClassMap)
                    .HasForeignKey(d => d.ClassesId)
                    .HasConstraintName("FK_ClassMap_Classes");

                entity.HasOne(d => d.Projects)
                    .WithMany(p => p.ClassMap)
                    .HasForeignKey(d => d.ProjectsId)
                    .HasConstraintName("FK_ClassMap_Projects");
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasIndex(e => new { e.ClassName, e.ClassFile })
                    .HasName("Classes_IX1");

                entity.Property(e => e.ClassesId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.ClassFile).HasColumnType("varchar(256)");

                entity.Property(e => e.ClassName).HasColumnType("varchar(64)");

                entity.Property(e => e.DocType)
                    .HasColumnType("varchar(8)")
                    .HasDefaultValueSql("'.txt'");
            });

            modelBuilder.Entity<ClassesSql>(entity =>
            {
                entity.HasIndex(e => e.ClassesId)
                    .HasName("ClassesSql_IX1");

                entity.Property(e => e.ClassesSqlId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.SqlText).HasColumnType("varchar(4000)");

                entity.HasOne(d => d.Classes)
                    .WithMany(p => p.ClassesSql)
                    .HasForeignKey(d => d.ClassesId)
                    .HasConstraintName("FK_ClassesSql_Classes");
            });

            modelBuilder.Entity<DotNetComReferences>(entity =>
            {
                entity.HasIndex(e => e.DotNetProjectsId)
                    .HasName("DotNetComReferences_IX1");

                entity.Property(e => e.DotNetComReferencesId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.ComGuid).HasColumnType("varchar(128)");

                entity.Property(e => e.ReferenceInclude).HasColumnType("varchar(256)");

                entity.Property(e => e.VersionMajor).HasColumnType("varchar(8)");

                entity.Property(e => e.VersionMinor).HasColumnType("varchar(8)");

                entity.HasOne(d => d.DotNetProjects)
                    .WithMany(p => p.DotNetComReferences)
                    .HasForeignKey(d => d.DotNetProjectsId)
                    .HasConstraintName("FK_DotNetComReferences_DotNetProjects");
            });

            modelBuilder.Entity<DotNetCompileFiles>(entity =>
            {
                entity.HasIndex(e => e.DotNetProjectsId)
                    .HasName("DotNetCompileFiles_IX1");

                entity.Property(e => e.DotNetCompileFilesId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.CompileFile).HasColumnType("varchar(128)");

                entity.Property(e => e.CompileFileType).HasColumnType("varchar(8)");

                entity.Property(e => e.DocType)
                    .HasColumnType("varchar(8)")
                    .HasDefaultValueSql("'.xml'");

                entity.HasOne(d => d.DotNetProjects)
                    .WithMany(p => p.DotNetCompileFiles)
                    .HasForeignKey(d => d.DotNetProjectsId)
                    .HasConstraintName("FK_DotNetCompileFiles_DotNetProjects");
            });

            modelBuilder.Entity<DotNetHelp>(entity =>
            {
                entity.HasIndex(e => e.DotNetCompileFilesId)
                    .HasName("DotNetHelp_IX1");

                entity.Property(e => e.DotNetHelpId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.HelpText).HasColumnType("varchar(4000)");

                entity.HasOne(d => d.DotNetCompileFiles)
                    .WithMany(p => p.DotNetHelp)
                    .HasForeignKey(d => d.DotNetCompileFilesId)
                    .HasConstraintName("FK_DotNetHelp_DotNetCompileFilesId");
            });

            modelBuilder.Entity<DotNetProjects>(entity =>
            {
                entity.Property(e => e.DotNetProjectsId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.AssemblyName).HasColumnType("varchar(128)");

                entity.Property(e => e.DocType)
                    .HasColumnType("varchar(8)")
                    .HasDefaultValueSql("'.xml'");

                entity.Property(e => e.OutputType).HasColumnType("varchar(32)");

                entity.Property(e => e.ProjectFile).HasColumnType("varchar(128)");

                entity.Property(e => e.ProjectFolder).HasColumnType("varchar(256)");

                entity.Property(e => e.ProjectParentFolder).HasColumnType("varchar(256)");

                entity.Property(e => e.RootNamespace).HasColumnType("varchar(128)");

                entity.Property(e => e.TargetFrameworkVersion).HasColumnType("varchar(8)");
            });

            modelBuilder.Entity<DotNetRefMap>(entity =>
            {
                entity.HasIndex(e => e.DotNetProjectsId)
                    .HasName("DotNetRefMap_IX1");

                entity.HasIndex(e => e.DotNetReferencesId)
                    .HasName("DotNetRefMap_IX2");

                entity.Property(e => e.DotNetRefMapId).HasDefaultValueSql("newsequentialid()");

                entity.HasOne(d => d.DotNetProjects)
                    .WithMany(p => p.DotNetRefMap)
                    .HasForeignKey(d => d.DotNetProjectsId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DotNetRefMap_DotNetProjects");

                entity.HasOne(d => d.DotNetReferences)
                    .WithMany(p => p.DotNetRefMap)
                    .HasForeignKey(d => d.DotNetReferencesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DotNetRefMap_DotNetReferences");
            });

            modelBuilder.Entity<DotNetReferences>(entity =>
            {
                entity.Property(e => e.DotNetReferencesId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.ReferenceInclude).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<DotNetSkipped>(entity =>
            {
                entity.Property(e => e.DotNetSkippedId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.ProjectPath).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<DotNetSql>(entity =>
            {
                entity.HasIndex(e => e.DotNetCompileFilesId)
                    .HasName("DotNetSql_IX1");

                entity.Property(e => e.DotNetSqlId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.SqlText).HasColumnType("varchar(4000)");

                entity.HasOne(d => d.DotNetCompileFiles)
                    .WithMany(p => p.DotNetSql)
                    .HasForeignKey(d => d.DotNetCompileFilesId)
                    .HasConstraintName("FK_DotNetSql_DotNetCompileFilesId");
            });

            modelBuilder.Entity<Forms>(entity =>
            {
                entity.HasIndex(e => e.FormFile)
                    .HasName("Forms_IX1");

                entity.Property(e => e.FormsId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.DocType)
                    .HasColumnType("varchar(8)")
                    .HasDefaultValueSql("'.txt'");

                entity.Property(e => e.FormFile).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<FormsMap>(entity =>
            {
                entity.HasIndex(e => e.FormsId)
                    .HasName("FormsMap_IX2");

                entity.HasIndex(e => e.ProjectsId)
                    .HasName("FormsMap_IX1");

                entity.Property(e => e.FormsMapId).HasDefaultValueSql("newsequentialid()");

                entity.HasOne(d => d.Forms)
                    .WithMany(p => p.FormsMap)
                    .HasForeignKey(d => d.FormsId)
                    .HasConstraintName("FK_FormsMap_Forms");

                entity.HasOne(d => d.Projects)
                    .WithMany(p => p.FormsMap)
                    .HasForeignKey(d => d.ProjectsId)
                    .HasConstraintName("FK_FormsMap_Projects");
            });

            modelBuilder.Entity<FormsSql>(entity =>
            {
                entity.HasIndex(e => e.FormsId)
                    .HasName("FormsSql_IX1");

                entity.Property(e => e.FormsSqlId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.SqlText).HasColumnType("varchar(4000)");

                entity.HasOne(d => d.Forms)
                    .WithMany(p => p.FormsSql)
                    .HasForeignKey(d => d.FormsId)
                    .HasConstraintName("FK_FormsSql_Forms");
            });

            modelBuilder.Entity<ModMap>(entity =>
            {
                entity.HasIndex(e => e.ModulesId)
                    .HasName("ModMap_IX2");

                entity.HasIndex(e => e.ProjectsId)
                    .HasName("ModMap_IX1");

                entity.Property(e => e.ModMapId).HasDefaultValueSql("newsequentialid()");

                entity.HasOne(d => d.Modules)
                    .WithMany(p => p.ModMap)
                    .HasForeignKey(d => d.ModulesId)
                    .HasConstraintName("FK_ModMap_Modules");

                entity.HasOne(d => d.Projects)
                    .WithMany(p => p.ModMap)
                    .HasForeignKey(d => d.ProjectsId)
                    .HasConstraintName("FK_ModMap_Projects");
            });

            modelBuilder.Entity<Modules>(entity =>
            {
                entity.HasIndex(e => new { e.ModuleName, e.ModuleFile })
                    .HasName("Modules_IX1");

                entity.Property(e => e.ModulesId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.DocType)
                    .HasColumnType("varchar(8)")
                    .HasDefaultValueSql("'.txt'");

                entity.Property(e => e.ModuleFile).HasColumnType("varchar(256)");

                entity.Property(e => e.ModuleName).HasColumnType("varchar(128)");
            });

            modelBuilder.Entity<ModulesSql>(entity =>
            {
                entity.HasIndex(e => e.ModulesId)
                    .HasName("ModulesSql_IX1");

                entity.Property(e => e.ModulesSqlId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.SqlText).HasColumnType("varchar(4000)");

                entity.HasOne(d => d.Modules)
                    .WithMany(p => p.ModulesSql)
                    .HasForeignKey(d => d.ModulesId)
                    .HasConstraintName("FK_ModulesSql_Modules");
            });

            modelBuilder.Entity<ObjRefMap>(entity =>
            {
                entity.HasIndex(e => e.ObjectRefsId)
                    .HasName("ObjRefMap_IX2");

                entity.HasIndex(e => e.ProjectsId)
                    .HasName("ObjRefMap_IX1");

                entity.Property(e => e.ObjRefMapId).HasDefaultValueSql("newsequentialid()");

                entity.HasOne(d => d.ObjectRefs)
                    .WithMany(p => p.ObjRefMap)
                    .HasForeignKey(d => d.ObjectRefsId)
                    .HasConstraintName("FK_ObjRefMap_ObjectRefs");

                entity.HasOne(d => d.Projects)
                    .WithMany(p => p.ObjRefMap)
                    .HasForeignKey(d => d.ProjectsId)
                    .HasConstraintName("FK_ObjRefMap_Projects");
            });

            modelBuilder.Entity<ObjectRefs>(entity =>
            {
                entity.HasIndex(e => e.ClsId)
                    .HasName("ObjectRefs_IX1");

                entity.Property(e => e.ObjectRefsId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.ClsId).HasColumnType("varchar(64)");

                entity.Property(e => e.ObjectFile).HasColumnType("varchar(256)");

                entity.Property(e => e.ObjectVersion).HasColumnType("varchar(8)");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.Property(e => e.ProjectsId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.DocType)
                    .HasColumnType("varchar(8)")
                    .HasDefaultValueSql("'.txt'");

                entity.Property(e => e.ExeName32).HasColumnType("varchar(32)");

                entity.Property(e => e.Name).HasColumnType("varchar(32)");

                entity.Property(e => e.ProjectFile).HasColumnType("varchar(32)");

                entity.Property(e => e.ProjectFolder).HasColumnType("varchar(256)");

                entity.Property(e => e.ProjectParentFolder).HasColumnType("varchar(256)");

                entity.Property(e => e.ProjectType).HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<RefMap>(entity =>
            {
                entity.HasIndex(e => e.ProjectsId)
                    .HasName("RefMap_IX1");

                entity.HasIndex(e => e.ReferencezId)
                    .HasName("RefMap_IX2");

                entity.Property(e => e.RefMapId).HasDefaultValueSql("newsequentialid()");

                entity.HasOne(d => d.Projects)
                    .WithMany(p => p.RefMap)
                    .HasForeignKey(d => d.ProjectsId)
                    .HasConstraintName("FK_RefMap_Projects");

                entity.HasOne(d => d.Referencez)
                    .WithMany(p => p.RefMap)
                    .HasForeignKey(d => d.ReferencezId)
                    .HasConstraintName("FK_RefMap_Referencez");
            });

            modelBuilder.Entity<Referencez>(entity =>
            {
                entity.HasIndex(e => e.ClsId)
                    .HasName("Referencez_IX1");

                entity.Property(e => e.ReferencezId).HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.ClsId).HasColumnType("varchar(64)");

                entity.Property(e => e.FilePath).HasColumnType("varchar(256)");

                entity.Property(e => e.ObjectName).HasColumnType("varchar(128)");

                entity.Property(e => e.ObjectVersion).HasColumnType("varchar(8)");
            });
        }
    }
}