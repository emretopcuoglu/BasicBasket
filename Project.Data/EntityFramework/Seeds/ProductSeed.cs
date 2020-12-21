using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.EntityFramework.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product{ ProductId = 1, ProductName = "Cep Telefonu", Price = 7500m, Stock = 50 },
                new Product{ ProductId = 2, ProductName = "Bilgisayar", Price = 12000m, Stock = 40 },
                new Product{ ProductId = 3, ProductName = "Tablet", Price = 3000m, Stock = 10 }
                );
        }
    }
}
