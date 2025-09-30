using Microsoft.EntityFrameworkCore;
using TestMVC.Models;

namespace TestMVC.Data
{
    public class PgDbContext : DbContext
    {
        public PgDbContext(DbContextOptions<PgDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.IdClient);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Client)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.IdClient);
        }
    }
}