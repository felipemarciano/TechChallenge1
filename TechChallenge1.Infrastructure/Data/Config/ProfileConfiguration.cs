using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge1.Core.Entities;

namespace TechChallenge1.Infrastructure.Data.Config
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .IsRequired();

            builder.Property(cb => cb.ApplicationUserId)
                .IsRequired();

            builder.Property(cb => cb.UserName)
                .IsRequired(false)
                .HasMaxLength(128);

            builder.Property(cb => cb.Biography)
                .IsRequired(false)
                .HasColumnType("text");

            builder.Property(cb => cb.PictureUri)
                .IsRequired()
                .IsRequired(false)
                .HasColumnType("text");

            builder.Property(e => e.Gender)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(e => e.DateCreate)
                .IsRequired();            
            
            builder.Property(e => e.DateUpdate)
                .IsRequired(false);
        }
    }
}
