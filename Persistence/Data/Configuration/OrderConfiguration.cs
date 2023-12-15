using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class OrderConfiguration : IEntityTypeConfiguration<Order>
  {
     public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("order");

        builder.Property(p => p.Date)
        .IsRequired()
        .HasColumnType("date");

        builder.Property(p => p.Total)
        .IsRequired();

        builder.HasOne(p => p.User)
        .WithMany(p => p.Orders)
        .HasForeignKey(p => p.UserId);

        
        
  }
  }