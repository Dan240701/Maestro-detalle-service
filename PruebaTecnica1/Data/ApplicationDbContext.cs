using Microsoft.EntityFrameworkCore;


namespace PruebaTecnica.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Order>()
                 .HasMany(o => o.OrderItems)
                 .WithOne(oi => oi.Order)
                 .HasForeignKey(oi => oi.OrderId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
