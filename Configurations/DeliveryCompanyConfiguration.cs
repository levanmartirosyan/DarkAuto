using DarkAuto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Configurations
{
    public class DeliveryCompanyConfiguration : IEntityTypeConfiguration<DeliveryCompany>
    {
        public void Configure(EntityTypeBuilder<DeliveryCompany> builder)
        {
            builder.ToTable("DeliveryCompanies");

            builder.HasKey(dc => dc.CompanyId);

            builder.Property(dc => dc.CompanyName)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
