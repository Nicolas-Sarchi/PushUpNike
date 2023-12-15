using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    builder.ToTable("category");

    builder.Property(p => p.Name)
    .IsRequired()
    .HasMaxLength(30);

    builder.HasData(
      new Category{Id = 1, Name = "Abrigos"},
      new Category{Id = 2, Name = "Camisetas"},
      new Category{Id = 3, Name = "Pantalones"}

    );
  }
}