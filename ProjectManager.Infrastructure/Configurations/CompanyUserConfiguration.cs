using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Infrastructure.Configurations
{
    public class CompanyUserConfiguration : IEntityTypeConfiguration<CompanyUser>
    {
        public void Configure(EntityTypeBuilder<CompanyUser> builder)
        {
            builder
                .HasMany(cu => cu.CompanyRoles)
                .WithMany(cr => cr.CompanyUsers)
                .UsingEntity<CompanyUserCompanyRole>(
                    cucr => cucr
                        .HasOne(u => u.CompanyRole)
                        .WithMany()
                        .HasForeignKey(u => u.CompanyRoleId)
                        .OnDelete(DeleteBehavior.NoAction),
                    cucr => cucr
                        .HasOne(u => u.CompanyUser)
                        .WithMany()
                        .HasForeignKey(u => u.CompanyUserId)
                        .OnDelete(DeleteBehavior.NoAction)
                    //cucr =>cucr
                    //   .HasKey(cucr => new
                    //       {
                    //           cucr.Id,
                    //           cucr.CompanyUserId,
                    //           cucr.CompanyRoleId,
                    //       })
                    );
            

        }
    }
}
