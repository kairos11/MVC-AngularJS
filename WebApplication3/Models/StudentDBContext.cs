using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WebApplication3.Models
{
    public class StudentDBContext : DbContext
    {

        public StudentDBContext() : base("StudentDBContext")
        {
        }

        public DbSet<Syllabus> CourseSyllabus { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<LoginViewModel> LogIn { get; set; }
        public DbSet<RegisterViewModel> Register { get; set; }
        public DbSet<RoleViewModel> Role { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Course>().HasKey(a => a.CourseId);
            modelBuilder.Entity<Course>().Property(b => b.CourseId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Student>().HasKey(c => c.Id);
            modelBuilder.Entity<Student>().Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Student>().HasRequired(a => a.Course)
                .WithMany(c => c.Students).HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<LoginViewModel>().HasKey(d => d.ID);
            modelBuilder.Entity<LoginViewModel>().Property(e => e.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<RegisterViewModel>().HasKey(f => f.Id);
            modelBuilder.Entity<RegisterViewModel>().Property(f => f.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<RoleViewModel>().HasKey(g => g.RoleId);
            modelBuilder.Entity<RoleViewModel>().Property(h => h.RoleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<RegisterViewModel>().HasRequired(g => g.Role)
                .WithMany(f => f.Registrations).HasForeignKey(f => f.RoleId);
            
            modelBuilder.Entity<Subject>().HasKey(i => i.SubjectId);
            modelBuilder.Entity<Subject>().Property(i => i.SubjectId);
                

            modelBuilder.Entity<Syllabus>().HasKey(j => j.ID);
            modelBuilder.Entity<Syllabus>().Property(k => k.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Syllabus>().HasRequired(i => i.Subjects)
                .WithMany(j => j.CourseSyllabus2).HasForeignKey(i => i.SubjectId);

            modelBuilder.Entity<Syllabus>().HasRequired(i => i.Courses)
                .WithMany(c => c.CourseSyllabus1).HasForeignKey(i => i.CourseId);

            base.OnModelCreating(modelBuilder);
        }

    }
}