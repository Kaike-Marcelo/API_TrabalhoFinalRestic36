using ApiPedidin.Data.Map;
using ApiPedidin.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidin.Data
{
    public class PedidinDBContext : DbContext
    {
        public PedidinDBContext(DbContextOptions<PedidinDBContext> options) : base(options)
        {
        }

        public DbSet<UsersModel> Users { get; set; }
        public DbSet<Users_OrdersModel> Users_Orders { get; set; }
        public DbSet<OrdersModel> Orders { get; set; }
        public DbSet<Orders_ProductsModel> Orders_Products { get; set; }
        public DbSet<ProductsModel> Products { get; set; }
        public DbSet<CategoriesModel> Categories { get; set; }
        public DbSet<StatusModel> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new StatusMap());
            modelBuilder.ApplyConfiguration(new CategoriesMap());
            modelBuilder.ApplyConfiguration(new ProductsMap());
            modelBuilder.ApplyConfiguration(new OrdersMap());
            modelBuilder.ApplyConfiguration(new Orders_ProductsMap());
            modelBuilder.ApplyConfiguration(new Users_OrdersMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}