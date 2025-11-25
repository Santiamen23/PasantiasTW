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
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<EsudianteEmpresa> esudiantesEmpresas => Set<EsudianteEmpresa>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>();

            modelBuilder.Entity<EsudianteEmpresa>()
                .HasKey(ee => new { ee.StudentID, ee.CompanyID });

            modelBuilder.Entity<EsudianteEmpresa>()
                .HasOne(ee => ee.Student)
                .WithMany(e => e.StudentCompany)
                .HasForeignKey(ee => ee.StudentID);

            modelBuilder.Entity<EsudianteEmpresa>()
                .HasOne(ee => ee.Company)
                .WithMany(comp => comp.StudentCompany)
                .HasForeignKey(ee => ee.CompanyID);
        }
    }
}
