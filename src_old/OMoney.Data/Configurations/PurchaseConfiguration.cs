﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Configurations
{
    public class PurchaseConfiguration : EntityTypeConfiguration<Purchase>
    {
        public PurchaseConfiguration()
        {
            ToTable("Purchases");
            HasKey(i => i.Id);
            Property(i => i.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).IsRequired().HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(255);
            Property(i => i.Price).IsRequired().HasColumnName("Price");
            Property(i => i.Buyed).IsRequired().HasColumnName("Buyed").HasColumnType("bit");
            Property(i => i.BuyedTime).IsOptional().HasColumnName("BuyedTime");

            HasRequired(i => i.Category).WithMany(c => c.Purchases).HasForeignKey(i => i.CategoryId).WillCascadeOnDelete(true);
        }
    }
}
