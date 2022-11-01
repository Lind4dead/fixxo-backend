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
        public DbSet<CategoryEntity> Categoríes { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }

    }
}
