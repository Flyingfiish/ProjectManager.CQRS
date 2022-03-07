using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using ProjectManager.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Infrastructure.EfCore
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<CompanyRole> CompanyRoles { get; set; }
        public DbSet<CompanyUserCompanyRole> CompanyUserCompanyRoles { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=DESKTOP-GPON2I3;Database=ProjectManager;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyUserConfiguration());

            modelBuilder.ApplyConfiguration(new IChangableConfiguration<User>());
            modelBuilder.ApplyConfiguration(new IChangableConfiguration<Company>());
            modelBuilder.ApplyConfiguration(new IChangableConfiguration<CompanyRole>());
            modelBuilder.ApplyConfiguration(new IChangableConfiguration<CompanyUser>());
            modelBuilder.ApplyConfiguration(new IChangableConfiguration<CompanyUserCompanyRole>());
        }
    }
}
