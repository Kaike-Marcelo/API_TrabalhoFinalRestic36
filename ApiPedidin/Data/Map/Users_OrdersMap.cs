using ApiPedidin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPedidin.Data.Map
{
    public class Users_OrdersMap : IEntityTypeConfiguration<Users_OrdersModel>
    {
        public void Configure(EntityTypeBuilder<Users_OrdersModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}