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
    public class BidConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.ToTable("Bids");

            builder.HasKey(b => b.BidId);

            builder.Property(b => b.BidDate)
                   .IsRequired();

            builder.HasOne(b => b.Car)
                   .WithMany()
                   .HasForeignKey(b => b.CarId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.User)
                   .WithMany()
                   .HasForeignKey(b => b.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
