using Microsoft.EntityFrameworkCore;
using PasantiasTW.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PasantiasTW.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Tutor> Tutors => Set<Tutor>();

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<StudentCompany> StudentsCompanies => Set<StudentCompany>();
        public DbSet<Practice> Practices => Set<Practice>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Tutor>();

            modelBuilder.Entity<Company>()
                .HasOne(c => c.Tutor)         
                .WithOne(t => t.Company)      
                .HasForeignKey<Tutor>(t => t.CompanyId);

            modelBuilder.Entity<Student>();

            modelBuilder.Entity<StudentCompany>()
                .HasKey(ee => new { ee.StudentID, ee.CompanyID });

            modelBuilder.Entity<StudentCompany>()
                .HasOne(ee => ee.Student)
                .WithMany(e => e.StudentCompany)
                .HasForeignKey(ee => ee.StudentID);

            modelBuilder.Entity<StudentCompany>()
                .HasOne(ee => ee.Company)
                .WithMany(comp => comp.StudentCompany)
                .HasForeignKey(ee => ee.CompanyID);

            modelBuilder.Entity<Practice>()
                .HasOne(p => p.Student)                 
                .WithMany(s => s.Practices)             
                .HasForeignKey(p => p.StudentId)        
                .OnDelete(DeleteBehavior.Cascade); //restrict por cascade pa que cuando se elimine un estudiante se eliminen sus practicas aunq no se si se usa

            modelBuilder.Entity<Practice>()
                .HasOne(p => p.Company)                
                .WithMany(c => c.Practices)             
                .HasForeignKey(p => p.CompanyId)       
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
