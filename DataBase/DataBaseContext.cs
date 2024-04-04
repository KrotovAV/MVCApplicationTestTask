using DataBase.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    //    dotnet ef migrations add InitialMigration 
    //    dotnet ef database update
    public class DataBaseContext : DbContext
    {

        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public DataBaseContext()
        {

        }
        public DataBaseContext(DbContextOptions dbc) : base(dbc)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .Build();

            optionsBuilder.UseLazyLoadingProxies().
                    UseSqlServer(config.GetConnectionString("Connection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("employee");

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.BirthDate)
                    .IsRequired();
                entity.Property(e => e.SeriaPassport)
                    .IsRequired()
                    .HasMaxLength(2);
                entity.Property(e => e.NumberPassport)
                    .IsRequired()
                    .HasMaxLength(7);
                //entity.Property(e => e.Organization)
                //    .IsRequired();

            });


            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("organization");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Inn)
                    .IsRequired()
                    .HasMaxLength(9);
                entity.Property(e => e.AdressUri)
                    .IsRequired();
                entity.Property(e => e.AdressFact)
                    .IsRequired();

            });
        }
    }

}

