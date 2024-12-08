using CodeZoneTest.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace CodeZoneTest.Data;
public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<StoreItems> StoreItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<StoreItems>()
            .HasKey(s => s.Id);
        modelBuilder.Entity<StoreItems>()
            .HasIndex(s => new { s.ItemId, s.StoreId })
            .IsUnique();
    }
}