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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.Companies)
                .WithMany(c => c.Users)
                .UsingEntity<CompanyUser>(
                    cu => cu
                        .HasOne(u => u.Company)
                        .WithMany(u => u.CompanyUsers)
                        .HasForeignKey(u => u.CompanyId)
                        .OnDelete(DeleteBehavior.NoAction),
                    cu => cu
                        .HasOne(u => u.User)
                        .WithMany()
                        .HasForeignKey(u => u.UserId)
                        .OnDelete(DeleteBehavior.NoAction),
                    cu => 
                    {
                        cu.HasIndex(u => u.CompanyId);
                        //cu.HasKey(cu => new
                        //{
                        //    cu.Id,
                        //    cu.UserId,
                        //    cu.CompanyId
                        //});
                    });

            builder.HasIndex(u => new
            {
                u.Login,
                u.Password
            });
            builder.HasIndex(u => u.Id);
            //builder
            //    .Ignore(u => u.CreatedBy)
            //    .Ignore(u => u.CreatedById);
            //builder
            //    .Ignore(u => u.ModifiedBy)
            //    .Ignore(u => u.ModifiedById);
        }
    }
}
