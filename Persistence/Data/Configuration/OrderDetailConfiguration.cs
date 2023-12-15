using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
  {
     public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("order_detail");

        builder.Property(p => p.Quantity)
        .IsRequired();

        builder.Property(p => p.SubTotal)
        .IsRequired();

        builder.HasOne(p => p.Product)
        .WithMany(p => p.OrderDetails)
        .HasForeignKey(p => p.ProductId);

        
  }
  }