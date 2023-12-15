using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class RoleConfiguration : IEntityTypeConfiguration<Role>
  {
     public void Configure(EntityTypeBuilder<Role> builder)
    {

          builder.ToTable("role");

            builder.Property(p => p.Nombre)
            .HasMaxLength(50)
            .IsRequired();

            builder.HasData(
            new Role
            {
                Id = 1,
                Nombre = "Administrador"
            },
            new Role
            {
                Id = 2,
                Nombre = "Empleado"
            }
            );
  }
  }