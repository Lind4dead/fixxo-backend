using fixxo_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace fixxo_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductColorEntity> Colors { get; set; }
        public DbSet<ProductSizeEntity> Sizes { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<AdditionalInformationEntity> AdditionalInformations { get; set; }
        public DbSet<ClassificationEntity> Classifications { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderProductEntity> OrderProduct { get; set; }
    }
}
