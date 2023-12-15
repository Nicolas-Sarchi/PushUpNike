using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class ProductConfiguration : IEntityTypeConfiguration<Product>
  {
     public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");

        builder.Property(p => p.ProductId)
        .IsRequired()
        .HasMaxLength(30);

        builder.Property(p => p.Title)
        .IsRequired()
        .HasMaxLength(25);

        builder.Property(p => p.Image)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Price)
        .IsRequired();

        builder.HasOne(p => p.Category)
        .WithMany(p => p.Products)
        .HasForeignKey(p => p.CategoryId);

        builder.HasData(
            new Product{Id =1, ProductId = "abrigo-01", Title = "Abrigo 01", Image= "./img/abrigos/01.jpg", CategoryId=  1, Price=  1000},
            new Product{Id =2, ProductId = "abrigo-02", Title = "Abrigo 02", Image= "./img/abrigos/02.jpg", CategoryId=  1, Price=  1000},
            new Product{Id =3, ProductId = "abrigo-03", Title = "Abrigo 03", Image= "./img/abrigos/03.jpg", CategoryId=  1, Price=  1000},
            new Product{Id =4, ProductId = "abrigo-04", Title = "Abrigo 04", Image= "./img/abrigos/04.jpg", CategoryId=  1, Price=  1000},
            new Product{Id =5, ProductId = "abrigo-05", Title = "Abrigo 05", Image= "./img/abrigos/05.jpg", CategoryId=  1, Price=  1000},
            new Product{Id =6, ProductId = "camiseta-01", Title = "Camiseta 01", Image= "./img/camisetas/01.jpg", CategoryId=  2, Price=  1000},
            new Product{Id =7, ProductId = "camiseta-02", Title = "Camiseta 02", Image= "./img/camisetas/02.jpg", CategoryId=  2, Price=  1000},
            new Product{Id =8, ProductId = "camiseta-03", Title = "Camiseta 03", Image= "./img/camisetas/03.jpg", CategoryId=  2, Price=  1000},
            new Product{Id =9, ProductId = "camiseta-04", Title = "Camiseta 04", Image= "./img/camisetas/04.jpg", CategoryId=  2, Price=  1000},
            new Product{Id =10, ProductId = "camiseta-05", Title = "Camiseta 05", Image= "./img/camisetas/05.jpg", CategoryId=  2, Price=  1000},
            new Product{Id =11, ProductId = "camiseta-06", Title = "Camiseta 06", Image= "./img/camisetas/06.jpg", CategoryId=  2, Price=  1000},
            new Product{Id =12, ProductId = "camiseta-07", Title = "Camiseta 07", Image= "./img/camisetas/07.jpg", CategoryId=  2, Price=  1000},
            new Product{Id =13, ProductId = "camiseta-08", Title = "Camiseta 08", Image= "./img/camisetas/08.jpg", CategoryId=  2, Price=  1000},
            new Product{Id =14, ProductId = "pantalon-01", Title = "Pantalón 01", Image= "./img/pantalons/01.jpg", CategoryId=  3, Price=  1000},
            new Product{Id =15, ProductId = "pantalon-02", Title = "Pantalón 02", Image= "./img/pantalons/02.jpg", CategoryId=  3, Price=  1000},
            new Product{Id =16, ProductId = "pantalon-03", Title = "Pantalón 03", Image= "./img/pantalons/03.jpg", CategoryId=  3, Price=  1000},
            new Product{Id =17, ProductId = "pantalon-04", Title = "Pantalón 04", Image= "./img/pantalons/04.jpg", CategoryId=  3, Price=  1000},
            new Product{Id =18, ProductId = "pantalon-05", Title = "Pantalón 05", Image= "./img/pantalons/05.jpg", CategoryId=  3, Price=  1000}
        );
  }
  }