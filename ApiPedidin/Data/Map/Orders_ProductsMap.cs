using ApiPedidin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPedidin.Data.Map
{
    public class Orders_ProductsMap : IEntityTypeConfiguration<Orders_ProductsModel>
    {
        public void Configure(EntityTypeBuilder<Orders_ProductsModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
        }
    }
}