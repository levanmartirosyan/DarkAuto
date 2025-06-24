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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(c => c.UserId);

            builder.Property(c => c.UserName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(c => c.Email) 
                   .IsUnique();

            builder.Property(c => c.Password)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(c => c.IsAdmin)
                   .IsRequired();
        }
    }
}
