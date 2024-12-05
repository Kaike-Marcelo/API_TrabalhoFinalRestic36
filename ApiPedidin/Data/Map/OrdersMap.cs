using ApiPedidin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPedidin.Data.Map
{
    public class OrdersMap : IEntityTypeConfiguration<OrdersModel>
    {
        public void Configure(EntityTypeBuilder<OrdersModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.statusId).IsRequired();
            builder.Property(x => x.value).IsRequired().HasMaxLength(100);
        }
    }
}