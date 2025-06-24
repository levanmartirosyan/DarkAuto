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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(p => p.PaymentId);

            builder.Property(p => p.isPaid)
                   .IsRequired();

            builder.Property(p => p.PaymentAmount)
                   .HasColumnType("decimal(10,2)");

            builder.HasOne<Delivery>()
                   .WithMany()
                   .HasForeignKey(p => p.DeliveryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
