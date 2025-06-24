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
    public class CarCategoryConfiguration : IEntityTypeConfiguration<CarCategory>
    {
        public void Configure(EntityTypeBuilder<CarCategory> builder)
        {
            builder.ToTable("CarCategories");

            builder.HasKey(cc => cc.CarCategoryId);

            builder.Property(cc => cc.CarCategoryName)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
