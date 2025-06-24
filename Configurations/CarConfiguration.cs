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
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");

            builder.HasKey(c => c.CarId);

            builder.Property(c => c.CarModelName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Engine)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.ManufactureDate)
                .IsRequired();

            builder.Property(c => c.Price)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.IsDamaged)
                .IsRequired();

            builder.Property(c => c.IsSold)
                .IsRequired();

            builder.Property(c => c.SellDate)
                .IsRequired();

            builder.HasOne(c => c.carBrand)
                .WithMany()
                .HasForeignKey(c => c.CarBrandId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.carCategory)
                .WithMany()
                .HasForeignKey(c => c.CarCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.seller)
                .WithMany()
                .HasForeignKey(c => c.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.location)
                .WithMany()
                .HasForeignKey(c => c.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.payment)
                .WithMany()
                .HasForeignKey(c => c.PaymentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
