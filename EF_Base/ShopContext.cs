namespace EF_Base
{
    using EF_Base.Tables;
    using EF_Base.Tables.Many_to_Many;
    using Microsoft.EntityFrameworkCore;

    public class ShopContext : DbContext
    {
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Comment> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartProduct>()
                .HasKey(t => new { t.ProductId, t.CartId });

            modelBuilder.Entity<CartProduct>()
                .HasOne(sc => sc.Cart)
                .WithMany(s => s.CartProducts)
                .HasForeignKey(sc => sc.CartId);

            modelBuilder.Entity<CartProduct>()
                .HasOne(sc => sc.Product)
                .WithMany(s => s.CartProducts)
                .HasForeignKey(sc => sc.ProductId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Shop_db;Trusted_Connection=True;");
        }
    }
}
