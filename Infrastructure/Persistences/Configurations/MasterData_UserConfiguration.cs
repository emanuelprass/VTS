using System;
using SceletonAPI.Application.Misc;
using SceletonAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SceletonAPI.Infrastructure.Persistences.Configurations
{
    public class MasterData_UserConfiguration : IEntityTypeConfiguration<MasterDataUser>
    {
        public void Configure(EntityTypeBuilder<MasterDataUser> builder)
        {
            builder.Property(e => e.ID)
                .HasColumnType("int")
                .HasColumnName("ID");

            builder.Property(e => e.FullName)
                .HasColumnName("FullName")
                .HasMaxLength(500);

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .HasMaxLength(100);

            builder.Property(e => e.VendorName)
                .HasColumnName("VendorName")
                .HasMaxLength(500);

            builder.Property(e => e.Company)
                .HasColumnName("Company")
                .HasMaxLength(100);

            builder.Property(e => e.UserRole)
                .HasColumnType("string")
                .HasColumnName("UserRole");

            builder.Property(e => e.Password)
                .HasColumnName("Password")
                .HasMaxLength(100);

            builder.Property(e => e.ConfPassword)
                .HasColumnName("ConfPassword")
                .HasMaxLength(100);

            builder.Property(e => e.RowStatus)
                .HasColumnType("smallint")
                .HasColumnName("RowStatus");

            builder.Property(e => e.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(100);

            builder.Property(e => e.LastUpdatedBy)
                .HasColumnName("LastUpdatedBy")
                .HasMaxLength(100);

            builder.Property(e => e.LastUpdatedTime)
                .HasColumnName("LastUpdatedTime")
                .HasColumnType("datetime");

            builder.Property(e => e.CreatedTime)
                .HasColumnName("CreatedTime")
                .HasColumnType("datetime");

            builder.HasQueryFilter(m => m.RowStatus == 0);
            builder.ToTable("MasterData_User");
        }
    }
}
