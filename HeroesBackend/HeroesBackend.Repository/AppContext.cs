using HeroesBackend.Repository.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesBackend.Repository
{
    public class AppContext : DbContext
    {
        public AppContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\SQLEXPRESS;database=HeroesappDB;trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HeroMapper());
            modelBuilder.ApplyConfiguration(new HeroHomeMapper());
        }
    }
}
