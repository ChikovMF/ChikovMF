using ChikovMF.Application.Interfaces;
using ChikovMF.Domain;
using ChikovMF.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Persistence;

public class ChikovMFDbContext : DbContext, IChikovMFDbContext
{
    public DbSet<Project> Projects { get; set; }

    public ChikovMFDbContext(DbContextOptions<ChikovMFDbContext> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new ImageLinkConfigurations());

        base.OnModelCreating(modelBuilder);
    }
}
