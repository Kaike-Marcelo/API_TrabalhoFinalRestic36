using ApiPedidin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPedidin.Data.Map
{
    public class CategoriesMap : IEntityTypeConfiguration<CategoriesModel>
    {
        public void Configure(EntityTypeBuilder<CategoriesModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PathImage).IsRequired().HasMaxLength(255);
        }
    }
}