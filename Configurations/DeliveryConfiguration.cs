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
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.ToTable("Deliveries");

            builder.HasKey(d => d.DeliveryId);

            builder.Property(d => d.DeliveryAddress)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(d => d.DeliveryDate)
                   .IsRequired();

            builder.Property(d => d.IsDelivered)
                   .IsRequired();

            builder.Property(d => d.TrackingNumber)
                   .HasMaxLength(100);

            builder.Property(d => d.DeliveryCost)
                   .HasColumnType("decimal(10,2)");

            builder.HasOne(d => d.Payment)
                   .WithOne(p => p.Delivery)
                   .HasForeignKey<Delivery>(d => d.PaymentId) 
                   .IsRequired(false)                         
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
