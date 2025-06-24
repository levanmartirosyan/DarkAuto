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
    public class CarBrandConfiguration : IEntityTypeConfiguration<CarBrand>
    {
        public void Configure(EntityTypeBuilder<CarBrand> builder)
        {
            builder.ToTable("CarBrands");

            builder.HasKey(cb => cb.CarBrandId);

            builder.Property(cb => cb.CarBrandName)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
