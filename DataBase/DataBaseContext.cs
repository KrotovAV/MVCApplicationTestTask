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
                
                entity.ToTable("employee");

                entity.HasKey(e => e.Id)
                    .HasName("employee_primary_key");

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("surname");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("secondname");
                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasColumnName("birthdata");
                entity.Property(e => e.SeriaPassport)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("seriapass");
                entity.Property(e => e.NumberPassport)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasColumnName("numberpass");

                entity.HasOne(u => u.Organization)
                        .WithMany(c => c.Employees)
                        .HasForeignKey(u => u.OrganizationId);
            });


            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("organization");

                entity.HasKey(e => e.Id)
                    .HasName("organization_primary_key");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Inn)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasColumnName("inn");
                entity.Property(e => e.AdressUri)
                    .IsRequired()
                    .HasColumnName("uriadress");
                entity.Property(e => e.AdressFact)
                    .IsRequired()
                    .HasColumnName("factadress");

            });
        }
    }

}

