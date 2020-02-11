using HeroesBackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesBackend.Repository.Mappers
{
    public class HeroMapper : IEntityTypeConfiguration<Hero>
    {
        public void Configure(EntityTypeBuilder<Hero> builder)
        {
            builder.ToTable("hero");

            builder.HasKey(c => c.Id);

            builder.Ignore(c => c.UpdateDate);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.Bio)
                .HasColumnName("bio")
                .HasMaxLength(500);

            builder.Property(c => c.Image)
                .HasColumnName("image")
                .HasMaxLength(100);

            builder.Property(c => c.FirstAppearance)
                .HasColumnName("first_appearance");

            builder.Property(c => c.CreateDate)
                .HasColumnName("create_date")
                .IsRequired();

            builder.Property(c => c.HomeId)
                .HasColumnName("home_id")
                .IsRequired();

            builder.HasOne(c => c.Home)
                .WithMany(h => h.Heroes)
                .HasForeignKey(c => c.HomeId);
        }
    }
}
