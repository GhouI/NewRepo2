using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BasicSkin.Data;

namespace BasicSkin.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<Transaction> Transcations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Order and OrderItem configuration
            builder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            builder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Item)
                .WithMany(i => i.OrderItems) 
                .HasForeignKey(oi => oi.ItemId);

            builder.Entity<OrderItem>()
                .Property(o => o.Price)
                .HasColumnType("decimal(18,2)");

            // Cart and CartItem configuration
            builder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart) 
                .HasForeignKey<Cart>(c => c.UserId);

            builder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId);

            builder.Entity<CartItem>()
                .HasOne(ci => ci.Item)
                .WithMany() // Assuming the Item model is defined elsewhere and does not have a navigation property to CartItem
                .HasForeignKey(ci => ci.ItemId);

            // Transaction configuration
            builder.Entity<Transaction>()
                .HasOne(t => t.Order)
                .WithMany() // Assuming the Order model is defined elsewhere and does not have a navigation property to Transaction
                .HasForeignKey(t => t.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
                

            builder.Entity<Transaction>()
                .Property(o => o.Amount)
                .HasColumnType("decimal(18,2)");
                

            builder.Entity<Cart>()
                .HasIndex(c => c.UserId)
                .IsUnique();  // This enforces that each user has only one cart


        }
        public DbSet<BasicSkin.Data.Item> Item { get; set; } = default!;
    }
}
