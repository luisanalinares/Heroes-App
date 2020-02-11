using HeroesBackend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesBackend.Repository.Mappers
{
    public class HeroHomeMapper : IEntityTypeConfiguration<HeroHome>
    {
        public void Configure(EntityTypeBuilder<HeroHome> builder)
        {
            builder.ToTable("hero_home");

            builder.HasKey(c => c.Id);

            builder.Ignore(c => c.UpdateDate);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.Image)
                .HasColumnName("image")
                .HasMaxLength(100);

            builder.Property(c => c.CreateDate)
                .HasColumnName("create_date")
                .IsRequired();
        }
    }
}
